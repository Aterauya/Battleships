using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Common
{
    public abstract class ShipBase
    {
        public ShipBase()
        {
            this.CellsInhabited = new List<BoardCell>();
        }

        public int Size { get; set; }
        public List<BoardCell> CellsInhabited { get; set; }
        public Guid Identifier { get; set; }
        public OrientationEnum Orientation { get; set; }
        public bool IsDestroyed { get { return this.CellsInhabited.All(i => i.Hit); } }
        public string Type { get; set; }
    }
}
