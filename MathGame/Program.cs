using MathGame.Controllers;
using MathGame.Models;

namespace MathGame;

class Program
{
    private static readonly List<string> Scores = new();
    static void Main()
    {
        bool shouldExit = false;
        while (!shouldExit)
        {
            GameType? gameType = null;
            Console.WriteLine("MENU: \n 1 - ADD \n 2 - SUBTRACT \n 3 - MULTIPLY \n 4 - DIVIDE \n 5 - SCORES \n 6 - EXIT \n Please choose a number");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    gameType = GameType.Add;
                    break;
                case "2":
                    gameType = GameType.Subtract;
                    break;
                case "3":
                    gameType = GameType.Multiply;
                    break;
                case "4":
                    gameType = GameType.Divide;
                    break;
                case "5":
                    DisplayLastScores();
                    break;
                case "6":
                    shouldExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            if (gameType != null)
            {
                var gameLogic = new GameController(DateTime.Now, (GameType)gameType);
                gameLogic.StartGame();
                Scores.Add($"Score: {gameLogic.Score} GameTime: {gameLogic.GameTime:g}");
            }
        }
    }

    static void DisplayLastScores()
    {
        Console.WriteLine("Last Scores:");
        foreach (var score in Scores)
        {
            Console.WriteLine(score);
        }
    }
}