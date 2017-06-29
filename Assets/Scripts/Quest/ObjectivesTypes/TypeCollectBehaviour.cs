using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    class TypeCollectBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
            {
                gameObject.SetActive(false);
                
                GameObject.Find("TypeCollectController").GetComponent<TypeCollect>().Amount++;

                Debug.Log(GameObject.Find("TypeCollectController").GetComponent<TypeCollect>().Amount);
                Debug.Log(GameObject.Find("TypeCollectController").GetComponent<TypeCollect>().GoalAmount);
            }
        }
    }
}