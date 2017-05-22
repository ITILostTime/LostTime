using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.Interfaces
{
    interface IQuestObjective
    {
        /// <summary>
        /// Gets or sets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        string QuestName { get; set; }

        /// <summary>
        /// Gets or sets the quest description.
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
        bool IsComplete { get; set; }

        /// <summary>
        /// Updates the progress.
        /// </summary>
        void UpdateProgress();

        /// <summary>
        /// Checks the progress.
        /// </summary>
        void CheckProgress();
    }
}
