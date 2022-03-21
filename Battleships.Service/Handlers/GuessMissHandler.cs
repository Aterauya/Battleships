using Battleships.Common.Results;
using Battleships.Interfaces;

namespace Battleships.Service.Handlers
{
    internal class GuessMissHandler : IGuessHandler
    {
        public IGuessHandler NextHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GuessBattleshipResult Handle()
        {
            throw new NotImplementedException();
        }
    }
}
