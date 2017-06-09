using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class QuestController : IQuest
    {
        private int _questID;
        private string _questName;
        private string _questDescription;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestController"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="questName">Name of the quest.</param>
        /// <param name="questDescription">The quest description.</param>
        /// <param name="questDialogue">The quest dialogue.</param>
        public QuestController(int questID, string questName, string questDescription)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
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
        /// Gets the objectives of the quest.
        /// </summary>
        /// <value>
        /// The objectives of the quest.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<IQuestObjective> Objectives
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Checks the progress.
        /// </summary>
        public void CheckProgress()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List of quest objectives
        /// </summary>
        List<ObjectiveController> QuestObjectives;
    }
}
