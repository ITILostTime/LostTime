using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    /// <summary>
    /// Implement the objective type talk to a pnj
    /// </summary>
    public class TypeTalkToPNJBehavior : MonoBehaviour
    {
        private int _questID;
        private int _objectiveID;
        GameObject pnj;

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

        /// <summary>
        /// Generates the PNJ.
        /// </summary>
        /// <param name="pnjName">Name of the PNJ.</param>
        /// <param name="positionX">The position x.</param>
        /// <param name="positionY">The position y.</param>
        /// <param name="positionZ">The position z.</param>
        /// <param name="rotationX">The rotation x.</param>
        /// <param name="rotationY">The rotation y.</param>
        /// <param name="rotationZ">The rotation z.</param>
        /// <param name="job">The job.</param>
        public void GeneratePNJ(string pnjName, float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, string job)
        {
            // generer PNJ soit trouver le PNJ
            GameObject.Find("Event").GetComponent<GeneratePNJ>().GeneratePNJGearDistrict(pnjName, positionX, positionY, positionZ, rotationX, rotationY, rotationZ, job);
            pnj = GameObject.Find(pnjName);
            Debug.Log("Salut je suis dans le Start");

            // Add au PNJ un script => ce script va appeler l'ui dialogue avec le text passé en parametre 
            pnj.AddComponent<UIDialogueSystem>();

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "AstridPlayer")
            {
                pnj.GetComponent<UIDialogueSystem>().InteractWithPNJ(pnj.transform.name);
            }
        }

    }
}
