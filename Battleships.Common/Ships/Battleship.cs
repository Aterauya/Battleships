using Battleships.Common.Enums;

namespace Battleships.Common.Ships
{
    public class Battleship : ShipBase
    {
        public Battleship(OrientationEnum orientation)
        {
            Identifier = Guid.NewGuid();
            Size = 5;
            Orientation = orientation;
            Type = "Battleship";
        }
    }
}
