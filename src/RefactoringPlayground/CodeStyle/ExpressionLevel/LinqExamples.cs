using System.Collections;

namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class LinqExamples
{
    // REFACTOR [IDE0120]: Simplify LINQ expression ('lines.Any(l => l.Quantity > 5)')
    public static bool HasBulkLine(IEnumerable<OrderLine> lines)
    {
        return lines.Where(l => l.Quantity > 5).Any();
    }

    // REFACTOR [IDE0120]: Simplify LINQ expression ('lines.First(l => ...)')
    public static OrderLine FirstExpensive(IEnumerable<OrderLine> lines)
    {
        return lines.Where(l => l.UnitPrice > 100m).First();
    }

    // REFACTOR [IDE0120]: Simplify LINQ expression ('lines.FirstOrDefault(l => ...)')
    public static OrderLine? FirstOrNone(IEnumerable<OrderLine> lines, string sku)
    {
        return lines.Where(l => l.Sku == sku).FirstOrDefault();
    }

    // REFACTOR [IDE0120]: Simplify LINQ expression ('lines.Count(l => ...)')
    public static int CountCheap(IEnumerable<OrderLine> lines)
    {
        return lines.Where(l => l.UnitPrice < 10m).Count();
    }

    // REFACTOR [IDE0121]: Simplify LINQ type check and cast ('items.OfType<int>()')
    public static IEnumerable<int> Integers(IEnumerable<object> items)
    {
        return items.Where(item => item is int).Cast<int>();
    }

    // REFACTOR [IDE0121]: Simplify LINQ type check and cast ('items.OfType<string>()')
    public static IEnumerable<string> Strings(IEnumerable<object> items)
    {
        return items.Where(item => item is string).Select(item => (string)item);
    }

    // REFACTOR [IDE0121]: Simplify LINQ type check and cast ('shapes.OfType<Circle>()')
    public static double TotalCircleArea(IEnumerable<Shape> shapes)
    {
        return shapes.Where(s => s is Circle).Select(s => (Circle)s).Sum(c => Math.PI * c.Radius * c.Radius);
    }

    // REFACTOR [IDE0220]: Add explicit cast in foreach loop ('in names.Cast<string>()')
    // dotnet_style_prefer_foreach_explicit_cast_in_source = when_strongly_typed flags generic collections only.
    public static int TotalLength(List<object> names)
    {
        int total = 0;
        foreach (string name in names)
        {
            total += name.Length;
        }

        return total;
    }

    // REFACTOR [IDE0220]: Add explicit cast in foreach loop (a base type iterated as a derived type)
    public static double TotalWidth(IEnumerable<Shape> shapes)
    {
        double total = 0;
        foreach (Rectangle rectangle in shapes)
        {
            total += rectangle.Width;
        }

        return total;
    }

    // Not flagged by default: ArrayList is a legacy (non-generic) collection.
    // Set dotnet_style_prefer_foreach_explicit_cast_in_source = always to flag it as well.
    public static int TotalLengthLegacy(ArrayList names)
    {
        int total = 0;
        foreach (string name in names)
        {
            total += name.Length;
        }

        return total;
    }
}
