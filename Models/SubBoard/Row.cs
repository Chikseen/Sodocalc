public class Row
{
    private List<int?> _SubRow = new();

    public Row(Board board, int y)
    {
        _SubRow = board.Field.Field[y]; ;
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

    public List<int?> GetList()
    {
        return _SubRow;
    }

    public bool Contains(int number)
    {
        return _SubRow.Contains(number);
    }
}