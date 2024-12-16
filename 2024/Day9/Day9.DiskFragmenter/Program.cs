// See https://aka.ms/new-console-template for more information

using AOC.Shared;

Console.WriteLine("Day 9: Disk Fragmenter");
Console.WriteLine("----------------------");

var line = File.ReadAllText(StringConstants.DefaultPath);

var mass = GetInputMass(line);

var currEmptyIndex = mass.FindIndex(x => !x.HasValue);

for (int i = mass.Count - 1; i >=0 && currEmptyIndex < i; i--)
{
    if (mass[i].HasValue)
    {
        mass[currEmptyIndex] = mass[i];
        mass[i] = null;
        do
        {
            currEmptyIndex++;
        } while (currEmptyIndex < mass.Count && mass[currEmptyIndex].HasValue);
    }
}

var sum = 0L;
var index = 0;
while (mass[index].HasValue)
{
    sum += mass[index].Value * index;
    index++;
}

Console.WriteLine(sum);

List<int?> GetInputMass(string s)
{
    var ints = new List<int?>(s.Length * 9);
    for (int i = 0; i < s.Length - 1; i++)
    {   
        var isEven = s[i] % 2 == 0;
        var num = int.Parse(s.Substring(i, 1));
        for (int j = 0; j < num; j++)
        {
            ints.Add(isEven ? null : num);
        }
    }

    return ints;
}
