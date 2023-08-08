public class Column
{
    private List<int?> _SubColumn = new();

    public Column(Board board, int y)
    {
        for (int i = 0; i < FieldSize.y; i++)
        {
            _SubColumn.Add(board.Field[i][y]);
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
}