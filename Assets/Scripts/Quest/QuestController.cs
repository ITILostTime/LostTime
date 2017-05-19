using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    class QuestController : IQuest
    {
        /// <summary>
        /// The informations of Quest
        /// </summary>
        IQuest questInformations;

        //int _questSteps; a préciser entre une classe elle même, un string ou un int comme ici
        
        ObjectLibrary _objectLibrary; //Call class ObjectLibrary (contains the quest in the form of list).

        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        public int QuestID
        {
            get { return questInformations.QuestID; }
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
        }

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
