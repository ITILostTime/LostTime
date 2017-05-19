using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    class QuestController : IQuest
    {
        int _questID;
        string _questName;
        string _questDescription;
        string _questDialogue;
        //int _questSteps; a préciser entre une classe elle même, un string ou un int comme ici

        ObjectLibrary _objectLibrary; //appel de la classe objectLibrary qui contient les objets de la quête sous forme de liste 

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
        /// Gets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        public string QuestName
        {
            get { return _questName; }
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
        }

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
