using Battleships.Common.Results;

namespace Battleships.Interfaces
{
    public interface IGuessHandler
    {
        IGuessHandler NextHandler { get; set; }

        GuessBattleshipResult Handle();
    }
}
