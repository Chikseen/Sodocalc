public class Posistion
{
    public int X;

    public int Y;

    public int? Value;

    public Posistion(int x, int y, int? value = null)
    {
        X = x;
        Y = y;
        Value = value;
    }
}