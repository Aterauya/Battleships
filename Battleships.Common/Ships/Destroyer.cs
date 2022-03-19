using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Common.Ships
{
    public class Destroyer : ShipBase
    {
        public Destroyer(OrientationEnum orientation)
        {
            this.Identifier = Guid.NewGuid();
            this.Size = 4;
            this.Orientation = orientation;
            this.Type = "Destroyer";
        }
    }
}
