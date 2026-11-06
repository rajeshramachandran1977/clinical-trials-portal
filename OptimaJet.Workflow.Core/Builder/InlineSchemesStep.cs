using System;
using System.Collections.Generic;
using System.Linq;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Builder
{
    public class InlineSchemesStep : BuildStep
    {
        private class SchemesTree
        {
            public ProcessDefinition ProcessDefinition { get; set; }

            public string SchemeCode => ProcessDefinition.Name;

            public SchemesTree Parent { get; set; }

            public readonly List<SchemesTree> Children = new List<SchemesTree>();

            public bool IsRoot => Parent == null;

            public bool HasAnyChild => Children.Any();

            public SchemesTree(ProcessDefinition processDefinition)
            {
                ProcessDefinition = processDefinition;
            }

            public bool SetParent(SchemesTree parent, out List<string> cycleInfo)
            {
                var names = parent.GetSchemeNamesFromRootToThis();

                if (names.Contains(SchemeCode))
                {
                    names.Add(SchemeCode);
                    cycleInfo = names;
                    return false;
                }

                Parent?.Children.Remove(this);
                Parent = parent;
                if (!parent.Children.Contains(this))
                    parent.Children.Add(this);

                cycleInfo = null;
                return true;
            }

            public List<string> GetSchemeNamesFromRootToThis()
            {
                var pointer = this;

                var result = new List<string> {pointer.SchemeCode};

                while (!pointer.IsRoot)
                {
                    pointer = pointer.Parent;
                    result.Add(pointer.SchemeCode);
                }

                result.Reverse();

                return result;
            }

            public string GroupName
            {
                get
                {
                    if (IsRoot)
                        return null;

                    return string.Join("_", GetSchemeNamesFromRootToThis());
                }
            }
        }

        public InlineSchemesStep(IWorkflowBuilder builder) : base(builder)
        {
        }

        public override string Name => nameof(InlineSchemesStep);

        public override BuildStepResult Execute(ProcessDefinition processDefinition, IDictionary<string, object> parameters)
        {
            var inlines = processDefinition.Activities.Where(a => a.ActivityType == ActivityType.Inline).Select(a => a as IInlineActivity).ToList();
            if (!inlines.Any())
                return BuildStepResult.Success(processDefinition);

            //form schemes tree, look for cycle refs
            var schemeCodes = inlines.Select(i => i.SchemeCode).Distinct().ToList();
            var root = new SchemesTree(processDefinition);

            if (!CreateSchemesTree(root, schemeCodes, parameters, new Dictionary<string, ProcessDefinition>(), out var error))
                return BuildStepResult.Fail($"Can't generate scheme {processDefinition.Name}. Inline cycle reference {error}");

            //now we have complete schemes tree, can start inlining
            var errors = new List<string>();
            InlineSchemesRecursive(root, errors);
            
            var builtProcessDefinition = root.ProcessDefinition;
            
//            //last step we need to set parent group name in the initial inlined activities, it is necessary for the Designer
//            SetParentGroupName(builtProcessDefinition);   

            if (errors.Any())
                return BuildStepResult.Fail(errors);
            return BuildStepResult.Success(builtProcessDefinition);
        }

//        private static void SetParentGroupName(ProcessDefinition builtProcessDefinition)
//        {
//            //this method sets parent group name in the initial inlined activities, it is necessary for the Designer
//            var initialInlinedActivities = builtProcessDefinition.Activities.Where(a => a.WasInlined && a.DesignerSettings.InlineElementSettings != null).ToList();
//
//            foreach (var initialInlinedActivity in initialInlinedActivities)
//            {
//                var firstIngoingTransition = builtProcessDefinition.Transitions.FirstOrDefault(t => t.To == initialInlinedActivity);
//                if (firstIngoingTransition != null)
//                {
//                    firstIngoingTransition.To.DesignerSettings.InlineElementSettings.Group = firstIngoingTransition.From.DesignerSettings.Group;
//                }
//            }
//        }

        private bool CreateSchemesTree(SchemesTree root, List<string> schemeCodes, IDictionary<string, object> parameters,
            Dictionary<string, ProcessDefinition> cache, out string error)
        {
            foreach (var code in schemeCodes)
            {
                if (!cache.TryGetValue(code, out var pd))
                {
                    pd = Builder.GenerateProcessDefinition(code, parameters);
                    cache.Add(code, pd);
                }

                var newNode = new SchemesTree(pd);
                if (!newNode.SetParent(root, out var codes))
                {
                    error = string.Join("->", codes);
                    return false;
                }

                var inlines = pd.Activities.Where(a => a.ActivityType == ActivityType.Inline).Select(a => a as IInlineActivity).ToList();

                if (inlines.Any())
                {
                    var newSchemeCodes = inlines.Select(i => i.SchemeCode).Distinct().ToList();
                    if (!CreateSchemesTree(newNode, newSchemeCodes, parameters, cache, out var newError))
                    {
                        error = newError;
                        return false;
                    }

                }

            }

            error = null;
            return true;
        }

        private bool InlineSchemesRecursive(SchemesTree tree, List<string> errors)
        {
            if (!tree.HasAnyChild)
            {
                if (!tree.IsRoot)
                {
                    var newPd = Inline(tree.Parent, tree, out var newErrors);
                    tree.Parent.Children.Remove(tree);
                    tree.Parent.ProcessDefinition = newPd;
                    if (newErrors != null && newErrors.Any())
                    {
                        errors.AddRange(newErrors);
                    }

                    return InlineSchemesRecursive(tree.Parent, errors);
                }
            }
            else
            {
                return InlineSchemesRecursive(tree.Children.First(), errors);

            }

            //root without children - end of inlining
            return errors == null || !errors.Any();
        }

        private ProcessDefinition Inline(SchemesTree target, SchemesTree inlined, out List<string> errors)
        {
            var targetProcessDefinition = target.ProcessDefinition;
            var inlinedProcessDefinition = inlined.ProcessDefinition;
            var targetGroupName = target.GroupName;
            var inlinedGroupName = inlined.GroupName;
            
            errors = new List<string>();

            var pointsOfInlining = targetProcessDefinition.Activities.Where(a => a.ActivityType == ActivityType.Inline && a.SchemeCode.Equals(inlinedProcessDefinition.Name, StringComparison.Ordinal))
                .Select(a => a.Name).ToList();
            if (!pointsOfInlining.Any())
                return targetProcessDefinition;

            var merged = targetProcessDefinition.Clone();

            //parameters compatibility check & merge
            foreach (var inlinedParameter in inlinedProcessDefinition.Parameters.Where(p=>p.Purpose != ParameterPurpose.System))
            {
                var existingParameter = merged.Parameters.FirstOrDefault(ep => ep.Name.Equals(inlinedParameter.Name, StringComparison.Ordinal));

                if (existingParameter == null)
                {
                    merged.Parameters.Add(inlinedParameter.Clone());
                }
                else if (!TryMergeParameters(existingParameter, inlinedParameter))
                {
                    errors.Add($"Incompatible parameter {existingParameter.Name} in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                }
            }

            //commands compatibility check & merge 
            foreach (var inlinedCommand in inlinedProcessDefinition.Commands)
            {
                var existingCommand = merged.Commands.FirstOrDefault(ec => ec.Name.Equals(inlinedCommand.Name, StringComparison.Ordinal));

                if (existingCommand == null)
                {
                    merged.Commands.Add(inlinedCommand.Clone());
                }
                else if (!TryMergeCommand(existingCommand, inlinedCommand))
                {
                    errors.Add($"Incompatible command {existingCommand.Name} in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                }
            }

            //timers compatibility check & merge
            foreach (var inlinedTimer in inlinedProcessDefinition.Timers)
            {
                var existingTimer = merged.Timers.FirstOrDefault(et => et.Name.Equals(inlinedTimer.Name, StringComparison.Ordinal));
                if (existingTimer == null)
                {
                    merged.Timers.Add(inlinedTimer.Clone());
                }
                else if (!TryMergeTimer(existingTimer, inlinedTimer))
                {
                    errors.Add($"Incompatible timer {existingTimer.Name} in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                }
            }

            //localization merge
            foreach (var inlinedLocalization in inlinedProcessDefinition.Localization)
            {
                var existingLocalization = merged.Localization.FirstOrDefault(el => el.ObjectName.Equals(inlinedLocalization.ObjectName, StringComparison.Ordinal) &&
                                                                                    el.Culture.Equals(inlinedLocalization.Culture, StringComparison.Ordinal) &&
                                                                                    el.Type == inlinedLocalization.Type);
                if (existingLocalization == null)
                {
                    merged.Localization.Add(inlinedLocalization.Clone());
                }
                else if (!TryMergeLocalization(existingLocalization, inlinedLocalization))
                {
                    errors.Add(
                        $"Incompatible localization {existingLocalization.Type:G} with name {existingLocalization.ObjectName} for {existingLocalization.Culture} culture in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                }
            }

            //code actions inlining
            var ruleNameConversions = new Dictionary<string, string>();
            var actionNameConversions = new Dictionary<string, string>();
            var conditionNameConversions = new Dictionary<string, string>();

            foreach (var inlinedCodeAction in inlinedProcessDefinition.CodeActions)
            {
                var newName = inlinedCodeAction.WasInlined ? inlinedCodeAction.Name : $"{inlinedProcessDefinition.Name}_{inlinedCodeAction.Name}";
                var oldName = inlinedCodeAction.Name;

                if (!newName.Equals(oldName, StringComparison.Ordinal))
                {
                    if (inlinedCodeAction.Type == CodeActionType.Action && !actionNameConversions.ContainsKey(oldName))
                    {
                        actionNameConversions.Add(oldName, newName);
                    }
                    else if (inlinedCodeAction.Type == CodeActionType.Condition && !conditionNameConversions.ContainsKey(oldName))
                    {
                        conditionNameConversions.Add(oldName, newName);
                    }
                    else if ((inlinedCodeAction.Type == CodeActionType.RuleGet || inlinedCodeAction.Type == CodeActionType.RuleCheck) && !ruleNameConversions.ContainsKey(oldName))
                    {
                        ruleNameConversions.Add(oldName, newName);
                    }
                }

                if (merged.CodeActions.Any(ca => ca.Name.Equals(newName, StringComparison.Ordinal) && ca.Type == inlinedCodeAction.Type && ca.WasInlined)) //was inlined before
                {
                    continue;
                }

                if (merged.CodeActions.Any(ca => ca.Name.Equals(newName, StringComparison.Ordinal) && ca.Type == inlinedCodeAction.Type)) //name conflict
                {
                    errors.Add($"Code action {oldName} type {inlinedCodeAction.Type} name conflict in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                    continue;
                }

                var cloned = inlinedCodeAction.Clone();
                cloned.Name = newName;
                if (!cloned.WasInlined)
                {
                    cloned.WasInlined = true;
                    cloned.OriginalName = oldName;
                    cloned.OriginalSchemeCode = inlinedProcessDefinition.Name;
                }

                merged.CodeActions.Add(cloned);
            }

            //actor inlining 
            var actorNameConversions = new Dictionary<string, string>();
            var allActors = new Dictionary<string, ActorDefinition>();
            foreach (var inlinedActor in inlinedProcessDefinition.Actors)
            {
                var newName = inlinedActor.WasInlined ? inlinedActor.Name : $"{inlinedProcessDefinition.Name}_{inlinedActor.Name}";
                var oldName = inlinedActor.Name;
                if (!newName.Equals(oldName, StringComparison.Ordinal) && !actorNameConversions.ContainsKey(oldName))
                {
                    actorNameConversions.Add(oldName, newName);
                }

                if (merged.Actors.Any(a => a.Name.Equals(newName) && a.WasInlined))
                {
                    continue;
                }

                if (merged.Actors.Any(a => a.Name.Equals(newName)))
                {
                    errors.Add($"Actor {oldName} name conflict in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                    continue;
                }

                var cloned = inlinedActor.Clone();
                cloned.Name = newName;
                if (!cloned.WasInlined)
                {
                    cloned.WasInlined = true;
                    cloned.OriginalName = oldName;
                    cloned.OriginalSchemeCode = inlinedProcessDefinition.Name;
                }

                if (ruleNameConversions.TryGetValue(cloned.Rule, out var newRuleName))
                {
                    cloned.Rule = newRuleName;
                }

                merged.Actors.Add(cloned);
                allActors.Add(cloned.Name, cloned);
            }

            //activities & transitions inlining
            foreach (var pointOfInlining in pointsOfInlining)
            {
                var initialActivity = inlinedProcessDefinition.InitialActivity;
                if (initialActivity == null)
                {
                    errors.Add($"Initial activity in the scheme {inlinedProcessDefinition.Name} is not found");
                    continue;
                }

                //same as the name of first activity in inlined scheme after rename
                //the initial activity will be always inlined first time so we can determine the 
                var specificInlinedGroupName = GetNewActivityName(initialActivity,pointOfInlining,inlinedProcessDefinition); 
                
                ActivityDefinition initial = null;
                var finals = new List<ActivityDefinition>();
                var allClonedActivities = new Dictionary<string, ActivityDefinition>();
                var activityNameConversion = new Dictionary<string, string>();
                //activities
                foreach (var inlinedActivity in inlinedProcessDefinition.Activities)
                {
                    var oldName = inlinedActivity.Name;
                    var newName = GetNewActivityName(inlinedActivity, pointOfInlining, inlinedProcessDefinition);

                    if (merged.Activities.Any(a => a.Name.Equals(newName, StringComparison.Ordinal)))
                    {
                        var activityName = inlinedActivity.WasInlined ? inlinedActivity.OriginalName : inlinedActivity.Name;
                        errors.Add($"Activity {activityName} name conflict in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                        continue;
                    }

                    var cloned = inlinedActivity.Clone();

                    if (cloned.DesignerSettings?.InlineElementSettings?.Group == inlinedGroupName)
                    {
                        cloned.DesignerSettings.InlineElementSettings.Group = specificInlinedGroupName;
                    }
                    
                    cloned.Name = newName;
                    if (!cloned.WasInlined)
                    {
                        cloned.DesignerSettings.Group = specificInlinedGroupName;
                        cloned.WasInlined = true;
                        cloned.OriginalName = oldName;
                        cloned.OriginalSchemeCode = inlinedProcessDefinition.Name;
                        cloned.FirstTimeInlineName = pointOfInlining;
                    }
               
                    cloned.LastTimeInlineName = pointOfInlining;

                    //action replace
                    foreach (var implementation in cloned.Implementation.Concat(cloned.PreExecutionImplementation))
                    {
                        if (actionNameConversions.TryGetValue(implementation.ActionName, out string newActionName))
                        {
                            implementation.ActionName = newActionName;
                        }
                    }

                    if (cloned.IsFinal)
                    {
                        finals.Add(cloned);
                    }
                    else if (cloned.IsInitial)
                    {
                        initial = cloned;
                    }

                    allClonedActivities.Add(cloned.Name, cloned);
                    activityNameConversion.Add(oldName, newName);
                    merged.Activities.Add(cloned);
                }
                
                //rename groups and inline groups
                foreach (var mergedActivity in allClonedActivities.Values)
                {
                    var groupName = mergedActivity?.DesignerSettings?.Group;

                    if (!string.IsNullOrEmpty(groupName))
                    {
                        if (activityNameConversion.TryGetValue(groupName, out var newGroupName))
                        {
                            mergedActivity.DesignerSettings.Group = newGroupName;
                        }
                    }

                    var inlineGroupName = mergedActivity?.DesignerSettings?.InlineElementSettings?.Group;
                    
                    if (!string.IsNullOrEmpty(inlineGroupName))
                    {
                        if (activityNameConversion.TryGetValue(inlineGroupName, out var newInlinedGroupName))
                        {
                            mergedActivity.DesignerSettings.InlineElementSettings.Group = newInlinedGroupName;
                        }
                    }
                }

                if (initial == null)
                {
                    errors.Add($"Initial activity in the scheme {inlinedProcessDefinition.Name} is not found");
                    continue;
                }

                if (!finals.Any())
                {
                    errors.Add($"No final activity in scheme {inlinedProcessDefinition.Name}");
                    continue;
                }
                
                //set parent designer settings for initial inlined activity
                var inlineActivity = merged.Activities.FirstOrDefault(a => a.Name.Equals(pointOfInlining, StringComparison.Ordinal));

                if (inlineActivity == null)
                {
                    errors.Add($"Can't found inline activity {pointOfInlining} in scheme {merged.Name}");
                    continue;
                }

                initial.DesignerSettings.InlineElementSettings = inlineActivity.DesignerSettings.Clone();

                initial.DesignerSettings.InlineElementSettings.Group = targetGroupName;
              
                //relink ingoing and outgoing transitions
                //ingoing
                var ingoingTransitions =
                    merged.Transitions.Where(t => t.To.ActivityType == ActivityType.Inline && t.To.Name.Equals(pointOfInlining, StringComparison.Ordinal));
                foreach (var ingoingTransition in ingoingTransitions)
                {
                    //set parent designer settings for initial activity of inlined scheme
                    ingoingTransition.To = initial;
                    //this activity is not initial anymore 
                    initial.IsInitial = false;
                }

                //outgoing
                var outgoingTransitions =
                    merged.Transitions.Where(t => t.From.ActivityType == ActivityType.Inline && t.From.Name.Equals(pointOfInlining, StringComparison.Ordinal));
                foreach (var outgoingTransition in outgoingTransitions)
                {
                    if (!string.IsNullOrEmpty(outgoingTransition.InlinedFinalActivityName))
                    {
                        var final = finals.FirstOrDefault(f => f.OriginalName.Equals(outgoingTransition.InlinedFinalActivityName));
                        if (final == null)
                        {
                            var transitionName = outgoingTransition.WasInlined ? outgoingTransition.OriginalName : outgoingTransition.Name;
                            var schemeName = outgoingTransition.WasInlined ? outgoingTransition.OriginalSchemeCode : merged.Name;
                            errors.Add($"Can't find {outgoingTransition.InlinedFinalActivityName} activity in {inlinedProcessDefinition.Name} scheme. " +
                                       $"This is activity is mentioned in {transitionName} transition from {schemeName} scheme.");
                            continue;
                        }

                        outgoingTransition.From = final;
                        //it is not final activity anymore
                        final.IsFinal = false;
                    }
                    else
                    {
                        var firstFinal = finals.First();
                        outgoingTransition.From = firstFinal;
                        //it is not final activity anymore
                        firstFinal.IsFinal = false;
                    }
                }

                //transitions
                foreach (var inlinedTransition in inlinedProcessDefinition.Transitions)
                {
                    var oldName = inlinedTransition.Name;
                    var newName = inlinedTransition.WasInlined
                        ? $"{pointOfInlining}_{inlinedTransition.Name}"
                        : $"{pointOfInlining}_{inlinedProcessDefinition.Name}_{inlinedTransition.Name}";

                    if (merged.Transitions.Any(a => a.Name.Equals(newName, StringComparison.Ordinal)))
                    {
                        var transitionName = inlinedTransition.WasInlined ? inlinedTransition.OriginalName : inlinedTransition.Name;
                        errors.Add($"Transition {transitionName} name conflict in schemes {merged.Name} and {inlinedProcessDefinition.Name}");
                        continue;
                    }

                    var cloned = inlinedTransition.Clone();

                    cloned.Name = newName;
                    if (!cloned.WasInlined)
                    {
                        cloned.WasInlined = true;
                        cloned.OriginalName = oldName;
                        cloned.OriginalSchemeCode = inlinedProcessDefinition.Name;
                        cloned.FirstTimeInlineName = pointOfInlining;
                    }

                    cloned.LastTimeInlineName = pointOfInlining;

                    //replace from and to
                    var newFromActivity = activityNameConversion[inlinedTransition.From.Name];
                    var newToActivity = activityNameConversion[inlinedTransition.To.Name];
                    cloned.From = allClonedActivities[newFromActivity];
                    cloned.To = allClonedActivities[newToActivity];

                    //replace actors
                    foreach (var restriction in cloned.Restrictions)
                    {
                        if (actorNameConversions.TryGetValue(restriction.Actor.Name, out string newActorName))
                        {
                            restriction.Actor = allActors[newActorName];
                        }
                    }

                    //replace condition
                    foreach (var condition in cloned.Conditions.Where(c => c.Type == ConditionType.Action))
                    {
                        if (conditionNameConversions.TryGetValue(condition.Action.ActionName, out var newConditionName))
                        {
                            condition.Action.ActionName = newConditionName;
                        }
                    }

                    merged.Transitions.Add(cloned);
                }
            }

            //remove inline activities (points of inlining) from scheme
            merged.Activities.RemoveAll(a => pointsOfInlining.Contains(a.Name, StringComparer.Ordinal));

            return merged;
        }

        private static string GetNewActivityName(ActivityDefinition inlinedActivity, string pointOfInlining, ProcessDefinition inlinedProcessDefinition)
        {
            return inlinedActivity.WasInlined ? $"{pointOfInlining}_{inlinedActivity.Name}" : $"{pointOfInlining}_{inlinedProcessDefinition.Name}_{inlinedActivity.Name}";
        }


        private bool TryMergeParameters(ParameterDefinition target, ParameterDefinition source)
        {
            if (target.Type != source.Type)
                return false;
            if (target.InitialValue != null && source.InitialValue != null && !target.InitialValue.Equals(source.InitialValue, StringComparison.Ordinal))
            {
                return false;
            }

            if (target.Purpose == ParameterPurpose.Temporary)
                target.Purpose = source.Purpose;
            if (target.InitialValue == null)
                target.InitialValue = source.InitialValue;
            return true;
        }

        private bool TryMergeTimer(TimerDefinition target, TimerDefinition source)
        {
            //all fields must be same
            if (target.Type != source.Type)
                return false;
            if (target.NotOverrideIfExists != source.NotOverrideIfExists)
                return false;
            if (!target.Value.Equals(source.Value, StringComparison.Ordinal))
                return false;

            return true;
        }
        
        private bool TryMergeLocalization(LocalizeDefinition target, LocalizeDefinition source)
        {
            //all fields must be same
            if (target.IsDefault != source.IsDefault)
                return false;
            if (!target.Value.Equals(source.Value, StringComparison.Ordinal))
                return false;
            return true;
        }

        private bool TryMergeCommand(CommandDefinition target, CommandDefinition source)
        {
            if (!target.InputParameters.Any())
            {
                if (!source.InputParameters.Any())
                    return true;
                foreach (var inputParameter in source.InputParameters)
                {
                    target.InputParameters.Add(inputParameter.Clone());
                }

                return true;
            }

            if (!source.InputParameters.Any())
            {
                return true;
            }

            foreach (var inputParameter in source.InputParameters)
            {
                var existingInputParameter = target.InputParameters.FirstOrDefault(eip => eip.Name.Equals(inputParameter.Name, StringComparison.Ordinal));
                if (existingInputParameter == null)
                {
                    target.InputParameters.Add(inputParameter.Clone());
                }
                else if (!TryMergeCommandInputParameter(existingInputParameter, inputParameter))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryMergeCommandInputParameter(ParameterDefinitionReference target, ParameterDefinitionReference source)
        {
            if (!target.Parameter.Name.Equals(source.Parameter.Name, StringComparison.Ordinal))
                return false;
            
            if (target.DefaultValue != null && source.DefaultValue != null && !target.DefaultValue.Equals(source.DefaultValue))
            {
                return false;
            }

            if (!target.IsRequired)
                target.IsRequired = source.IsRequired;
            if (target.DefaultValue == null)
                target.DefaultValue = source.DefaultValue;
            return true;
        }
    }
}