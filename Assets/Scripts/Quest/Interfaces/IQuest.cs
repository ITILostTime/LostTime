using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Interfaces
{
    public interface IQuest
    {
        /// <summary>
        /// Gets or sets the quest title.
        /// </summary>
        /// <value>
        /// The quest title.
        /// </value>
        string QuestPNJ { get; set; }

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
        /// Gets or sets the quest context.
        /// </summary>
        /// <value>
        /// The quest context.
        /// </value>
        string QuestContext { get; set; }

        /// <summary>
        /// Gets the quest description.
        /// </summary>
        /// <value>
        /// The quest description.
        /// </value>
        string QuestDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        bool QuestIsComplete { get; set; }

        /// <summary>
        /// Gets the objectives of the quest.
        /// </summary>
        /// <value>
        /// The objectives of the quest.
        /// </value>
        List<IQuestObjective> Objectives { get; set; }

        /// <summary>
        /// Quests the progression.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <returns></returns>
        int QuestProgression(int objectiveID);
    }
}
