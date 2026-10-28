namespace RefactoringPlayground.CodeStyle.UnnecessaryCode;

public class UnusedCodeExamples
{
    // REFACTOR [IDE0052]: Remove unread private member (assigned but never read)
    private string? _lastValue;

    public void Remember(string value)
    {
        _lastValue = value;
    }

    // REFACTOR [IDE0051]: Remove unused private member
    private static int Helper(int value)
    {
        return value + 1;
    }

    // REFACTOR [IDE0060]: Remove unused parameter ('unused')
    public static int Add(int a, int b, int unused)
    {
        return a + b;
    }

    // REFACTOR [IDE0058]: Remove unused expression value (the result of 'Add' is thrown away)
    public static void Record(HashSet<string> seen, string value)
    {
        seen.Add(value);
    }

    // REFACTOR [IDE0059]: Unnecessary assignment of a value to 'total'
    public static int Compute(int a, int b)
    {
        int total = 0;
        total = a + b;
        return total;
    }
}
