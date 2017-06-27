using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    /// <summary>
    /// Implement the objective types collect.
    /// </summary>
    public class TypeCollect : MonoBehaviour
    {
        private int _amount;
        private int _goalAmount;
        
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount
        {
            get { return _amount; }

            set { _amount = value; }
        }

        /// <summary>
        /// Gets or sets the goal amount.
        /// </summary>
        /// <value>
        /// The goal amount.
        /// </value>
        public int GoalAmount
        {
            get { return _goalAmount; }

            set { _goalAmount = value; }
        }

        /// <summary>
        /// Determines whether this instance is complete.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is complete; otherwise, <c>false</c>.
        /// </returns>
        public bool IsComplete()
        {
            if (Amount == GoalAmount)
            {
                return true;
            }

            return false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
            {
                gameObject.SetActive(false);
                Amount++;
            }
        }

    }
}
