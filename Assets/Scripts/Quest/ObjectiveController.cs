﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace Assets.Scripts.Quest
{
    public class ObjectiveController : IQuestObjective
    {
        private int _questID;
        private int _objectiveID;
        private string _objectiveName;
        private string _objectiveDescription;
        private TypeCollect _typeCollect;
        private TypeTalkToPNJ _typeTalkToPNJ;
        private TypeGoToZone _typeGoToZone;
        private bool _objectiveIsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveController"/> class.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="typeCollect">The type collect.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, TypeCollect typeCollect, bool objectiveIsComplete)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            TypeCollect = typeCollect;
            ObjectiveIsComplete = objectiveIsComplete;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveController"/> class.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="typeTalkToPNJ">The type talk to PNJ.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, TypeTalkToPNJ typeTalkToPNJ, bool objectiveIsComplete)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            TypeTalkToPNJ = typeTalkToPNJ;
            ObjectiveIsComplete = objectiveIsComplete;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectiveController"/> class.
        /// </summary>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="typeGoToZone">The type go to zone.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        public ObjectiveController(int objectiveID, string objectiveName, string objectiveDescription, TypeGoToZone typeGoToZone, bool objectiveIsComplete)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            TypeGoToZone = typeGoToZone;
            ObjectiveIsComplete = objectiveIsComplete;
        }

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
        /// Gets or sets the objective identifier.
        /// </summary>
        /// <value>
        /// The objective identifier.
        /// </value>
        public int ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        /// <summary>
        /// Gets or sets the name of the objective.
        /// </summary>
        /// <value>
        /// The name of the objective.
        /// </value>
        public string ObjectiveName
        {
            get { return _objectiveName; }
            set { _objectiveName = value; }
        }

        /// <summary>
        /// Gets or sets the objective description.
        /// </summary>
        /// <value>
        /// The objective description.
        /// </value>
        public string ObjectiveDescription
        {
            get { return _objectiveDescription; }
            set { _objectiveDescription = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this objective is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this objective is complete; otherwise, <c>false</c>.
        /// </value>
        public bool ObjectiveIsComplete
        {
            get { return _objectiveIsComplete; }
            set { _objectiveIsComplete = value; }
        }

        /// <summary>
        /// Gets or sets the type collect.
        /// </summary>
        /// <value>
        /// The type collect.
        /// </value>
        public TypeCollect TypeCollect
        {
            get { return _typeCollect; }
            set { _typeCollect = value; }
        }

        /// <summary>
        /// Gets or sets the type talk to PNJ.
        /// </summary>
        /// <value>
        /// The type talk to PNJ.
        /// </value>
        public TypeTalkToPNJ TypeTalkToPNJ
        {
            get { return _typeTalkToPNJ; }
            set { _typeTalkToPNJ = value; }
        }

        /// <summary>
        /// Gets or sets the type go to zone.
        /// </summary>
        /// <value>
        /// The type go to zone.
        /// </value>
        public TypeGoToZone TypeGoToZone
        {
            get { return _typeGoToZone; }
            set { _typeGoToZone = value; }
        }
    }
}
