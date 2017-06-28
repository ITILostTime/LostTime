using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.PNJQuest
{
    public class PNJ
    {
        private float _positionX;
        private float _positionY;
        private float _positionZ;
        private float _rotationX;
        private float _rotationY;
        private float _rotationZ;
        private string _pnjName;
        private float _pnjCurrentQuestID;
        private int _pnjQuestIDMax;
        List<float> _pnjquest;



        public PNJ(float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, string pnjName, 
            float pnjCurrentQuestID, int pnjQuestIDMax, List<float> pnjQuest)
        {
            _positionX = positionX;
            _positionY = positionY;
            _positionZ = positionZ;
            _rotationX = rotationX;
            _rotationY = rotationY;
            _rotationZ = rotationZ;
            _pnjName = pnjName;
            _pnjCurrentQuestID = pnjCurrentQuestID;
            _pnjQuestIDMax = pnjQuestIDMax;
            _pnjquest = new List<float>();
            _pnjquest = pnjQuest;
        }
        
        public float GetPositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public float GetPositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public float GetPositionZ
        {
            get { return _positionZ; }
            set { _positionZ = value; }
        }

        public float GetRotationX
        {
            get { return _rotationX; }
            set { _rotationX = value; }
        }

        public float GetRotationY
        {
            get { return _rotationY; }
            set { _rotationY = value; }
        }

        public float GetRotationZ
        {
            get { return _rotationZ; }
            set { _rotationZ = value; }
        }

        public string GetPNJName
        {
            get { return _pnjName; }
            set { _pnjName = value; }
        }

        public float GetPNJCurrentQuestID
        {
            get { return _pnjCurrentQuestID; }
            set { _pnjCurrentQuestID = value; }
        }

        public int GetPNJQuestIDMax
        {
            get { return _pnjQuestIDMax; }
            set { _pnjQuestIDMax = value; }
        }

        public List<float> GetPNJQuest
        {
            get { return _pnjquest; }
            set { _pnjquest = value; }
        }
    }
}
