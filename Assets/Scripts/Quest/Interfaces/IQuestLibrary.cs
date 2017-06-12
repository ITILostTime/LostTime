using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Interfaces
{
    public interface IQuestLibrary
    {
        /// <summary>
        /// Gets or sets the quest list.
        /// </summary>
        /// <value>
        /// The quest list.
        /// </value>
        List<IQuest> QuestList { get; set; }
    }
}
