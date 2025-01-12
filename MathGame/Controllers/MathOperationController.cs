using MathGame.Models;

namespace MathGame.Controllers;

public static class MathOperationController
{
    public static MathOperation GenerateMathOperation(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Add:
                return GenerateAddOperation();
            case GameType.Subtract:
                return GenerateSubtractOperation();
            case GameType.Multiply:
                return GenerateMultiplyOperation();
            default:
                return GenerateDivideOperation();
        }
    }
    
    private static MathOperation GenerateAddOperation()
    {
        int? x = null, y = null, z = null, answer = null;
        var random = new Random();
        switch (random.Next(1, 3))
        {
            case 1:
                x = null;
                y = random.Next(1, 99);
                z = random.Next(y ?? 1, 100);
                answer = z - y;
                break;
            case 2:
                x = random.Next(1, 99);
                y = null;
                z = random.Next(x ?? 1, 100);
                answer = z - x;
                break;
            case 3:
                do
                {
                    x = random.Next(1, 99);
                    y = random.Next(1, 99);
                } while (x + y > 100);
                z = null;
                answer = x + y;
                break;
        }
        return new MathOperation(x, y, z, answer);
    }
    
    private static MathOperation GenerateSubtractOperation()
    {
        int? x = null, y = null, z = null, answer = null;
        var random = new Random();
        switch (random.Next(1, 3))
        {
            case 1:
                do
                {
                    y = random.Next(1, 99);
                    z = random.Next(1, 99); 
                } while(y + z > 100 || y + z < 0);
                x = null;
                answer = z + y;
                break;
            case 2:
                do
                {
                    x = random.Next(2, 100);
                    z = random.Next(1, 99); 
                } while (x < z);
                y = null;
                answer = x - z;
                break;
            case 3:
                do
                {
                    x = random.Next(1, 99);
                    y = random.Next(1, 99);
                } while (x - y < 0 || y > x);
                z = null;
                answer = x - y;
                break;
        }
        return new MathOperation(x, y, z, answer);
    }
    
    private static MathOperation GenerateMultiplyOperation()
    {
        int? x = null, y = null, z = null, answer = null;
        var random = new Random();
        switch (random.Next(1, 3))
        {
            case 1:
                do
                {
                    y = random.Next(1, 100);
                    z = random.Next(1, 100); 
                } while(z % y == 0);
                x = null;
                answer = z / y;
                break;
            case 2:
                do
                {
                    x = random.Next(1, 100);
                    z = random.Next(1, 100); 
                } while (z % x != 0);
                y = null;
                answer = z / x;
                break;
            case 3:
                do
                {
                    x = random.Next(1, 99);
                    y = random.Next(1, 99);
                } while (x * y <= 100);
                z = null;
                answer = x - y;
                break;
        }
        return new MathOperation(x, y, z, answer);
    }
    
    private static MathOperation GenerateDivideOperation()
    {
        int? x = null, y = null, z = null, answer = null;
        var random = new Random();
        switch (random.Next(1, 3))
        {
            case 1:
                do
                {
                    y = random.Next(1, 100);
                    z = random.Next(1, 100); 
                } while(z * y < 100);
                x = null;
                answer = z * y;
                break;
            case 2:
                do
                {
                    x = random.Next(1, 100);
                    z = random.Next(1, 100);
                } while (x % z != 0 && x < z);
                y = null;
                answer = x / z;
                break;
            case 3:
                do
                {
                    x = random.Next(1, 99);
                    y = random.Next(1, 99);
                } while (x % y != 0);
                z = null;
                answer = x / y;
                break;
        }
        return new MathOperation(x, y, z, answer);
    }
}