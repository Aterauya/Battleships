using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Common.Ships
{
    public class Battleship : ShipBase
    {
        public Battleship(OrientationEnum orientation)
        {
            this.Identifier = Guid.NewGuid();
            this.Size = 5;
            this.Orientation = orientation;
            this.Type = "Battleship";
        }
    }
}
