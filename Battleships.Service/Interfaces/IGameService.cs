using Battleships.Common;
using Battleships.Common.Results;

namespace Battleships.Service.Interfaces
{
    public interface IGameService
    {
        BattleshipResult StartGame(List<ShipBase> ships, int xSize, int ySize);
        GuessBattleshipResult ProcessGuess(int guessX, int guessY);
    }
}
