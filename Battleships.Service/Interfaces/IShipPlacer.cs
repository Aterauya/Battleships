using Battleships.Common;

namespace Battleships.Service.Interfaces
{
    public interface IShipPlacer
    {
        BattleshipResult PlaceShip(List<List<BoardCell>> board, int startX, int startY, ShipBase ship);
    }
}
