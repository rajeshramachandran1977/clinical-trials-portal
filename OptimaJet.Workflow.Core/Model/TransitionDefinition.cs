using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OptimaJet.Workflow.Core.Fault;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Conditions and restrictions concatenation type
    /// </summary>
    public enum ConcatenationType
    {
        /// <summary>
        /// Concatenate as And
        /// </summary>
        And,
        /// <summary>
        /// Concatenate as Or
        /// </summary>
        Or
    }

    /// <summary>
    ///  Represent a transition in a process scheme
    /// </summary>
    public class TransitionDefinition : BaseDefinition
    {
        /// <summary>
        /// Final activity name in inlined scheme, may not be filled, then any final activity from inlined scheme will be taken
        /// </summary>
        public string InlinedFinalActivityName { get; set; } 
        /// <summary>
        /// If object was inlined, you can get its original name from this property
        /// </summary>
        public string OriginalName { get; set; }
        /// <summary>
        /// The code of the scheme to which the inlined object originally belonged.
        /// </summary>
        public string OriginalSchemeCode { get; set; }
        /// <summary>
        /// The name of the inline activity instead of which the object was inlined.last time
        /// </summary>
        public string LastTimeInlineName { get; set; }
        /// <summary>
        /// The name of the inline activity instead of which the object was inlined first time.
        /// </summary>
        public string FirstTimeInlineName { get; set; }
        /// <summary>
        /// Return true if the object was inlined.
        /// </summary>
        public bool WasInlined { get; set; }
        /// <summary>
        /// Source activity
        /// </summary>
        public ActivityDefinition From { get; set; }
        /// <summary>
        /// Destination activity
        /// </summary>
        public ActivityDefinition To { get; set; }
        /// <summary>
        /// Classifier of the direction of the transition
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransitionClassifier Classifier { get; set; }
        /// <summary>
        /// Transition's trigger
        /// </summary>
        public TriggerDefinition Trigger { get; set; }
        /// <summary>
        /// List of conditions which are checked to execute transition
        /// </summary>
        public List<ConditionDefinition> Conditions { get; set; }
        /// <summary>
        /// List of actors which are determine a user which can execute transition
        /// </summary>
        public List<RestrictionDefinition> Restrictions { get; set; }
        /// <summary>
        /// Type of concatenation for restrictions with the type equal "Allow" <see cref="RestrictionType.Allow"/> <seealso cref="RestrictionDefinition.Type"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ConcatenationType AllowConcatenationType { get; set; }
        /// <summary>
        /// Type of concatenation for restrictions with the type equal "Restrict" <see cref="RestrictionType.Restrict"/> <seealso cref="RestrictionDefinition.Type"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ConcatenationType RestrictConcatenationType { get; set; }
        /// <summary>
        /// Type of concatenation for conditions
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ConcatenationType ConditionsConcatenationType { get; set; }

        /// <summary>
        /// A List of <see cref="Annotation"/> attached to this transition.
        /// </summary>
        public List<Annotation> Annotations { get; set; }

        /// <summary>
        /// Create TransitionDefinition object
        /// </summary>
        /// <param name="name">Name of the transition</param>
        /// <param name="clasifier">Classifier of the direction of the transition</param>
        /// <param name="allowRestrictionsConcatenationType">Type of concatenation for restrictions with the type equal "Allow" <see cref="RestrictionType.Allow"/> <seealso cref="RestrictionDefinition.Type"/></param>
        /// <param name="denyRestrictionsConcatenationType">Type of concatenation for restrictions with the type equal "Restrict" <see cref="RestrictionType.Restrict"/> <seealso cref="RestrictionDefinition.Type"/></param>
        /// <param name="conditionsConcatenationType">Type of concatenation for conditions</param>
        /// <param name="mergeViaSetState">Returns true if after a subprocess will be merged with a parent process new state of a parent process will be set forcibly</param>
        /// <param name="disableParentStateControl"> Applied if transition is fork. False - mean that subprocess will be dropped if parent process turned up in a state where subprocess can not exist.
        /// True - mean that subprocess control is responsibility of a developer.</param>
        /// <param name="from">Source activity</param>
        /// <param name="to">Destination activity</param>
        /// <param name="trigger">Transition's trigger</param>
        /// <param name="conditions">List of conditions which are checked to execute transition</param>
        /// <param name="isFork">True if Transition initialized or finalized a fork (split, parallel branch). Fork transition is the initial or final transition of a subprocess</param>
        /// <returns>TransitionDefinition object</returns>
        public static TransitionDefinition Create(string name, string clasifier,
            string allowRestrictionsConcatenationType, string denyRestrictionsConcatenationType,
            string conditionsConcatenationType, string isFork, string mergeViaSetState, string disableParentStateControl, ActivityDefinition from,
            ActivityDefinition to,
            TriggerDefinition trigger, List<ConditionDefinition> conditions)
        {
            Enum.TryParse(clasifier, true, out TransitionClassifier parsedClassifier);
            return new TransitionDefinition()
            {
                Name = name,
                To = to,
                From = from,
                Classifier = parsedClassifier,
                Conditions = conditions ?? new List<ConditionDefinition> {ConditionDefinition.Always},
                Trigger = trigger ?? TriggerDefinition.Auto,
                Restrictions = new List<RestrictionDefinition>(),
                IsFork = !string.IsNullOrEmpty(isFork) && bool.Parse(isFork),
                MergeViaSetState = !string.IsNullOrEmpty(mergeViaSetState) && bool.Parse(mergeViaSetState),
                DisableParentStateControl = !string.IsNullOrEmpty(disableParentStateControl) && bool.Parse(disableParentStateControl),
                Annotations = new List<Annotation>(),
                AllowConcatenationType =
                    string.IsNullOrEmpty(allowRestrictionsConcatenationType)
                        ? ConcatenationType.And
                        : (ConcatenationType)
                            Enum.Parse(typeof (ConcatenationType), allowRestrictionsConcatenationType, true),
                RestrictConcatenationType =
                    string.IsNullOrEmpty(denyRestrictionsConcatenationType)
                        ? ConcatenationType.And
                        : (ConcatenationType)
                            Enum.Parse(typeof (ConcatenationType), denyRestrictionsConcatenationType, true),
                ConditionsConcatenationType =
                    string.IsNullOrEmpty(conditionsConcatenationType)
                        ? ConcatenationType.And
                        : (ConcatenationType) Enum.Parse(typeof (ConcatenationType), conditionsConcatenationType, true),
            };
        }

        /// <summary>
        /// Create TransitionDefinition object with NotSpecified classifier, Always condition, Auto trigger
        /// </summary>
        /// <param name="from">Source activity</param>
        /// <param name="to">Destination activity</param>
        /// <returns>TransitionDefinition object</returns>
        public static TransitionDefinition Create(ActivityDefinition from, ActivityDefinition to)
        {
            return new TransitionDefinition()
            {
                Name = "Undefined",
                To = to,
                From = from,
                Classifier = TransitionClassifier.NotSpecified,
                Conditions = new List<ConditionDefinition>{ConditionDefinition.Always},
                Trigger = TriggerDefinition.Auto,
                Restrictions = new List<RestrictionDefinition>(),
                ConditionsConcatenationType = ConcatenationType.And,
                AllowConcatenationType = ConcatenationType.And,
                RestrictConcatenationType = ConcatenationType.And,
                Annotations = new List<Annotation>()
            };
        }

        /// <summary>
        /// Add restriction to restrictions list
        /// </summary>
        /// <param name="restriction">RestrictionDefinition object</param>
        public void AddRestriction (RestrictionDefinition restriction)
        {
            Restrictions.Add(restriction);
        }

        
        /// <summary>
        /// Returns true if condition type of the transition is equal "Always" <see cref="ConditionType.Always"/>
        /// </summary>
        public bool IsAlwaysTransition
        {
            get { return Conditions.Any(c => c.Type == ConditionType.Always); }
        }

        /// <summary>
        /// Returns true if condition type of the transition is equal "Otherwise" <see cref="ConditionType.Otherwise"/>
        /// </summary>
        public bool IsOtherwiseTransition
        {
            get { return Conditions.Any(c => c.Type == ConditionType.Otherwise); }
        }

        /// <summary>
        /// Returns true if condition type of the transition is equal "Action" <see cref="ConditionType.Action"/>
        /// </summary>
        public bool IsConditionTransition
        {
            get { return Conditions.All(c => c.Type == ConditionType.Action); }
        }

        /// <summary>
        /// Returns true if Transition initialized or finalized a fork (split, parallel branch). Fork transition is the initial or final transition of a subprocess
        /// </summary>
        public bool IsFork { get; set; }
        
        /// <summary>
        /// Returns true if after a subprocess will be merged with a parent process new state of a parent process will be set forcibly
        /// </summary>
        public bool MergeViaSetState { get; set; }

        /// <summary>
        /// Applied if transition is fork. False - mean that subprocess will be dropped if parent process turned up in a state where subprocess can not exist.
        /// True - mean that subprocess control is responsibility of a developer.
        /// </summary>
        public bool DisableParentStateControl { get; set; }

        /// <summary>
        /// Returns type of fork transition <see cref="TransitionForkType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransitionForkType ForkType
        {
            get
            {
                if (!IsFork)
                    return TransitionForkType.NotFork;
                if (!From.NestingLevel.HasValue || !To.NestingLevel.HasValue)
                    return TransitionForkType.ForkUnknown;
                if (From.NestingLevel.Value == To.NestingLevel.Value)
                    throw new WrongSubprocessMarkupException(this,
                        "From and To activities of virtual transition can not have equal nesting levels.");
                if (From.NestingLevel.Value < To.NestingLevel.Value)
                    return TransitionForkType.ForkStart;
                if (From.NestingLevel.Value > To.NestingLevel.Value)
                    return TransitionForkType.ForkEnd;

                return TransitionForkType.ForkUnknown;
            }
        }

        public new TransitionDefinition Clone()
        {
            var newObject = MemberwiseClone() as TransitionDefinition;

            if (newObject == null)
                throw new Exception("Error cloning TransitionDefinition object");

            if (From != null)
                newObject.From = From.Clone();

            if (To != null)
                newObject.To = To.Clone();

            if (Trigger != null)
                newObject.Trigger = Trigger.Clone();

            newObject.Conditions = new List<ConditionDefinition>();

            Conditions.ForEach(c => newObject.Conditions.Add(c.Clone()));

            newObject.Restrictions = new List<RestrictionDefinition>();

            Restrictions.ForEach(c => newObject.Restrictions.Add(c.Clone()));

            newObject.Annotations = new List<Annotation>();
            Annotations.ForEach(a => newObject.Annotations.Add(a.Clone()));

            return newObject;
        }

        /// <summary>
        /// Clones TransitionDefinition object replacing references to the references to the specific objects
        /// </summary>
        /// <param name="actorDefinitions">List of the actors to replace</param>
        /// <param name="commandDefinitions">List of the commands to replace</param>
        /// <param name="activityDefinitions">List of the activities to replace</param>
        /// <param name="timerDefinitions">List of the timers to replace</param>
        /// <returns>Cloned TransitionDefinition object</returns>
        public TransitionDefinition Clone(List<ActorDefinition> actorDefinitions, List<CommandDefinition> commandDefinitions, List<ActivityDefinition> activityDefinitions, List<TimerDefinition> timerDefinitions)
        {
            var newObject = MemberwiseClone() as TransitionDefinition;

            if (newObject == null)
                throw new Exception("Error cloning TransitionDefinition object");

            if (From != null)
            {
                newObject.From =
                    activityDefinitions.First(a => a.Name.Equals(From.Name, StringComparison.Ordinal));
            }

            if (To != null)
            {
                newObject.To =
                    activityDefinitions.First(a => a.Name.Equals(To.Name, StringComparison.Ordinal));
            }

            if (Trigger != null)
                newObject.Trigger = Trigger.Clone(commandDefinitions, timerDefinitions);

            newObject.Conditions = new List<ConditionDefinition>();

            Conditions?.ForEach(c => newObject.Conditions.Add(c.Clone()));

            newObject.Restrictions = new List<RestrictionDefinition>();

            Restrictions?.ForEach(r => newObject.Restrictions.Add(r.Clone(actorDefinitions)));

            return newObject;

        }

        #region Annotations

        /// <summary>
        /// Get an annotation attached to this transition
        /// </summary>
        /// <typeparam name="T">Annotation's type</typeparam>
        /// <param name="name">Annotation's name</param>
        /// <returns>Annotation value</returns>
        public T GetAnnotation<T>(string name)
        {
            return JsonConvert.DeserializeObject<T>(GetAnnotation(name));
        }

        /// <summary>
        /// Get a JSON representation of annotation's value
        /// </summary>
        /// <param name="name">Annotation's name</param>
        /// <returns>JSON representation of annotation's value</returns>
        public string GetAnnotation(string name)
        {
            return Annotations.FirstOrDefault(x => x.Name == name)?.JsonValue;
        }

        #endregion // Annotations
    }
}
