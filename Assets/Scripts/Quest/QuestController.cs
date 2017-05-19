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

        public int QuestID
        {
            get { return questInformations.QuestID; }
        }

        public string QuestName
        {
            get { return questInformations.QuestName; }
        }

        public string QuestDescription
        {
            get { return questInformations.QuestDescription; }
        }

        public string QuestDialogue
        {
            get { return questInformations.QuestDialogue; }
        }

        //QuestLog (à définir + à implémenter)
        //EventLog (à définir + à implémenter)
    }
}
