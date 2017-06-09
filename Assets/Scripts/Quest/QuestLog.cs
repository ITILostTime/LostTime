using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.Interfaces;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace Assets.Scripts.Quest
{
    public class QuestLog : IQuestObjective, IQuest
    {
        //IQuestObjective
        private int _questID;
        private int _objectiveID;
        private string _objectiveName;
        private string _objectiveDescription;
        private TypeCollect _typeCollect;
        private TypeTalkToPNJ _typeTalkToPNJ;
        private TypeGoToZone _typeGoToZone;
        private bool _isComplete;

        //IQuest
        private string _questName;
        private string _questDescription;
        private IList<IQuestObjective> _objectivesControllers;
        private bool _questIsComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLog"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        public QuestLog(int questID, int objectiveID, string objectiveName, string objectiveDescription, bool isComplete, TypeCollect typeCollect)
        {
            QuestID = questID;
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            IsComplete = isComplete;
            TypeCollect = typeCollect;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLog"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        /// <param name="typeTalkToPNJ">The type talk to PNJ.</param>
        public QuestLog(int questID, int objectiveID, string objectiveName, string objectiveDescription, bool isComplete, TypeTalkToPNJ typeTalkToPNJ)
        {
            QuestID = questID;
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            IsComplete = isComplete;
            TypeTalkToPNJ = typeTalkToPNJ;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLog"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="objectiveID">The objective identifier.</param>
        /// <param name="objectiveName">Name of the objective.</param>
        /// <param name="objectiveDescription">The objective description.</param>
        /// <param name="isComplete">if set to <c>true</c> [is complete].</param>
        /// <param name="typeGoToZone">The type go to zone.</param>
        public QuestLog(int questID, int objectiveID, string objectiveName, string objectiveDescription, bool isComplete, TypeGoToZone typeGoToZone)
        {
            QuestID = questID;
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveDescription = objectiveDescription;
            IsComplete = isComplete;
            TypeGoToZone = typeGoToZone;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLog"/> class.
        /// </summary>
        /// <param name="questID">The quest identifier.</param>
        /// <param name="questName">Name of the quest.</param>
        /// <param name="questDescription">The quest description.</param>
        /// <param name="questIsComplete">if set to <c>true</c> [quest is complete].</param>
        public QuestLog(int questID, string questName, string questDescription, bool questIsComplete)
        {
            QuestID = questID;
            QuestName = questName;
            QuestDescription = questDescription;
            QuestIsComplete = questIsComplete;
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
            set { _questID = value; }
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
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        /// <summary>
        /// Checks the progress.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void CheckProgress()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name of the quest.
        /// </summary>
        /// <value>
        /// The name of the quest.
        /// </value>
        public string QuestName
        {
            get { return _questName; }
            set { _questName = value; }
        }

        /// <summary>
        /// Gets the quest description.
        /// </summary>
        /// <value>
        /// The quest description.
        /// </value>
        public string QuestDescription
        {
            get { return _questDescription; }
            set { _questDescription = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is complete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </value>
        public bool QuestIsComplete
        {
            get { return _questIsComplete; }
            set { _questIsComplete = value; }
        }

        /// <summary>
        /// Gets the objectives of the quest.
        /// </summary>
        /// <value>
        /// The objectives of the quest.
        /// </value>
        public IList<IQuestObjective> Objectives
        {
            get { return _objectivesControllers; }
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
