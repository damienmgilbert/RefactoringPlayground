using System.Text;

namespace RefactoringPlayground.CodeQuality.Performance;

public class PerformanceExamples
{
    // REFACTOR [CA1805]: Do not initialize unnecessarily (the default is already 0)
    private int _hits = 0;

    // REFACTOR [CA1822]: Mark members as static (nothing here uses 'this')
    public decimal AddTax(decimal amount)
    {
        return amount * 1.08m;
    }

    public int Hits => _hits++;

    // REFACTOR [CA1825]: Avoid zero-length array allocations ('Array.Empty<string>()' or '[]')
    public static string[] NoNames()
    {
        return new string[0];
    }

    // REFACTOR [CA1829]: Use the 'Count' property instead of the 'Count()' method
    public static int LineCount(List<OrderLine> lines)
    {
        return lines.Count();
    }

    // REFACTOR [CA1860]: Avoid 'Enumerable.Any()', prefer 'Count > 0' / 'Length > 0'
    public static bool HasLines(List<OrderLine> lines)
    {
        return lines.Any();
    }

    // REFACTOR [CA1861]: Avoid constant arrays as arguments (hoist to a static readonly field)
    public static string[] SplitList(string text)
    {
        return text.Split(new[] { ',', ';' });
    }

    // REFACTOR [CA1862]: Use the 'StringComparison' overload instead of lower-casing both sides
    public static bool SameSku(string a, string b)
    {
        return a.ToLowerInvariant() == b.ToLowerInvariant();
    }

    // REFACTOR [CA1834]: Use 'StringBuilder.Append(char)' for single-character strings
    public static string Dashes(int count)
    {
        var builder = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            builder.Append("-");
        }

        return builder.ToString();
    }

    // REFACTOR [CA1847]: Use 'string.Contains(char)' instead of 'string.Contains(string)'
    public static bool HasDash(string text)
    {
        return text.Contains("-");
    }
}
