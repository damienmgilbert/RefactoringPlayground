namespace RefactoringPlayground.CodeStyle.CodeBlock;

// Every statement below has a single-line body without braces on purpose.
// csharp_prefer_braces = true means "always", even when the body is one line.
public static class BraceExamples
{
    // REFACTOR [IDE0011]: Add braces to 'if' / 'else if' / 'else', even for one-line bodies
    public static string Describe(Order order)
    {
        if (order.Lines.Count == 0)
            return "Empty";
        else if (order.Lines.Count == 1)
            return "Single line";
        else
            return "Multiple lines";
    }

    // REFACTOR [IDE0011]: Add braces to 'foreach'
    public static decimal Sum(IEnumerable<OrderLine> lines)
    {
        decimal total = 0m;
        foreach (var line in lines)
            total += line.Quantity * line.UnitPrice;

        return total;
    }

    // REFACTOR [IDE0011]: Add braces to 'for'
    public static int SumTo(int limit)
    {
        int sum = 0;
        for (int i = 1; i <= limit; i++)
            sum += i;

        return sum;
    }

    // REFACTOR [IDE0011]: Add braces to 'while'
    public static int CountDigits(int value)
    {
        int digits = 0;
        while (value != 0)
        {
            value /= 10;
            digits++;
        }

        while (digits > 100)
            digits--;

        return digits;
    }

    // REFACTOR [IDE0011]: Add braces to 'do' / 'while'
    public static int Halve(int value)
    {
        do
            value /= 2;
        while (value > 100);

        return value;
    }

    // REFACTOR [IDE0011]: Add braces to 'using' and 'lock'
    private static readonly Lock _gate = new();

    public static string ReadFirstLine(string text)
    {
        using (var reader = new StringReader(text))
            return reader.ReadLine() ?? string.Empty;
    }

    public static int Increment(ref int counter)
    {
        lock (_gate)
            counter++;

        return counter;
    }

    // REFACTOR [IDE0011]: Add braces to a guard clause (keep the throw/return on its own braces)
    public static void Validate(Customer customer)
    {
        if (customer.Name is null)
            throw new ArgumentException("Name is required.", nameof(customer));
    }
}
