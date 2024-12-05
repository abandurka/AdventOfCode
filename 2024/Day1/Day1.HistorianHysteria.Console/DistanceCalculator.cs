using AOC.Shared;

namespace Day1.HistorianHysteria.Console;

public class DistanceCalculator
{
    public static (IReadOnlyCollection<int> l, IReadOnlyCollection<int> r) LoadLocations(string location)
    {
        var data = FileParser.LoadLines(location, s => DataParsers.AsInt(s));

        var left = new List<int>();
        var right = new List<int>();
        foreach (var line in data)
        {
            left.Add(line.ElementAt(0));
            right.Add(line.ElementAt(1));
        }
        
        left.Sort();
        right.Sort();
        return (left, right);
    }

    public static int GetDistance(int l, int r) => Math.Abs(l - r);

    public static int GetDistanceTotal(IReadOnlyCollection<int> l, IReadOnlyCollection<int> r)
    {
        if (l.Count != r.Count)
        {
            throw new ArgumentException("The number of locations does not match.");
        }

        var totalDistance = 0;
        for (int i = 0; i < l.Count; i++)
        {
            totalDistance += GetDistance(l.ElementAt(i), r.ElementAt(i));
        }
        
        return totalDistance;
    }
    
    public static int GetSimularity(IReadOnlyCollection<int> l, IReadOnlyCollection<int> r)
    {
        var scores = r.GroupBy(x=> x, (k, v) => (k, Count: v.Count())).ToDictionary(x=> x.k, v=> v.Count);

        var sumularuty = 0;
        for (int i = 0; i < l.Count; i++)
        {
            var item = l.ElementAt(i);
            sumularuty += scores.GetValueOrDefault(item, 0) * item;
        }
        
        return sumularuty;
    }
}