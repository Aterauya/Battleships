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

            var gameServive = serviceProvider.GetService<IGameService>();
            var started = gameServive.StartGame();
            if(started)
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
                            inProgress = gameServive.ProcessGuess(guessX - 1, guessNumber - 1);
                        }
                        else
                        {
                            Console.WriteLine("Guess is not in correct format. Please try again");
                        }

                    } catch(FormatException exception)
                    {
                        // Log exception
                        Console.WriteLine("Guess is not in correct format. Please try again");
                    }
                }
                while(inProgress);
            }
        }
    }
}

