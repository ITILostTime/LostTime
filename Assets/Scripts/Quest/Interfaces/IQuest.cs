using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Interfaces
{
    public interface IQuest
    {
        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        int QuestID { get; set; }

        /// <summary>
        /// Gets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        string QuestName { get; set; }

        /// <summary>
        /// Gets the quest description.
        /// </summary>
        /// <value>
        /// The quest description.
        /// </value>
        string QuestDescription { get; set; }

        /// <summary>
        /// Checks the progress.
        /// </summary>
        void CheckProgress();

        /// <summary>
        /// Gets the objectives of the quest.
        /// </summary>
        /// <value>
        /// The objectives of the quest.
        /// </value>
        IList<IQuestObjective> Objectives { get; }
    }
}
