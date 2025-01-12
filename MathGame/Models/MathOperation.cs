namespace MathGame.Models;

public class MathOperation(int? x, int? y, int? z, int? answer)
{
    public int? X => x;

    public int? Y => y;

    public int? Z => z;

    public int? Answer => answer;
    
}