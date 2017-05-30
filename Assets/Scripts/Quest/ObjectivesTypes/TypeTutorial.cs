using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    /// <summary>
    /// Implement the objective type tutorial
    /// </summary>
    public class TypeTutorial
    {
        private int _steps;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeTutorial"/> class.
        /// </summary>
        /// <param name="steps">The steps.</param>
        public TypeTutorial(int steps)
        {
            _steps = steps;
        }

        /// <summary>
        /// Gets the steps.
        /// </summary>
        /// <value>
        /// The steps.
        /// </value>
        public int Steps
        {
            get { return _steps; }
        }
    }
}
