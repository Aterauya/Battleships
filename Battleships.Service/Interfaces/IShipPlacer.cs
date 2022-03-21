using Battleships.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Interfaces
{
    public interface IShipPlacer
    {
        BattleshipResult PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship);
    }
}
