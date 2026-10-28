namespace RefactoringPlayground.Examples;

public static class AssignmentExamples
{
    // REFACTOR [IDE0054]: Use compound assignment ('total += ...', 'total *= 1.08m')
    // REFACTOR [refactoring]: Convert 'foreach' to LINQ
    public static decimal SumLines(IEnumerable<OrderLine> lines)
    {
        decimal total = 0m;
        foreach (var line in lines)
        {
            total = total + line.Quantity * line.UnitPrice;
        }

        total = total * 1.08m;
        return total;
    }

    // REFACTOR [IDE0054]: Use compound assignment ('result += ...')
    // REFACTOR [refactoring]: Convert to interpolated string
    public static string JoinNames(IEnumerable<string> names)
    {
        var result = "";
        foreach (var name in names)
        {
            result = result + name + ", ";
        }

        return result;
    }

    // REFACTOR [IDE0180]: Use tuple to swap values ('(a, b) = (b, a);')
    public static void SwapValues(ref int a, ref int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    // REFACTOR [IDE0018]: Inline variable declaration ('out int parsed' / 'out var parsed')
    public static int ParseOrDefault(string text)
    {
        int parsed;
        if (int.TryParse(text, out parsed))
        {
            return parsed;
        }

        return -1;
    }

    // Helper that returns a named tuple for the deconstruction example below.
    public static (decimal Min, decimal Max) GetPriceRange(IReadOnlyList<OrderLine> lines)
    {
        if (lines.Count == 0)
        {
            return (0m, 0m);
        }

        return (lines.Min(l => l.UnitPrice), lines.Max(l => l.UnitPrice));
    }

    // REFACTOR [IDE0042]: Deconstruct variable declaration ('var (min, max) = GetPriceRange(lines);')
    public static decimal PriceSpread(IReadOnlyList<OrderLine> lines)
    {
        var range = GetPriceRange(lines);
        return range.Max - range.Min;
    }

    // REFACTOR [IDE0059]: Unnecessary assignment of a value to 'net'
    public static decimal NetPrice(decimal gross)
    {
        decimal net = 0m;
        net = gross / 1.2m;
        return net;
    }
}
