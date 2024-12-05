namespace AOC.Shared;

public class FileParser
{
    public static IEnumerable<string> LoadLines(string location)
    {
        var lines = File.ReadLines(location);

        foreach (var line in lines)
        {
            yield return line;
        }
    }

    public static IEnumerable<T> LoadLines<T>(string location, Func<string, T> parser) => 
        LoadLines(location).Select(parser);
}