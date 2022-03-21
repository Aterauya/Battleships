using Battleships.Common;
using Battleships.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Services
{
    public class BoardBuilder : IBoardBuilder
    {
        /// <summary>
        /// Builds a matrix.
        /// </summary>
        /// <param name="xAmount">The X amount of cells</param>
        /// <param name="yAmount">The Y amount of cells</param>
        /// <returns></returns>
        public List<List<BoardCell>> BuildBoard(int xAmount, int yAmount)
        {
            var board = new List<List<BoardCell>>();
            for (int i = 0; i < xAmount; i++)
            {
                var row = new List<BoardCell>();
                for(int j = 0; j < yAmount; j++)
                {
                    row.Add(new BoardCell(i + 1,j + 1));
                }
                board.Add(row);
            }
            return board;
        }
    }
}
