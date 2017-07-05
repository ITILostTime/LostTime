using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    public class TypeGoToZoneBehavior : MonoBehaviour
    {
        float _questID;
        int _objectiveID;

        public float QuestID
        {
            get { return _questID; }
            set { _questID = value; }
        }
        
        public int ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
            {
                Debug.Log("questid : " + QuestID + "ObjectifID :" + ObjectiveID);
                GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().TypeGoToZoneIsComplete = true;

                Destroy(this.gameObject);
            }
        }
    }
}
