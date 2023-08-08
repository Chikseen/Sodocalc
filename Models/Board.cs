public class Board
{
    public List<List<int?>> Fiele { get; set; }

    public Board()
    {
        Fiele = NewBoard();
    }

    public void PrintBoard()
    {
        String output = "";
        for (int i = 0; i < FieldSize.x; i++)
        {
            List<int?> row = Fiele[i];

            for (int j = 0; j < FieldSize.y; j++)
            {
                int? col = row[j];

                output += col;
                if (j < row.Count - 1)
                    if (j % 3 == 2)
                        output += "  ||  ";
                    else
                        output += " | ";
            }
            if (i < Fiele.Count - 1 && i % 3 == 2)
                output += $"\n{new String('-', 11)}  {new String('-', 13)}  {new String('-', 11)}    ";
            output += new String(' ', FieldSize.y * i) + "\n";
        }
        Console.WriteLine(output);
    }

    public void FillBoard(List<List<int?>>? preset = null)
    {
        if (preset is not null)
            Fiele = preset;
        else
        {
            List<List<int?>>? newField = new();
            for (int i = 0; i < FieldSize.y; i++)
            {
                newField.Add(new List<int?>());
                for (int j = 0; j < FieldSize.x; j++)
                {
                    newField[i].Add(new Random().Next(1, 10));
                }
            }
            Fiele = newField;
        }
    }

    private List<List<int?>> NewBoard()
    {
        return Enumerable.Repeat<List<int?>>(Enumerable.Repeat<int?>(null, FieldSize.y).ToList(), FieldSize.x).ToList();
    }
}