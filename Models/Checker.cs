public class Checker
{
    public static bool Check(string value, bool strict = false)
    {
        if (strict)
            if (value.Count() != 9)
                return false;

        for (int i = 1; i <= 9; i++)
        {
            if (!value.Contains(i.ToString()))
            {
                return false;
            }
        }
        return true;
    }

    public Board board;
    public Checker(Board board)
    {
        this.board = board;
    }

    public bool IsValid()
    {
        bool isvalid = true;
        for (int i = 0; i < FieldSize.y; i++)
        {
            if (!CheckRow(i))
            {
                Console.WriteLine($"Row: {i + 1} -> is wrong \n");
                isvalid = false;
            }

            if (!CheckColumn(i))
            {
                Console.WriteLine($"Column: {i + 1} -> is wrong \n");
                isvalid = false;
            }
        }

        for (int i = 0; i < FieldSize.y / 3; i++)
        {
            for (int j = 0; j < FieldSize.x / 3; j++)
            {
                if (!CheckBox(i, j))
                {
                    Console.WriteLine($"Box: {i + 1}, {j + 1} -> is wrong \n");
                    isvalid = false;
                }
            }
        }

        if (isvalid)
            Console.WriteLine("No Errors 🥳");
        return isvalid;
    }

    private bool CheckBox(int i, int j)
    {
        Box b = new Box(board, i, j);
        return b.IsValid();
    }

    private bool CheckRow(int i)
    {
        Row r = new Row(board, i);
        return r.IsValid();
    }

    private bool CheckColumn(int y)
    {
        Column r = new Column(board, y);
        return r.IsValid();
    }
}