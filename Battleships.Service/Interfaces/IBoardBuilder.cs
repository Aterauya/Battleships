using Battleships.Common;

namespace Battleships.Service.Interfaces
{
    public interface IBoardBuilder
    {
        List<List<BoardCell>> BuildBoard(int xAmount, int yAmount);
    }
}
