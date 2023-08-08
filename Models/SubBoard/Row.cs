public class Row
{
    private List<int?> _SubRow = new();

    public Row(Board board, int y)
    {
        _SubRow = board.Field[y]; ;
    }

    public bool IsValid()
    {
        bool isValid = Checker.Check(String.Join("", _SubRow));
        if (!isValid)
            PrintRow();
        return isValid;
    }

    public void PrintRow()
    {
        Console.WriteLine(String.Join(",", _SubRow));
    }
}