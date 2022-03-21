using Battleships.Common;
using Battleships.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Strategies
{
    public class HorizontalShipPlacerStrategy : IHorizontalShipPlacerStrategy
    {
        /// <summary>
        /// Places a ship horizontally on the matrix.
        /// </summary>
        /// <param name="board">The board to place the ship on</param>
        /// <param name="startX">Where to start placing the ship horizontally</param>
        /// <param name="startY">Where to start placing the ship vertically</param>
        /// <param name="ship">The ship to place</param>
        public BattleshipResult PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship)
        {
            for (var i = startX; i <= startX + ship.Size - 1; i++)
            {
                if (board[i][startY].HasBattleship)
                {
                    return new BattleshipResult
                    {
                        IsSuccessful = false,
                        ResultMessage = "Battleship already on the requested cell"
                    };
                }
            }
            var cellsInhabited = new List<BoardCell>();
            for (var i = startX; i <= startX + ship.Size - 1; i++)
            {
                board[i][startY].BattleshipIdentifier = ship.Identifier;
                board[i][startY].HasBattleship = true;
                cellsInhabited.Add(board[i][startY]);
            }
            ship.CellsInhabited = cellsInhabited;
            return new BattleshipResult
            {
                IsSuccessful = true,
            };
        }
    }
}
