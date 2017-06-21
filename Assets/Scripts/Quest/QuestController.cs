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
        private int _questID;
        private string _questName;
        private string _questContext;
        private string _questDescription;
        private bool _questIsComplete;
        private List<IQuestObjective> _questObjectives;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestController"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="questName">Name of the quest.</param>
        /// <param name="questDescription">The quest description.</param>
        /// <param name="questIsComplete">if set to <c>true</c> [quest is complete].</param>
        public QuestController(string questPNJ, int questID, string questName, string questContext, string questDescription, 
            bool questIsComplete)
        {
            QuestPNJ = questPNJ;
            QuestID = questID;
            QuestName = questName;
            QuestContext = questContext;
            QuestDescription = questDescription;
            QuestIsComplete = questIsComplete;
            Objectives = new List<IQuestObjective>();
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
        public int QuestID
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
        public List<IQuestObjective> Objectives
        {
            get { return _questObjectives; }
            set { _questObjectives = value; }
        }

        /// <summary>
        /// Checks the progress.
        /// </summary>
        public void CheckProgress()
        {
            // A modifier
            foreach (IQuestObjective iO in Objectives)
            {
                if (iO.ObjectiveIsComplete == false)
                {
                    QuestIsComplete = false;
                    return;
                }
            }
            QuestIsComplete = true;
        }

        /// <summary>
        /// Quests the progression.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int QuestProgression(int objectiveID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List of quest objectives
        /// </summary>
        List<ObjectiveController> QuestObjectives;
    }
}
