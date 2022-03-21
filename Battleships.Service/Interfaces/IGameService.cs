using Battleships.Common;
using Battleships.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Service.Interfaces
{
    public interface IGameService
    {
        BattleshipResult StartGame(List<ShipBase> ships, int xSize, int ySize);
        GuessBattleshipResult ProcessGuess(int guessX, int guessY);
    }
}
