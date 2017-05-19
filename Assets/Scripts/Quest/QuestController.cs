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
            get { return questInformations.QuestID; }
            set { questInformations.QuestID = value; }
        }

        /// <summary>
        /// Gets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        public string QuestName
        {
            get { return questInformations.QuestName; }
            set { questInformations.QuestName = value; }
        }

        /// <summary>
        /// Gets the quest description.
        /// </summary>
        /// <value>
        /// The quest description.
        /// </value>
        public string QuestDescription
        {
            get { return questInformations.QuestDescription; }
            set { questInformations.QuestDescription = value; }
        }

        /// <summary>
        /// Gets the quest dialogue.
        /// </summary>
        /// <value>
        /// The quest dialogue.
        /// </value>
        public string QuestDialogue
        {
            get { return questInformations.QuestDialogue; }
            set { questInformations.QuestDialogue = value; }
        }

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
