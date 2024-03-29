﻿using Battleships.Common;
using Battleships.Common.Results;
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

        /// <summary>
        /// Starts the battleships game
        /// </summary>
        /// <param name="ships">The ships to place on the board</param>
        /// <param name="xSize">The amount of columns on the board</param>
        /// <param name="ySize">The amount of rows on the board</param>
        /// <returns>Whether or not the game started successfully</returns>
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
                while (!hasPlacedShip);
            }
            return new BattleshipResult
            {
                IsSuccessful = true,
            };
        }

        /// <summary>
        /// Processes the guess from the user
        /// </summary>
        /// <param name="guessX">The column the user guessed</param>
        /// <param name="guessY">The row the user guessed</param>
        /// <returns>User feedback if the guess hit or didn't hit a ship</returns>
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
            if (cell.Hit)
            {
                return new GuessBattleshipResult
                {
                    IsSuccessful = false,
                    ResultMessage = "You have already targeted this cell",
                    GameFinished = false
                };
            }
            else if (!cell.Hit && cell.HasBattleship)
            {
                var battleship = _ships.Find(i => i.Identifier == cell.BattleshipIdentifier);
                var hitCell = battleship.CellsInhabited.Find(i => i.XCoordinate == guessX + 1 && i.YCoordinate == guessY + 1);
                hitCell.Hit = true;
                if (_ships.All(i => i.IsDestroyed == true))
                {
                    return new GuessBattleshipResult
                    {
                        IsSuccessful = true,
                        ResultMessage = "Congratulations, you have sunk all the ships!",
                        GameFinished = true,
                    };
                }
                if (battleship.IsDestroyed)
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
            else if (!cell.Hit && !cell.HasBattleship)
            {
                return new GuessBattleshipResult
                {
                    IsSuccessful = false,
                    ResultMessage = "You missed",
                    GameFinished = false
                };
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
