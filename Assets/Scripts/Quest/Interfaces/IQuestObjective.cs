using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace Assets.Scripts.Quest.Interfaces
{
    public interface IQuestObjective
    {
        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        float QuestID { get; set; }

        /// <summary>
        /// Gets or sets the objective identifier.
        /// </summary>
        /// <value>
        /// The objective identifier.
        /// </value>
        int ObjectiveID { get; set; }

        /// <summary>
        /// Gets or sets the name of the objective.
        /// </summary>
        /// <value>
        /// The name of the objective.
        /// </value>
        string ObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the objective description.
        /// </summary>
        /// <value>
        /// The objective description.
        /// </value>
        string ObjectiveDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        bool ObjectiveIsComplete { get; set; }

        /// <summary>
        /// Gets or sets the objective context.
        /// </summary>
        /// <value>
        /// The objective context.
        /// </value>
        string ObjectiveContext { get; set; }

        /// <summary>
        /// Gets or sets the type of the objective.
        /// </summary>
        /// <value>
        /// The type of the objective.
        /// </value>
        string ObjectiveType { get; set; }
    }
}
