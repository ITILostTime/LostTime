using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    class TypeCollectBehavior : MonoBehaviour
    {
        int _questID;
        int _objectiveID;

        public int QuestID
        {
            get { return _questID; }
            set { _questID = value; }
        }
        public int ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
            {
                gameObject.SetActive(false);

                //GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().Amount++;
                //GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().CollectIsComplete();

                Destroy(gameObject);

                //Debug.Log(GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().Amount);
                //Debug.Log(GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().GoalAmount);
                //Debug.Log(GameObject.Find("QID" + QuestID + "OID" + ObjectiveID).GetComponent<ObjectiveController>().ObjectiveIsComplete);
            }
        }
    }
}