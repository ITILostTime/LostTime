using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class QuestController : IQuest
    {
        private string _questPNJ;
        private float _questID;
        private string _questName;
        private string _questContext;
        private string _questDescription;
        private bool _questIsComplete;
        private List<ObjectiveController> _questObjectives;
        private int _objectiveID;
        private int _objectiveMax;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestController"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="questName">Name of the quest.</param>
        /// <param name="questDescription">The quest description.</param>
        /// <param name="questIsComplete">if set to <c>true</c> [quest is complete].</param>
        public QuestController(string questPNJ, float questID, string questName, string questContext, string questDescription, 
            bool questIsComplete, int objectiveID, int objectiveMax, List<ObjectiveController> questObjectives)
        {
            QuestPNJ = questPNJ;
            QuestID = questID;
            QuestName = questName;
            QuestContext = questContext;
            QuestDescription = questDescription;
            QuestIsComplete = questIsComplete;
            Objectives = new List<ObjectiveController>();
            Objectives = questObjectives;
            ObjectiveID = objectiveID;
            ObjectiveMax = objectiveMax;
        }

        /// <summary>
        /// Gets or sets the quest title.
        /// </summary>
        /// <value>
        /// The quest title.
        /// </value>
        public string QuestPNJ
        {
            get { return _questPNJ; }
            set { _questPNJ = value; }
        }

        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public float QuestID
        {
            get { return _questID; }
            set { _questID = value; }
        }

        /// <summary>
        /// Gets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        public string QuestName
        {
            get { return _questName; }
            set { _questName = value; }
        }

        /// <summary>
        /// Gets or sets the quest context.
        /// </summary>
        /// <value>
        /// The quest context.
        /// </value>
        public string QuestContext
        {
            get { return _questContext; }
            set { _questContext = value; }
        }

        /// <summary>
        /// Gets the quest description.
        /// </summary>
        /// <value>
        /// The quest description.
        /// </value>
        public string QuestDescription
        {
            get { return _questDescription; }
            set { _questDescription = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool QuestIsComplete
        {
            get { return _questIsComplete; }
            set { _questIsComplete = value; }
        }

        /// <summary>
        /// Gets the objectives of the quest.
        /// </summary>
        /// <value>
        /// The objectives of the quest.
        /// </value>
        public List<ObjectiveController> Objectives
        {
            get { return _questObjectives; }
            set { _questObjectives = value; }
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
        /// Gets or sets the objective maximum.
        /// </summary>
        /// <value>
        /// The objective maximum.
        /// </value>
        public int ObjectiveMax
        {
            get { return _objectiveMax; }
            set { _objectiveMax = value; }
        }
    }
}
