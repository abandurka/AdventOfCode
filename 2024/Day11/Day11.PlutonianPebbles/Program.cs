// See https://aka.ms/new-console-template for more information

using AOC.Shared;

Console.WriteLine($"{DateTime.Now} - Day11.PlutonianPebbles");

var lines = FileParser
    .LoadLines(StringConstants.DefaultPath, s => DataParsers.AsInt(s))
    .SelectMany(x =>  x)
    .Select(x=> (long)x);

var likedList = new LinkedList<long>();
var stones = new LinkedList<Stone>();
foreach (var i in lines)
{
    likedList.AddLast(i);
    stones.AddLast(new Stone(i));
}

for (int i = 0; i < 25; i++)
{
    Blink1(likedList);
    Console.WriteLine($"Blink {i} times");
    Console.WriteLine($"zeros count: {likedList.Count(x => x == 0)} / {likedList.Count}");
    for (var i1 = 0; i1 < stones.Count; i1++)
    {
        stones.ElementAt(i1).Blink();
    }
}

Console.WriteLine($"{DateTime.Now} - Day11 Part 1. Result is {likedList.Count}");


// part2



//

static long[] ApplyRules(long value) =>
    value == 0 
        ? [1] 
        : TrySplit(value, out var result) 
            ? result 
            : [value * 2024];

static bool TrySplit(long i, out long[] o)
{
    var lenOfNumber = Math.Floor(Math.Log10((double)i) + 1);
    if (lenOfNumber % 2 == 0)
    {
        var splitter = (int) Math.Pow(10, (int)lenOfNumber / 2);
        o = [ i / splitter , i % splitter ];
        return true;
    }

    o = [];
    return false;
}

LinkedList<long> Blink1(LinkedList<long> linkedList)
{
    var current = linkedList.First;
    while (current is not null)
    {
        var i = current.Value;
        var r = ApplyRules(i);
        current.Value = r[0];
        if (r.Length == 2)
        {
            linkedList.AddAfter(current, r[1]);
            current = current.Next;
        }
        current = current!.Next;
    }

    return linkedList;
}

public class Stone  
{
    private long? _value;
    private int? ZeroPow = null;

    public LinkedList<Stone> Childs { get; } = new();

    public Stone(long value)
    {
        if (value == 0)
        {
            ZeroPow = 0;
        }
        else
        {
            _value = value;
        }
    }

    public void Blink()
    {
        foreach (var child in Childs)
        {
            child.Blink();
        }
        
        if (_value is null)
        {
            ZeroPow++;
            return;
        }

        if (TrySplit(_value.Value, out var result))
        {
            Childs.AddLast(new Stone(result[0]));
            var c = result[1];
            if (c == 0)
            {
                _value = null;
                ZeroPow = 0;
            }
            else
            {
                _value = c;
            }
            return;
        }

        _value *= 2024;
    }

    static bool TrySplit(long i, out long[] o)
    {
        var lenOfNumber = Math.Floor(Math.Log10(i) + 1);
        if (lenOfNumber % 2 == 0)
        {
            var splitter = (int) Math.Pow(10, (int)lenOfNumber / 2);
            o = [ i / splitter , i % splitter ];
            return true;
        }

        o = [];
        return false;
    }
}