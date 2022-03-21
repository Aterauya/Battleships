using Battleships.Common;
using Battleships.Common.Enums;
using Battleships.Common.Ships;
using Battleships.Service.Interfaces;
using Battleships.Service.Services;
using Battleships.Service.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IGameService, GameService>()
                .AddTransient<IBoardBuilder, BoardBuilder>()
                .AddTransient<IShipPlacer, ShipPlacer>()
                .AddTransient<IHorizontalShipPlacerStrategy, HorizontalShipPlacerStrategy>()
                .AddTransient<IVerticalShipPlacerStrategy, VerticalShipPlacerStrategy>()
                .BuildServiceProvider();

            var gameService = serviceProvider.GetService<IGameService>();
            var ships = new List<ShipBase>();
            ships.Add(new Battleship(OrientationEnum.Horizontal));
            ships.Add(new Destroyer(OrientationEnum.Vertical));
            ships.Add(new Destroyer(OrientationEnum.Horizontal));
            var startedResult = gameService.StartGame(ships, 10, 10);
            if (startedResult.IsSuccessful)
            {
                Console.WriteLine("Game has started\n" +
                    "Please target youe first cell. Eg 'A1'");
                var inProgress = true;
                do
                {
                    var guess = Console.ReadLine();

                    try
                    {
                        var guessNumber = Convert.ToInt32(string.Concat(guess.Where(i => char.IsDigit(i))));
                        var guessLetter = guess.Where(i => !char.IsDigit(i)).FirstOrDefault();
                        if (char.IsLetter(guessLetter) && guessNumber != 0)
                        {
                            // Convert letter to its index in the alphabet
                            var guessX = char.ToUpper(guessLetter) - 64;
                            var guessResult = gameService.ProcessGuess(guessX - 1, guessNumber - 1);
                            inProgress = !guessResult.GameFinished;

                            if (!guessResult.IsSuccessful)
                            {
                                Console.WriteLine(guessResult.ResultMessage);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Guess is not in correct format. Please try again");
                        }

                    }
                    catch (FormatException exception)
                    {
                        // Log exception
                        Console.WriteLine("Guess is not in correct format. Please try again");
                    }
                }
                while (inProgress);
            }
        }
    }
}

