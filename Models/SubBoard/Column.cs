public class Column
{
    private List<int?> _SubColumn = new();

    public Column(Board board, int y)
    {
        for (int i = 0; i < FieldSize.y; i++)
        {
            _SubColumn.Add(board.Field.Field[i][y]);
        }
    }

    public bool IsValid()
    {
        bool isValid = Checker.Check(String.Join("", _SubColumn));
        if (!isValid)
            PrintColumn();
        return isValid;
    }

    public void PrintColumn()
    {
        Console.WriteLine(String.Join(",", _SubColumn));
    }

    public List<int?> GetList()
    {
        return _SubColumn;
    }

    public bool Contains(int number)
    {
        return _SubColumn.Contains(number);
    }
}