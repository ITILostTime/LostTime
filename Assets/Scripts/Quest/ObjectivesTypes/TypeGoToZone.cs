using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Quest.ObjectivesTypes
{
    public class TypeGoToZone
    {
        private int _zone;
        private int _positionX;
        private int _positionY;
        private int _positionZ;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeGoToZone"/> class.
        /// </summary>
        /// <param name="zone">The zone.</param>
        /// <param name="positionX">The position x.</param>
        /// <param name="positionY">The position y.</param>
        /// <param name="positionZ">The position z.</param>
        public TypeGoToZone(int zone, int positionX, int positionY, int positionZ)
        {
            Zone = zone;
            PositionX = positionX;
            PositionY = positionY;
            PositionZ = positionZ;
        }

        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        /// <value>
        /// The zone.
        /// </value>
        public int Zone
        {
            get { return _zone; }
            set { _zone = value; }
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
    }
}
