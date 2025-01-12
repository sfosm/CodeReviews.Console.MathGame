using MathGame.Models;

namespace MathGame.Controllers;

public class GameController
{
    private DateTime _startTime;
    private GameType _gameType;
    private int _score;
    private int _lives;
    private TimeSpan _gameTime;
    private MathOperation? _currentOperation;

    public int Score => _score;
    public TimeSpan? GameTime => _gameTime;

    public GameController(DateTime startTime, GameType gameType)
    {
        _startTime = startTime;
        _gameType = gameType;
        _score = 0;
        _lives = 3;
    }

    public void StartGame()
    {
        for (int i = 0; i < 10; i++)
        {
            GenerateTask();
            var userInput = Console.ReadLine();
            int answer;
            var parse = Int32.TryParse(userInput, out answer);
            if (parse)
            {
                CheckAnswer(answer);
            }
            else
            {
                Console.WriteLine("Illegal input");
            }

            if (_lives == 0)
            {
                Console.WriteLine("You lost all your lives");
                break;
            }
        }
        Console.WriteLine($"Score: {_score}");
        var time = DateTime.Now - _startTime;
        Console.WriteLine($"Game time: {time:g}");
        _gameTime = time;
    }

    private void CheckAnswer(int answer)
    {
        if (answer == _currentOperation?.Answer)
        {
            _score += 10;
            Console.WriteLine("Correct Answer!");
        }
        else
        {
            Console.WriteLine("Wrong Answer!");
            _lives--;
        }
    }

    private void GenerateTask()
    {
        _currentOperation = MathOperationController.GenerateMathOperation(_gameType);
        string operationChar = _gameType switch
        {
            GameType.Add => "+",
            GameType.Subtract => "-",
            GameType.Divide => "/",
            GameType.Multiply => "*"
        };
        Console.WriteLine($"{_currentOperation.X} {operationChar} {_currentOperation.Y} = {_currentOperation.Z}");
    }
}