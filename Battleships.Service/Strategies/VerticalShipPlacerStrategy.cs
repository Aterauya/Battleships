using Battleships.Common;
using Battleships.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Strategies
{
    public class VerticalShipPlacerStrategy : IVerticalShipPlacerStrategy
    {
        /// <summary>
        /// Places a ship vertically on the matrix.
        /// </summary>
        /// <param name="board">The board to place the ship on</param>
        /// <param name="startX">Where to start placing the ship horizontally</param>
        /// <param name="startY">Where to start placing the ship vertically</param>
        /// <param name="ship">The ship to place</param>
        public bool PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship)
        {
            for (var i = startY; i <= startY + ship.Size - 1; i++)
            {
                if (board[startX][i].HasBattleship)
                {
                    return false;
                }
            }
            var cellsInhabited = new List<BoardCell>();
            for (var i = startY; i <= startY + ship.Size - 1; i++)
            {
                board[startX][i].BattleshipIdentifier = ship.Identifier;
                board[startX][i].HasBattleship = true;
                cellsInhabited.Add(board[startX][i]);
            }
            ship.CellsInhabited = cellsInhabited;
            return true;
        }
    }
}
