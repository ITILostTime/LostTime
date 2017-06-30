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
        private string _objectiveType;
        private int _amount;
        private int _goalAmount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveController"/> class.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="objectiveIsComplete">if set to <c>true</c> [objective is complete].</param>
        /// <param name="objectiveContext">The objective context.</param>
        /// <param name="objectiveType">Type of the objective.</param>
        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, bool objectiveIsComplete, string objectiveContext, string objectiveType)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            ObjectiveContext = objectiveContext;
            ObjectiveIsComplete = objectiveIsComplete;
            ObjectiveType = objectiveType;
        }

        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, bool objectiveIsComplete, string objectiveContext, string objectiveType, int goalAmount)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            ObjectiveContext = objectiveContext;
            ObjectiveIsComplete = objectiveIsComplete;
            ObjectiveType = objectiveType;
            GoalAmount = goalAmount;
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

        /// <summary>
        /// Gets or sets the objective context.
        /// </summary>
        /// <value>
        /// The objective context.
        /// </value>
        public string ObjectiveContext
        {
            get { return _objectiveContext; }
            set { _objectiveContext = value; }
        }

        /// <summary>
        /// Gets or sets the type of the objective.
        /// </summary>
        /// <value>
        /// The type of the objective.
        /// </value>
        public string ObjectiveType
        {
            get { return _objectiveType; }
            set { _objectiveType = value; }
        }

        /// <summary>
        /// Gets or sets the goal amount.
        /// </summary>
        /// <value>
        /// The goal amount.
        /// </value>
        public int GoalAmount
        {
            get { return _goalAmount; }
            set { _goalAmount = value; }
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
