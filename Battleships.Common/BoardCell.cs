using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Common
{
    public class BoardCell
    {
        public BoardCell(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public bool Hit { get; set; } = false;
        public bool HasBattleship { get; set; } = false;
        public Guid? BattleshipIdentifier { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
    }
}
