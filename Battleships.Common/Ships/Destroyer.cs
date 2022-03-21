using Battleships.Common.Enums;

namespace Battleships.Common.Ships
{
    public class Destroyer : ShipBase
    {
        public Destroyer(OrientationEnum orientation)
        {
            Identifier = Guid.NewGuid();
            Size = 4;
            Orientation = orientation;
            Type = "Destroyer";
        }
    }
}
