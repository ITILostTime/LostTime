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
    public class TypeTalkToPNJ : MonoBehaviour
    {
        private string _talk;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeTalkToPNJ"/> class.
        /// </summary>
        /// <param name="talk">The talk.</param>
        public TypeTalkToPNJ(string talk)
        {
            _talk = talk;
        }

        /// <summary>
        /// Gets the talk.
        /// </summary>
        /// <value>
        /// The talk.
        /// </value>
        public string Talk
        {
            get { return _talk; }
        }
    }
}
