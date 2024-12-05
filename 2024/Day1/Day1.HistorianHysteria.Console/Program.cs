namespace Day1.HistorianHysteria.Console;

internal class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Advent of Code 2024: Day 1");
        var (l, r) = DistanceCalculator.LoadLocations("../../../../input.txt");
        var distanceTotal = DistanceCalculator.GetDistanceTotal(l,r);
        System.Console.WriteLine($"Distance total: {distanceTotal}");
        var simulatity = DistanceCalculator.GetSimularity(l, r);
        
        System.Console.WriteLine($"Simularity: {simulatity}");
    }
}