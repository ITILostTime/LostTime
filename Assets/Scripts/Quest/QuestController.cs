using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class QuestController : IQuest
    {
        /// <summary>
        /// The informations of Quest
        /// </summary>
        IQuest questInformations;

        //int _questSteps; a préciser entre une classe elle même, un string ou un int comme ici
        
        ObjectLibrary _objectLibrary; //Call class ObjectLibrary (contains the quest in the form of list).
        private int _questID;
        private string _questName;
        private string _questDescription;
        private string _questDialogue;

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

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
