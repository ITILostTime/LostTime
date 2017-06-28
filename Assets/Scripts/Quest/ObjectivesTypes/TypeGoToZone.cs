using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    public class TypeGoToZone : MonoBehaviour
    {
        private int _positionX;
        private int _positionY;
        private int _positionZ;
        private bool _typeGoToZoneIsComplete;

        // Ecrire différement 

        private void Start()
        {
            
        }

        /// <summary>
        /// Gets or sets the position x.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        /// <summary>
        /// Gets or sets the position y.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        /// <summary>
        /// Gets or sets the position z.
        /// </summary>
        /// <value>
        /// The position z.
        /// </value>
        public int PositionZ
        {
            get { return _positionZ; }
            set { _positionZ = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [type go to zone is complete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [type go to zone is complete]; otherwise, <c>false</c>.
        /// </value>
        public bool TypeGoToZoneIsComplete
        {
            get { return _typeGoToZoneIsComplete; }
            set { _typeGoToZoneIsComplete = value; }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.name == "AstridPlayer") // si le PNJ a une quête 
            {
                gameObject.SetActive(false);

                this.GetComponent<TypeGoToZone>().TypeGoToZoneIsComplete = true;
                Debug.Log(this.GetComponent<TypeGoToZone>().TypeGoToZoneIsComplete);
            }
        }
    }
}
