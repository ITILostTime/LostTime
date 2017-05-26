using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.Interfaces;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    public class ObjectiveTypes : IQuestObjective
    {
        /// <summary>
        /// Gets the quest identifier.
        /// </summary>
        /// <value>
        /// The quest identifier.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        int IQuestObjective.QuestID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the objective description.
        /// </summary>
        /// <value>
        /// The objective description.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        string IQuestObjective.ObjectiveDescription
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        bool IQuestObjective.IsComplete
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the type of the objective.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        /// <exception cref="System.NotImplementedException">
        /// </exception>
        ObjectiveTypes IQuestObjective.Type
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Enum of the different quest types
        /// </summary>
        public enum Types
        {
            Collect,
            TalkToPNJ
        }

    }
}
