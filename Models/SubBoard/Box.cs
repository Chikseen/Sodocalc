public class Box
{
    private List<List<int?>> _SubField = new();

    public Box(Board board, int boxPosX, int boxPosY)
    {
        for (int i = boxPosX * 3; i < (boxPosX * 3) + 3; i++)
        {
            _SubField.Add(new List<int?>());
            for (int j = boxPosY * 3; j < (boxPosY * 3) + 3; j++)
            {
                _SubField[i % 3].Add(board.Field[i][j]);
            }
        }
        // PrintBox();
    }

    public bool IsValid()
    {
        string value = "";
        for (int i = 0; i < 3; i++)
        {
            value += String.Join("", _SubField[i]);
        }

        bool isValid = Checker.Check(value);
        if (!isValid)
            PrintBox();
        return isValid;
    }

    public void PrintBox()
    {
        String output = "";
        for (int i = 0; i < 3; i++)
        {
            List<int?> row = _SubField[i];

            for (int j = 0; j < 3; j++)
            {
                int? col = row[j];

                output += col;
                if (j < row.Count - 1)
                    output += " | ";
            }
            if (i < 2)
                output += new String(' ', FieldSize.y * i) + "\n";
        }
        Console.WriteLine(output);
    }
}