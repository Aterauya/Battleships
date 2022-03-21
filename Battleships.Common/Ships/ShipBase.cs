using Battleships.Common.Enums;

namespace Battleships.Common
{
    public abstract class ShipBase
    {
        public ShipBase()
        {
            CellsInhabited = new List<BoardCell>();
        }

        public int Size { get; set; }
        public List<BoardCell> CellsInhabited { get; set; }
        public Guid Identifier { get; set; }
        public OrientationEnum Orientation { get; set; }
        public bool IsDestroyed { get { return CellsInhabited.All(i => i.Hit); } }
        public string Type { get; set; }
    }
}
