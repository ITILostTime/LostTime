using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace Assets.Scripts.Quest
{
    public class ObjectiveController : IQuestObjective
    {
        private int _questID;
        private int _objectiveID;
        private string _objectiveName;
        private string _objectiveDescription;
        private bool _objectiveIsComplete;
        private string _objectiveContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveController"/> class.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="typeCollect">The type collect.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, bool objectiveIsComplete, string objectiveContext)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            ObjectiveContext = objectiveContext;
            ObjectiveIsComplete = objectiveIsComplete;
        }

        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestID
        {
            get { return _questID; }
        }

        /// <summary>
        /// Gets or sets the objective identifier.
        /// </summary>
        /// <value>
        /// The objective identifier.
        /// </value>
        public int ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        /// <summary>
        /// Gets or sets the name of the objective.
        /// </summary>
        /// <value>
        /// The name of the objective.
        /// </value>
        public string ObjectiveName
        {
            get { return _objectiveName; }
            set { _objectiveName = value; }
        }

        /// <summary>
        /// Gets or sets the objective description.
        /// </summary>
        /// <value>
        /// The objective description.
        /// </value>
        public string ObjectiveDescription
        {
            get { return _objectiveDescription; }
            set { _objectiveDescription = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this objective is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this objective is complete; otherwise, <c>false</c>.
        /// </value>
        public bool ObjectiveIsComplete
        {
            get { return _objectiveIsComplete; }
            set { _objectiveIsComplete = value; }
        }

        public string ObjectiveContext
        {
            get { return _objectiveContext; }
            set { _objectiveContext = value; }
        }
    }
}
