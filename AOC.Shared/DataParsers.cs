namespace AOC.Shared;

public static class DataParsers
{
    public static int[] AsInt(
        string str,
        string separator = " ",
        StringSplitOptions opts = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries) 
        => 
            str.Split(separator, opts).Select(int.Parse).ToArray();
}
