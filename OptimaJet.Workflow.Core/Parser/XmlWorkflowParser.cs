using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Fault;
using OptimaJet.Workflow.Core.Persistence;

namespace OptimaJet.Workflow.Core.Parser
{
    /// <summary>
    /// Base workflow parser, which parses not parsed process scheme serialized to XML to the object model of a scheme of a process <see cref="ProcessDefinition"/>
    /// </summary>
    public class XmlWorkflowParser : WorkflowParser<XElement>
    {
        /// <summary>
        /// Parses timers from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>List of <see cref="TimerDefinition"/> objects</returns>
        public override List<TimerDefinition> ParseTimers(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var timersElement = schemeMedium.SingleOrDefault("Timers");

            if (timersElement == null) return new List<TimerDefinition>();

            return
                timersElement.Elements()
                    .ToList()
                    .Select(
                        element =>
                            TimerDefinition.Create(GetName(element), GetType(element), GetValue(element),
                                GetNotOverrideIfExists(element)))
                    .ToList();
        }

        /// <summary>
        /// Parses actors from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>List of <see cref="ActorDefinition"/> objects</returns>
        public override List<ActorDefinition> ParseActors(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var actorsElement = schemeMedium.SingleOrDefault("Actors");

            if (actorsElement == null) return new List<ActorDefinition>();

            var actors = new List<ActorDefinition>();

            foreach (var element in actorsElement.Elements().ToList())
            {
                var actorDefinition = ActorDefinition.Create(GetName(element), GetRule(element), GetValue(element));
                actorDefinition.OriginalName = GetSingleValue(element,nameof(actorDefinition.OriginalName));
                actorDefinition.OriginalSchemeCode = GetSingleValue(element, nameof(actorDefinition.OriginalSchemeCode));
                actorDefinition.WasInlined = GetSingleBooleanValue(element,nameof(actorDefinition.WasInlined));
                actors.Add(actorDefinition);
            }

            return actors;
        }

        /// <summary>
        /// Parses localization items from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>List of <see cref="LocalizeDefinition"/> objects</returns>
        public override List<LocalizeDefinition> ParseLocalization(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");

            var localizationElement = schemeMedium.SingleOrDefault("Localization");

            var localization = new List<LocalizeDefinition>();

            if (localizationElement == null) return localization;

            foreach (var element in localizationElement.Elements().ToList())
            {
                var localizeDefinition = LocalizeDefinition.Create(GetObjectName(element), GetType(element),
                    GetCulture(element),
                    GetValue(element), GetIsDefault(element));


                localization.Add(localizeDefinition);
            }

            return localization;
        }

        /// <summary>
        /// Parses parameters from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <param name="schemeParsingType">Type of parsing strict or soft. Uses only for upload operations where we need softer scheme check</param>
        /// <returns>List of <see cref="ParameterDefinition"/> objects</returns>
        public override List<ParameterDefinition> ParseParameters(XElement schemeMedium,  SchemeParsingType schemeParsingType = SchemeParsingType.Strict)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            var parametersElement = schemeMedium.SingleOrDefault("Parameters");

            var parameters = new List<ParameterDefinition>();

            if (parametersElement != null)
            {
                foreach (var element in parametersElement.Elements().ToList())
                {
                    ParameterDefinition parameterDefinition;
                    if (element.Attributes("Purpose").Count() == 1)
                    {
                        parameterDefinition = ParameterDefinition.Create(GetName(element),
                            element.Attributes("Type").Single().Value,
                            element.Attributes("Purpose").Single().Value, GetInitialValue(element), schemeParsingType == SchemeParsingType.Soft);
                    }
                    else
                    {
                        parameterDefinition = ParameterDefinition.Create(GetName(element),
                            element.Attributes("Type").Single().Value, GetInitialValue(element), schemeParsingType == SchemeParsingType.Soft);
                    }

                    parameters.Add(parameterDefinition);
                }
            }

            parameters.AddRange(DefaultDefinitions.DefaultParameters);

            return parameters;
        }

        /// <summary>
        /// Parses commands from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <param name="parameterDefinitions">List of parsed parameters <see cref="ParameterDefinition"/></param>
        /// <returns>List of <see cref="CommandDefinition"/> objects</returns>
        public override List<CommandDefinition> ParseCommands(XElement schemeMedium,
            List<ParameterDefinition> parameterDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (parameterDefinitions == null) throw new ArgumentNullException("parameterDefinitions");
            var commandsElement = schemeMedium.SingleOrDefault("Commands");


            var commands = new List<CommandDefinition>();
            if (commandsElement == null) return commands;

            var parameterDefinitionsList = parameterDefinitions.ToList();


            foreach (var element in commandsElement.Elements().ToList())
            {
                var command = CommandDefinition.Create(GetName(element));
                var el = element.Elements("InputParameters").SingleOrDefault();
                if (el != null)
                {
                    foreach (var xmlInputParameter in el.Elements())
                    {
                        var parameterRef =
                            parameterDefinitionsList.FirstOrDefault(pd => pd.Name == GetNameRef(xmlInputParameter));
                        if (parameterRef == null)
                        {
                            throw new SchemeNotValidException(string.Format("Command {0}: parameter '{1}' not found",
                                command.Name, GetNameRef(xmlInputParameter)));
                        }
                        command.AddParameterRef(GetName(xmlInputParameter), GetIsRequired(xmlInputParameter), GetDefaultValue(xmlInputParameter), parameterRef);
                    }
                }

                commands.Add(command);
            }

            return commands;
        }

        /// <summary>
        /// Parses activities from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>List of <see cref="ActivityDefinition"/> objects</returns>
        public override List<ActivityDefinition> ParseActivities(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            var activitiesElements = schemeMedium.SingleOrDefault("Activities");
            if (activitiesElements == null) throw new ArgumentNullException("");

            var activities = new List<ActivityDefinition>();

            foreach (var element in activitiesElements.Elements().ToList())
            {
                ActivityDefinition activity;
                if (element.Name == "Inline")
                {
                    activity = ActivityDefinition.CreateInlineActivity(GetName(element), GetSingleValue(element, nameof(activity.SchemeCode)));
                    activity.DesignerSettings = GetDesignerSettings(element);
                }
                else
                {
                    activity = ActivityDefinition.Create(GetName(element), GetState(element), GetIsInitial(element),
                        GetIsFinal(element), GetIsForSetState(element), GetIsAutoSchemeUpdate(element));

                    activity.OriginalName = GetSingleValue(element,nameof(activity.OriginalName));
                    activity.OriginalSchemeCode = GetSingleValue(element, nameof(activity.OriginalSchemeCode));
                    activity.WasInlined = GetSingleBooleanValue(element,nameof(activity.WasInlined));
                    activity.LastTimeInlineName = GetSingleValue(element, nameof(activity.LastTimeInlineName));
                    activity.FirstTimeInlineName = GetSingleValue(element, nameof(activity.FirstTimeInlineName));
                    
                    activity.DesignerSettings = GetDesignerSettings(element);
                    activity.Annotations = GetAnnotations(element);

                    var implementation = element.Elements("Implementation").ToList();

                    if (implementation.Any())
                        foreach (var xmlOutputParameter in implementation.Single().Elements())
                        {
                            string nameRef = GetNameRef(xmlOutputParameter);
                            activity.AddAction(ActionDefinitionReference.Create(nameRef, GetOrder(xmlOutputParameter),
                                GetParameter(xmlOutputParameter)));
                        }

                    var preExecutionImplementation = element.Elements("PreExecutionImplementation").ToList();

                    if (preExecutionImplementation.Any())
                        foreach (var xmlOutputParameter in preExecutionImplementation.Single().Elements())
                        {
                            string nameRef = GetNameRef(xmlOutputParameter);
                            activity.AddPreExecutionAction(ActionDefinitionReference.Create(nameRef,
                                GetOrder(xmlOutputParameter), GetParameter(xmlOutputParameter)));
                        }
                }
                
                activities.Add(activity);
            }

            return activities;
        }

        /// <summary>
        /// Parses code actions from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>List of <see cref="CodeActionDefinition"/> objects</returns>
        public override List<CodeActionDefinition> ParseCodeActions(XElement schemeMedium)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            var codeActionsElement = schemeMedium.SingleOrDefault("CodeActions");
            return codeActionsElement == null
                ? new List<CodeActionDefinition>()
                : codeActionsElement.Elements()
                    .Select(
                        element =>
                        {
                            var actionCode = GetActionCode(element);
                            var usings = GetUsings(element);
                            var parameters = GetCodeActionParameters(element);
                            var codeAction = CodeActionDefinition.Create(GetName(element), usings, actionCode, GetIsGlobal(element), 
                                GetType(element), GetIsAsync(element), parameters);
                            codeAction.OriginalName = GetSingleValue(element,nameof(codeAction.OriginalName));
                            codeAction.OriginalSchemeCode = GetSingleValue(element, nameof(codeAction.OriginalSchemeCode));
                            codeAction.WasInlined = GetSingleBooleanValue(element,nameof(codeAction.WasInlined));
                            return codeAction;
                        })
                    .Where(ac => !string.IsNullOrEmpty(ac.ActionCode))
                    .ToList();
        }

        /// <summary>
        /// Parses transitions from not parsed scheme in theirs object model
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <param name="actorDefinitions">List of parsed actors <see cref="ActorDefinition"/></param>
        /// <param name="commandDefinitions">List of parsed commands <see cref="CommandDefinition"/></param>
        /// <param name="activityDefinitions">List of parsed activities <see cref="ActivityDefinition"/></param>
        /// <param name="timerDefinitions">List of parsed timers <see cref="TimerDefinition"/></param>
        /// <returns>List of <see cref="TransitionDefinition"/> objects</returns>
        public override List<TransitionDefinition> ParseTransitions(XElement schemeMedium,
            List<ActorDefinition> actorDefinitions, List<CommandDefinition> commandDefinitions,
            List<ActivityDefinition> activityDefinitions, List<TimerDefinition> timerDefinitions)
        {
            if (schemeMedium == null) throw new ArgumentNullException("schemeMedium");
            if (commandDefinitions == null) throw new ArgumentNullException("commandDefinitions");
            if (activityDefinitions == null) throw new ArgumentNullException("activityDefinitions");
            var transitionElements = schemeMedium.SingleOrDefault("Transitions");

            var transitions = new List<TransitionDefinition>();
            if (transitionElements == null) return transitions;

            var commandDefinitionsList = commandDefinitions.ToList();
            var activityDefinitionsList = activityDefinitions.ToList();
            var actorDefinitionsList = actorDefinitions.ToList();
            var timerDefinitionsList = timerDefinitions.ToList();


            foreach (var transitionElement in transitionElements.Elements().ToList())
            {
                var fromActivity = activityDefinitionsList.Single(ad => ad.Name == GetFrom(transitionElement));
                var toActivity = activityDefinitionsList.Single(ad => ad.Name == GetTo(transitionElement));

                TriggerDefinition trigger = null;
                var triggersElement = transitionElement.Element("Triggers");
                var triggerElement = triggersElement?.Element("Trigger");
                if (triggerElement != null)
                {
                    trigger = TriggerDefinition.Create(GetType(triggerElement));

                    var nameRef = GetNameRef(triggerElement);
                    if (nameRef != null)
                    {
                        if (trigger.Type == TriggerType.Command)
                        {
                            trigger.Command =
                                commandDefinitionsList.SingleOrDefault(cd => cd.Name == nameRef);
                        }
                        else if (trigger.Type == TriggerType.Timer)
                        {
                            trigger.Timer =
                                timerDefinitionsList.SingleOrDefault(cd => cd.Name == nameRef);
                        }
                    }
                }

                var conditions = new List<ConditionDefinition>();
                var conditionsElement = transitionElement.Element("Conditions");
                if (conditionsElement != null)
                {
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (var conditionElement in conditionsElement.Elements("Condition"))
                    {
                        var condition = !string.IsNullOrEmpty(GetNameRef(conditionElement))
                            ? ConditionDefinition.Create(GetType(conditionElement),
                                ActionDefinitionReference.Create(GetNameRef(conditionElement), "0",
                                    GetParameter(conditionElement)),
                                GetConditionInversion(conditionElement),
                                GetResultOnPreExecution(conditionElement))
                            : ConditionDefinition.Create(GetType(conditionElement),
                                GetResultOnPreExecution(conditionElement));
                        conditions.Add(condition);
                    }
                }

                var transition = TransitionDefinition.Create(GetName(transitionElement),
                    GetClassifier(transitionElement), GetAllowRestrictionsConcatenationType(transitionElement),
                    GetDenyRestrictionsConcatenationType(transitionElement),
                    GetConditionsConcatenationType(transitionElement), GetIsFork(transitionElement),
                    GetMergeViaSetState(transitionElement), GetDisableParentStateControl(transitionElement),
                    fromActivity,
                    toActivity, trigger, conditions);
                
                transition.InlinedFinalActivityName = GetSingleValue(transitionElement,nameof(transition.InlinedFinalActivityName));
                transition.OriginalName = GetSingleValue(transitionElement,nameof(transition.OriginalName));
                transition.OriginalSchemeCode = GetSingleValue(transitionElement, nameof(transition.OriginalSchemeCode));
                transition.WasInlined = GetSingleBooleanValue(transitionElement,nameof(transition.WasInlined));
                transition.LastTimeInlineName = GetSingleValue(transitionElement, nameof(transition.LastTimeInlineName));
                transition.FirstTimeInlineName = GetSingleValue(transitionElement, nameof(transition.FirstTimeInlineName));
                
                transition.DesignerSettings = GetDesignerSettings(transitionElement);
                transition.Annotations = GetAnnotations(transitionElement);

                var restrictionsElement = transitionElement.Element("Restrictions");
                if (restrictionsElement != null)
                {
                    foreach (var element in restrictionsElement.Elements("Restriction"))
                    {
                        var item = actorDefinitionsList.FirstOrDefault(ad => ad.Name == GetNameRef(element));
                        if (item == null)
                        {
                            throw new SchemeNotValidException(string.Format("Actor {0} not found", GetNameRef(element)));
                        }
                        transition.AddRestriction(RestrictionDefinition.Create(GetType(element),
                            actorDefinitionsList.Single(ad => ad.Name == GetNameRef(element))));
                    }
                }

                transitions.Add(transition);
            }


            return transitions;
        }

        /// <summary>
        /// Gets the code of the scheme from not parsed scheme 
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>Code of the scheme</returns>
        public override string GetSchemeCode(XElement schemeMedium)
        {
            return GetName(schemeMedium);
        }

        public override bool GetCanBeInlined(XElement schemeMedium)
        {
            return GetSingleBooleanValue(schemeMedium, nameof(ProcessDefinition.CanBeInlined));
        }

        /// <summary>
        /// Gets designer settings from not parsed scheme 
        /// </summary>
        /// <param name="schemeMedium">Not parsed scheme</param>
        /// <returns>Designer settings</returns>
        public override DesignerSettings GetDesignerSettings(XElement schemeMedium)
        {
            var designerElement = schemeMedium.Element("Designer");
            var inlineDesignerElement = schemeMedium.Element("InlineDesigner");
            if (designerElement == null && inlineDesignerElement == null)
                return DesignerSettings.Empty;

            var designerSettings = new DesignerSettings();

            if (designerElement != null)
            {
                designerSettings.X = GetSingleValue(designerElement, "X");
                designerSettings.Y = GetSingleValue(designerElement, "Y");
                designerSettings.Bending = GetSingleValue(designerElement, "Bending");
                designerSettings.Group = GetSingleValue(designerElement, "Group");
            }

            if (inlineDesignerElement != null)
            {
                designerSettings.InlineElementSettings = new DesignerSettings
                {
                    X = GetSingleValue(inlineDesignerElement, "X"),
                    Y = GetSingleValue(inlineDesignerElement, "Y"),
                    Bending = GetSingleValue(inlineDesignerElement, "Bending"),
                    Group = GetSingleValue(inlineDesignerElement, "Group")
                };
            }


            return designerSettings;
        }

        private static string GetName(XElement element)
        {
            return GetSingleValue(element, "Name");
        }
        
        private static string GetValue(XElement element)
        {
            return GetSingleValue(element, "Value");
        }

        private static string GetRule(XElement element)
        {
            return GetSingleValue(element, "Rule");
        }

        private static string GetParameter(XElement element)
        {
            var firstOrDefault = element.Elements("ActionParameter").FirstOrDefault();
            if (firstOrDefault != null)
                return firstOrDefault.Value;
            return null;
        }

        private static string GetOrder(XElement element)
        {
            return GetSingleValue(element, "Order");
        }

        private static string GetType(XElement element)
        {
            return GetSingleValue(element, "Type");
        }

        private static string GetNotOverrideIfExists(XElement element)
        {
            return GetSingleValue(element, "NotOverrideIfExists");
        }

        private static string GetNameRef(XElement element)
        {
            return GetSingleValue(element, "NameRef");
        }

        private static string GetConditionInversion(XElement element)
        {
            return GetSingleValue(element, "ConditionInversion");
        }

        private static string GetDefaultValue(XElement element)
        {
            return GetSingleValue(element, "DefaultValue");
        }

        private static string GetInitialValue(XElement element)
        {
            return GetSingleValue(element, "InitialValue");
        }

        private static string GetResultOnPreExecution(XElement element)
        {
            return GetSingleValue(element, "ResultOnPreExecution");
        }

        private static string GetFrom(XElement element)
        {
            return GetSingleValue(element, "From");
        }

        private static string GetTo(XElement element)
        {
            return GetSingleValue(element, "To");
        }

        private static string GetIsFinal(XElement element)
        {
            return GetSingleValue(element, "IsFinal");
        }

        private static string GetIsForSetState(XElement element)
        {
            return GetSingleValue(element, "IsForSetState");
        }

        private static string GetIsAutoSchemeUpdate(XElement element)
        {
            return GetSingleValue(element, "IsAutoSchemeUpdate");
        }


        private static string GetIsGlobal(XElement element)
        {
            return GetSingleValue(element, "IsGlobal");
        }

        private static string GetIsAsync(XElement element)
        {
            return GetSingleValue(element, "IsAsync");
        }

        private static string GetUsings(XElement element)
        {
            var firstOrDefault = element.Elements("Usings").FirstOrDefault();
            if (firstOrDefault != null)
                return firstOrDefault.Value;
            return null;
        }

        private List<CodeActionParameterDefinition> GetCodeActionParameters(XElement element)
        {
            var parametersElement =  element.Element("Parameters");

            if (parametersElement == null) return new List<CodeActionParameterDefinition>();

            return parametersElement.Elements().Select(x => new CodeActionParameterDefinition
            {
                Name = x.Attribute("name").Value,
                Type = (ParameterType)Enum.Parse(typeof(ParameterType), x.Attribute("type").Value, true),
                IsRequired = x.Attribute("isRequired") != null ? bool.Parse(x.Attribute("isRequired").Value) : false,
                DefaultValue = x.Element("DefaultValue")?.Value,
                DropdownValues = x.Elements("DropdownValue").Select(v => new DropdownValue()
                {
                    Name = v.Attribute("name").Value,
                    Value = v.Attribute("value").Value
                }).ToList()
            }).ToList();
        }

        private static string GetActionCode(XElement element)
        {
            var firstOrDefault = element.Elements("ActionCode").FirstOrDefault();
            if (firstOrDefault != null)
                return firstOrDefault.Value;
            return null;
        }

        private static string GetIsInitial(XElement element)
        {
            return GetSingleValue(element, "IsInitial");
        }

        private static string GetClassifier(XElement element)
        {
            return GetSingleValue(element, "Classifier");
        }

        private static string GetIsFork(XElement element)
        {
            return GetSingleValue(element, "IsFork");
        }

        private static string GetMergeViaSetState(XElement element)
        {
            return GetSingleValue(element, "MergeViaSetState");
        }

        private static string GetDisableParentStateControl(XElement element)
        {
            return GetSingleValue(element, "DisableParentStateControl");
        }

        private static string GetAllowRestrictionsConcatenationType(XElement element)
        {
            return GetSingleValue(element, "AllowConcatenationType");
        }

        private static string GetDenyRestrictionsConcatenationType(XElement element)
        {
            return GetSingleValue(element, "RestrictConcatenationType");
        }

        private static string GetConditionsConcatenationType(XElement element)
        {
            return GetSingleValue(element, "ConditionsConcatenationType");
        }

        private static string GetState(XElement element)
        {
            return GetSingleValue(element, "State");
        }

        private static string GetObjectName(XElement element)
        {
            return GetSingleValue(element, "ObjectName");
        }

        private static string GetCulture(XElement element)
        {
            return GetSingleValue(element, "Culture");
        }

        private static string GetIsDefault(XElement element)
        {
            return GetSingleValue(element, "IsDefault");
        }

        private static bool GetIsRequired(XElement element)
        {
            var value = GetSingleValue(element, "IsRequired");
            bool.TryParse(value, out bool result);
            return result;
        }

        private static List<Annotation> GetAnnotations(XElement element)
        {
            var annotationsElement = element.Element("Annotations");

            if (annotationsElement == null) return new List<Annotation>();

            return annotationsElement.Elements()
                .Select(a => new Annotation { Name = a.Attribute("Name").Value, JsonValue = a.Value })
                .ToList();
        }

        private static string GetSingleValue(XElement el, string attName)
        {
            var a = el.Attributes(attName).SingleOrDefault();
            return a?.Value;
        }
        
        private static bool GetSingleBooleanValue(XElement el, string attName)
        {
            var a = el.Attributes(attName).SingleOrDefault();
            bool.TryParse(a?.Value, out bool result);
            return result;
        }

        /// <summary>
        /// Returns object model of the scheme of a process
        /// </summary>
        /// <param name="scheme">String representation of not parsed sheme</param>
        /// <returns>ProcessDefinition object</returns>
        public override ProcessDefinition Parse(string scheme, SchemeParsingType schemeParsingType = SchemeParsingType.Strict)
        {
            return Parse(XElement.Parse(scheme), schemeParsingType);
        }

        public override XElement SerializeToSchemeMedium(ProcessDefinition processDefinition)
        {
            return processDefinition.SerializeToXElement();
        }

        public override List<string> GetSchemeTags(XElement schemeMedium)
        {
            XAttribute attr = schemeMedium.Attributes(nameof(ProcessDefinition.Tags)).SingleOrDefault();
            if (attr?.Value == null)
            {
                return new List<string>();
            }
            string tagsStr = attr.Value;
            return TagHelper.FromTagString(tagsStr);
        }
    }
}
