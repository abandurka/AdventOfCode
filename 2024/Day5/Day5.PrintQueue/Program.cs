using AOC.Shared;

namespace Day5.PrintQueue;

class Program
{
    static void Main(string[] args)
    {
        var lines = FileParser.LoadLines(StringConstants.DefaultPath);
        var init = Day5Solver.GetInitialData(lines);

        var count = 0;
        var fixedSumm = 0;
        foreach (var page in init.pages)
        {
            var appliedRules = init.rules.Where(x => x.CanApply(page)).ToList();
            if (appliedRules.All(x=> x.IsValid(page)))
            {
                count += page.GetMiddlePage;
                continue;
            }
            
            var fixedPages = page.FixPagesOrdering(appliedRules);
            fixedSumm += fixedPages.GetMiddlePage;
        }

        Console.WriteLine($"Ans is {count} / { fixedSumm}");
    }
}

public class Day5Solver
{
    public static (IReadOnlyCollection<Rule> rules, IReadOnlyCollection<PagesCollection> pages) GetInitialData(
        IEnumerable<string> lines)
    {
        var rules = lines.TakeWhile(l => l != "").Select(Rule.Parse).ToList();
        var pages = lines.SkipWhile(l => l != "").Skip(1).Select(PagesCollection.Parse).ToList();
        
        return new ValueTuple<IReadOnlyCollection<Rule>, IReadOnlyCollection<PagesCollection>>(rules, pages);
    }
}

public class PagesCollection(List<int> pages)
{
    public List<int> Pages { get; } = pages;

    public static PagesCollection Parse(string line) => new(line.Split(',').Select(int.Parse).ToList());

    public int GetMiddlePage => Pages.ElementAt(Pages.Count / 2);

    public PagesCollection FixPagesOrdering(IReadOnlyCollection<Rule> rules)
    {
        var newPages = pages.ToList();

        foreach (var rule in rules)
        {
            if (!rule.IsValid(newPages))
            {
                newPages = rule.Apply(newPages);
            }
        }
        
        var np = new PagesCollection(newPages);
        if (rules.All(x => x.IsValid(newPages)))
        {
            return np;
        }
        
        return np.FixPagesOrdering(rules);
    }
}

public class Rule(int leftPage, int rightPage)
{
    public int LeftPage { get; } = leftPage;
    public int RightPage { get; } = rightPage;

    public static Rule Parse(string line)
    {
        var parts = line.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var leftPage = int.Parse(parts[0]);
        var rightPage = int.Parse(parts[1]);
        
        return new(leftPage, rightPage);
    }

    public bool CanApply(PagesCollection pages) =>
        pages.Pages.Contains(LeftPage) 
        && pages.Pages.Contains(RightPage);

    public bool IsValid(PagesCollection pages) => 
        pages.Pages.IndexOf(LeftPage) < pages.Pages.IndexOf(RightPage);
    public bool IsValid(List<int> pages) => 
        pages.IndexOf(LeftPage) < pages.IndexOf(RightPage);

    public List<int> Apply(List<int> pages)
    {
        var li = pages.IndexOf(LeftPage);
        var ri = pages.IndexOf(RightPage);
        pages.RemoveAt(li);
        pages.Insert(li, RightPage);
        pages.RemoveAt(ri);
        pages.Insert(ri, LeftPage);
        return pages;
    }
}