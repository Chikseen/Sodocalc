using System.Diagnostics;

public class Solver
{
    private Board _CurrentBoard;
    private Board _Original;
    private List<Posistion> _SetPositions;

    public Solver(Board board)
    {
        _CurrentBoard = board;
        _Original = board;
        _SetPositions = new();
    }

    public Board SolveBoard()
    {
        var solverWatch = Stopwatch.StartNew();

        FindMissing();

        Console.WriteLine($"Solver needed {solverWatch.ElapsedMilliseconds}ms to execute");
        _CurrentBoard.PrintBoard();
        return _CurrentBoard;
    }

    private void FindMissing()
    {
        while (BoardConatinsNull())
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int? number = _CurrentBoard.Field.Field[x][y];
                    if (number is null)
                        FillPos(x, y);
                }
            }
        }
    }

    private void FillPos(int x, int y)
    {
        int? newNumber = GetPossibleMember(x, y);

        do
        {
            if (newNumber is null)
            {
                if (_SetPositions.Count > 0)
                {
                    Posistion pos = _SetPositions.Last();
                    _CurrentBoard.Field.Field[pos.X][pos.Y] = null;
                    _SetPositions.Remove(pos);
                }
                newNumber = GetPossibleMember(x, y, true); // Get Random Number to prevent Infinity loops
            }
            else
            {
                _SetPositions.Add(new(x, y, newNumber));
                _CurrentBoard.Field.Field[x][y] = newNumber;
            }
        }
        while (newNumber is null);
    }

    private int? GetPossibleMember(int x, int y, bool getAsRandom = false)
    {
        Row row = new(_CurrentBoard, x);
        Column col = new(_CurrentBoard, y);
        Box box = new(_CurrentBoard, x / 3, y / 3);

        for (int i = 1; i <= 9; i++)
        {
            int number = i;

            if (getAsRandom)
                number = new Random().Next(1, 10);

            if (!(row.Contains(number) || col.Contains(number) || box.Contains(number)))
            {
                return number;
            }
        }
        return null;
    }

    private bool BoardConatinsNull()
    {
        foreach (List<int?> row in _CurrentBoard.Field.Field)
        {
            if (row.Contains(null))
                return true;
        }
        return false;
    }
}