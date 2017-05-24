using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Quest.ObjectivesTypes;

namespace Assets.Scripts.Quest
{
    class ObjectiveController
    {
        private int _objectiveID;
        private string _objectiveName;
        private ObjectiveTypes _objectiveType;
        private bool _isComplete;

        public ObjectiveController(int objectiveID, string objectiveName, ObjectiveTypes objectiveType, bool isComplete)
        {
            ObjectiveID = objectiveID;
            ObjectiveName = objectiveName;
            ObjectiveType = objectiveType;
            IsComplete = isComplete;
        }

        public int ObjectiveID
        {
            get
            {
                return _objectiveID;
            }

            set
            {
                _objectiveID = value;
            }
        }

        public string ObjectiveName
        {
            get
            {
                return _objectiveName;
            }

            set
            {
                _objectiveName = value;
            }
        }

        public ObjectiveTypes ObjectiveType
        {
            get
            {
                return _objectiveType;
            }

            set
            {
                _objectiveType = value;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _isComplete;
            }

            set
            {
                _isComplete = value;
            }
        }
    }
}
