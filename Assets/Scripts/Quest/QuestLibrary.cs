using Assets.Scripts.Quest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest
{
    public class QuestLibrary : IQuestLibrary
    {
        private List<IQuest> _questList;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLibrary"/> class.
        /// </summary>
        /// <param name="questList">The quest list.</param>
        public QuestLibrary(List<IQuest> questList)
        {
            _questList = questList;
        }

        /// <summary>
        /// Gets or sets the quest list.
        /// </summary>
        /// <value>
        /// The quest list.
        /// </value>
        List<IQuest> IQuestLibrary.QuestList
        {
            get { return _questList; }
            set { _questList = value; }
        }
    }
}
