using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class QuestLog : MonoBehaviour
    {
        QuestLog _questLog;
        QuestLibrary _questLibrary;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start()
        {
            _questLog = new QuestLog(QuestLibrary);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestLog"/> class.
        /// </summary>
        /// <param name="questLibrary">The quest library.</param>
        public QuestLog(QuestLibrary questLibrary)
        {
            QuestLibrary = questLibrary;
        }

        /// <summary>
        /// Gets or sets the quest library.
        /// </summary>
        /// <value>
        /// The quest library.
        /// </value>
        public QuestLibrary QuestLibrary
        {
            get { return _questLibrary; }
            set { _questLibrary = value; }
        }

        /// <summary>
        /// Shows the quest information.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        // Return quest info (questID, questDescription, objectiveID, objectiveDescription, isComplete)        
        void ShowQuestInfo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}
