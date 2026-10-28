namespace RefactoringPlayground.CodeStyle.Formatting;

// Wrapping options (csharp_preserve_single_line_statements / csharp_preserve_single_line_blocks)
// are formatting rules, reported as IDE0055 and applied by 'dotnet format whitespace' or Code Cleanup.
// IDE2000 / IDE2001 / IDE2003 are the experimental blank-line and embedded-statement rules.
public static class WrappingExamples
{
    // REFACTOR [IDE0055]: Put each statement on its own line (csharp_preserve_single_line_statements = false)
    public static int Add(int a, int b)
    {
        int sum = a; sum += b; return sum;
    }

    // REFACTOR [IDE0055]: Expand a single-line block (csharp_preserve_single_line_blocks = false)
    public static string Sign(int value)
    {
        if (value < 0) { return "negative"; }
        if (value > 0) { return "positive"; }
        return "zero";
    }

    // REFACTOR [IDE2001]: Embedded statements must be on their own line
    public static int Clamp(int value, int max)
    {
        if (value > max) value = max;
        return value;
    }

    // REFACTOR [IDE0055]: Fix formatting (spacing, indentation and operators)
    public static int  Multiply( int a,int b )
    {
          return a*b ;
    }



    // REFACTOR [IDE2000]: Avoid multiple blank lines (there are three above this comment)
    public static string Join(IEnumerable<string> parts)
    {
        return string.Join(", ",
            parts.Where(part => part.Length > 0)
                 .Select(part => part.Trim())
                 .OrderBy(part => part));
    }

    // REFACTOR [IDE2003]: Blank line required between a block and the next statement
    public static int Total(IEnumerable<int> values)
    {
        int total = 0;
        foreach (var value in values)
        {
            total += value;
        }
        return total;
    }
}
