using Battleships.Common;
using Battleships.Service.Interfaces;

namespace Battleships.Service.Services
{
    public class ShipPlacer : IShipPlacer
    {
        private readonly IVerticalShipPlacerStrategy _verticalShipPlacer;
        private readonly IHorizontalShipPlacerStrategy _horizontalShipPlacer;
        public ShipPlacer(IVerticalShipPlacerStrategy verticalShipPlacer, IHorizontalShipPlacerStrategy horizontalShipPlacer)
        {
            _verticalShipPlacer = verticalShipPlacer;
            _horizontalShipPlacer = horizontalShipPlacer;
        }

        /// <summary>
        /// Places a ship on the matrix.
        /// </summary>
        /// <param name="board">The board to place the ship on</param>
        /// <param name="startX">Where to start placing the ship horizontally</param>
        /// <param name="startY">Where to start placing the ship vertically</param>
        /// <param name="ship">The ship to place</param>
        public BattleshipResult PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship)
        {
            if (ship.Orientation == OrientationEnum.Horizontal)
            {
                if (board.Count <= startX + ship.Size)
                {
                    return new BattleshipResult
                    {
                        IsSuccessful = false,
                        ResultMessage = "Ship is too big to fit Horizontally"
                    };
                }
                return _horizontalShipPlacer.PlaceShip(board, startX, startY, ship);
            }
            if (ship.Orientation == OrientationEnum.Vertical)
            {
                if (board.First().Count <= startY + ship.Size)
                {
                    return new BattleshipResult
                    {
                        IsSuccessful = false,
                        ResultMessage = "Ship is too big to fit Vertically"
                    };
                }
                return _verticalShipPlacer.PlaceShip(board, startX, startY, ship);

            }
            return new BattleshipResult
            {
                IsSuccessful = false,
            };
        }
    }
}
