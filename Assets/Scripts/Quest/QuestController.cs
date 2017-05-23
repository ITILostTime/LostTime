using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class QuestController : IQuest
    {
        //int _questSteps; a préciser entre une classe elle même, un string ou un int comme ici
        //ObjectLibrary _objectLibrary; //Call class ObjectLibrary (contains the quest in the form of list).

        private int _questID;
        private string _questName;
        private string _questDescription;
        private string _questDialogue;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestController"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="questName">Name of the quest.</param>
        /// <param name="questDescription">The quest description.</param>
        /// <param name="questDialogue">The quest dialogue.</param>
        public QuestController(int questID, string questName, string questDescription, string questDialogue)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            QuestDialogue = questDialogue;
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
        /// Gets the quest dialogue.
        /// </summary>
        /// <value>
        /// The quest dialogue.
        /// </value>
        public string QuestDialogue
        {
            get { return _questDialogue; }
            set { _questDialogue = value; }
        }

        /// <summary>
        /// Checks the progress.
        /// </summary>
        void CheckProgress() 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List of quest objectives
        /// </summary>
        List<QuestObjective> QuestObjectives;
    }
}
