public static class Checker
{
    public static bool Check(string value, bool strict = false)
    {
        if (strict)
            if (value.Count() != 9)
                return false;

        for (int i = 0; i < 9; i++)
        {
            if (!value.Contains(i.ToString()))
                return false;
        }

        return true;
    }
}