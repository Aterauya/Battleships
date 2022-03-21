using Battleships.Common;

namespace Battleships.Service.Interfaces
{
    public interface IShipPlacerStrategy
    {
        public BattleshipResult PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship);
    }
}
