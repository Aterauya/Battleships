using Battleships.Common;
using Battleships.Common.Results;
using Battleships.Common.Ships;
using Battleships.Service.Interfaces;

namespace Battleships.Service.Services
{
    public class GameService : IGameService
    {
        private readonly IBoardBuilder _boardBuilder;
        private readonly IShipPlacer _shipPlacer;
        private List<List<BoardCell>> _board;
        private List<ShipBase> _ships;
        public GameService(IBoardBuilder boardBuilder, IShipPlacer shipPlacer)
        {
            _boardBuilder = boardBuilder;
            _shipPlacer = shipPlacer;
        }

        public BattleshipResult StartGame(List<ShipBase> ships, int xSize, int ySize)
        {
            _ships = ships;
            _board = _boardBuilder.BuildBoard(xSize, ySize);


            var random = new Random();
            var hasPlacedShip = false;
            foreach (var ship in _ships)
            {
                var randomX = 0;
                var randomY = 0;
                do
                {
                    randomX = random.Next(0, xSize);
                    randomY = random.Next(0, ySize);
                    var shipPlacerResponse = _shipPlacer.PlaceShip(_board, randomX, randomY, ship);
                    hasPlacedShip = shipPlacerResponse.IsSuccessful;
                }
                while(!hasPlacedShip);
            }
            return new BattleshipResult
            {
                IsSuccessful = true,
            };
        }

        public GuessBattleshipResult ProcessGuess(int guessX, int guessY)
        {
            if (_board.Count <= guessX || _board.First().Count <= guessY)
            {
                return new GuessBattleshipResult
                {
                    IsSuccessful = false,
                    ResultMessage = "This target exceeds the boards size",
                    GameFinished = false
                };
            }
            var cell = _board[guessX][guessY];
            if(cell.Hit)
            {
                return new GuessBattleshipResult
                {
                    IsSuccessful = false,
                    ResultMessage = "You have already targeted this cell",
                    GameFinished = false
                };
            }
            else if(!cell.Hit && cell.HasBattleship)
            {
                var battleship = _ships.Find(i => i.Identifier == cell.BattleshipIdentifier);
                var hitCell = battleship.CellsInhabited.Find(i => i.xCoordinate == guessX + 1 && i.yCoordinate == guessY + 1);
                hitCell.Hit = true;
                if(_ships.All(i => i.IsDestroyed == true))
                {

                }
                if(battleship.IsDestroyed)
                {
                    return new GuessBattleshipResult
                    {
                        IsSuccessful = true,
                        ResultMessage = "Battleship is destroyed",
                        GameFinished = false
                    };
                }
                else
                {
                    return new GuessBattleshipResult
                    {
                        IsSuccessful = true,
                        ResultMessage = "You hit a battleship",
                        GameFinished = false
                    };
                }
            }
            else if(!cell.Hit && !cell.HasBattleship)
            {
                return new GuessBattleshipResult
                {
                    IsSuccessful = false,
                    ResultMessage = "You missed",
                    GameFinished = false
                };
                Console.WriteLine("You missed");
            }
            cell.Hit = true;

            return new GuessBattleshipResult
            {
                IsSuccessful = true,
                GameFinished = false
            };
        }
    }
}
