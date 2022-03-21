using Battleships.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    public static class TestData
    {
        public static List<List<BoardCell>> GetVerticallyFilledBoard()
        {
            return new List<List<BoardCell>>()
            {
                new List<BoardCell>()
                {
                    new BoardCell(0, 0),
                    new BoardCell(0, 0),
                    new BoardCell(0, 0),
                    new BoardCell(0, 0),
                    new BoardCell(0, 0),
                    new BoardCell(0, 0)

                }
            };
        }

        public static List<List<BoardCell>> GetHorizontallyFilledBoard()
        {
            return new List<List<BoardCell>>()
            {
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },
                new List<BoardCell>()
                {
                    new BoardCell(0,0)
                },

            };
        }

        public static List<List<BoardCell>> GetBoardWithSingleCell()
        {
            return new List<List<BoardCell>>()
            {
                new List<BoardCell>()
                {
                    new BoardCell(0, 0)
                }
            };
        }

        public static List<List<BoardCell>> GetBoardWithBattleshipOn()
        {
            var cell = new BoardCell(0, 0);
            cell.HasBattleship = true;
            return new List<List<BoardCell>>()
            {
                new List<BoardCell>()
                {
                    cell
                }
            };
        }
    }
}
