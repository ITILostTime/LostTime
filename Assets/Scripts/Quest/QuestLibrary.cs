using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    class QuestLibrary : IQuestLibrary
    {
        List<IQuest> _questList;

        /// <summary>
        /// Gets or sets the quest list.
        /// </summary>
        /// <value>
        /// The quest list.
        /// </value>
        List<IQuest> QuestList
        {
            get { return _questList; }
            set { _questList = value; }
        }
    }
}
