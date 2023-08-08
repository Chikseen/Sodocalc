public class Solver
{
    public Board board;
    public Solver(Board board)
    {
        this.board = board;
    }

    public bool IsValid()
    {
        for (int i = 0; i < FieldSize.y; i++)
        {
            for (int j = 0; j < FieldSize.x; j++)
            {
                Console.WriteLine("ChecPos: " + i + " " + j + " " + board.Fiele[i][j]);
                if (!CheckBox(i, j))
                    return false;

                if (!CheckRow(i))
                    return false;

                if (!CheckColumn(j))
                    return false;
            }
        }

        return true;
    }

    private bool CheckBox(int i, int j)
    {
        Box b = new Box(board, i, j);
        b.IsValid();
        return true;
    }
    private bool CheckRow(int i)
    {
        return true;
    }
    private bool CheckColumn(int y)
    {
        return true;
    }
}