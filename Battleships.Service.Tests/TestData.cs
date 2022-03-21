using Battleships.Common;
using Battleships.Common.Enums;
using Battleships.Common.Ships;
using System.Collections.Generic;

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
            var ship = new Battleship(OrientationEnum.Vertical);
            cell.BattleshipIdentifier = ship.Identifier;

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
