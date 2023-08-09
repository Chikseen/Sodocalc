using System.Text.Json;

public class Board
{
    public FieldModel Field { get; set; }

    public Board()
    {
        Field = new();
    }

    public void PrintBoard()
    {
        String output = "";
        for (int i = 0; i < FieldSize.x; i++)
        {
            List<int?> row = Field.Field[i];

            for (int j = 0; j < FieldSize.y; j++)
            {
                int? col = row[j];

                if (col is null)
                    output += " ";
                else
                    output += col;

                if (j < row.Count - 1)
                    if (j % 3 == 2)
                        output += "  ||  ";
                    else
                        output += " | ";
            }
            if (i < Field.Field.Count - 1 && i % 3 == 2)
                output += $"\n{new String('-', 11)}  {new String('-', 13)}  {new String('-', 11)}    ";
            output += new String(' ', FieldSize.y * i) + "\n";
        }
        Console.WriteLine(output);
    }

    public void PrintAsArrayTemplate()
    {
        String output = "new[] { \n";

        foreach (var item in Field.Field)
        {
            output += " \t new int[] {";
            output += String.Join(",", item);
            output += "}, \n";
        }
        output += "};";

        Console.WriteLine(output);
    }

    public void FillBoard(string? preset = null)
    {
        if (preset is not null)
        {
            Field = JsonSerializer.Deserialize<FieldModel>(preset)!;
        }
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
            Field.Field = newField;
        }
    }
}