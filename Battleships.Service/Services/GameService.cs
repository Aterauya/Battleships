using Battleships.Common;
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

        public bool StartGame()
        {
            _board = _boardBuilder.BuildBoard(10, 10);
            _ships = new List<ShipBase>();
            _ships.Add(new Battleship(OrientationEnum.Horizontal));
            _ships.Add(new Destroyer(OrientationEnum.Vertical));
            _ships.Add(new Destroyer(OrientationEnum.Horizontal));

            var random = new Random();
            var hasPlacedShip = false;
            foreach (var ship in _ships)
            {
                var randomX = 0;
                var randomY = 0;
                do
                {
                    randomX = random.Next(0, 10);
                    randomY = random.Next(0, 10);
                    hasPlacedShip = _shipPlacer.PlaceShip(_board, randomX, randomY, ship);
                }
                while(!hasPlacedShip);
            }
            return true;
        }

        public bool ProcessGuess(int guessX, int guessY)
        {
            if (_board.Count <= guessX || _board.First().Count <= guessY)
            {
                Console.WriteLine("This target exceeds the boards size");
                return true;
            }
            var cell = _board[guessX][guessY];
            if(cell.Hit)
            {
                Console.WriteLine("You have already targeted this cell");
            }
            else if(!cell.Hit && cell.HasBattleship)
            {
                var battleship = _ships.Find(i => i.Identifier == cell.BattleshipIdentifier);
                var hitCell = battleship.CellsInhabited.Find(i => i.xCoordinate == guessX + 1 && i.yCoordinate == guessY + 1);
                hitCell.Hit = true;
                if(battleship.IsDestroyed)
                {
                    Console.Write("Battleship is destroyed");
                }
                else
                {
                    Console.WriteLine("You hit a battleship");
                }
            }
            else if(!cell.Hit && !cell.HasBattleship)
            {
                Console.WriteLine("You missed");
            }
            cell.Hit = true;

            return true;
        }
    }
}
