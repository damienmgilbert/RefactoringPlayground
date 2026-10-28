namespace RefactoringPlayground.Examples;

public delegate bool TryParser<T>(string text, out T result);

public class DelegateExamples
{
    public event EventHandler? Changed;

    // REFACTOR [IDE1005]: Delegate invocation can be simplified ('Changed?.Invoke(this, EventArgs.Empty)')
    public void RaiseChanged()
    {
        var handler = Changed;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }

    // REFACTOR [IDE1005]: same rule, direct form
    public void RaiseChangedDirect()
    {
        if (Changed != null)
        {
            Changed(this, EventArgs.Empty);
        }
    }

    // REFACTOR [IDE0200]: Remove unnecessary lambda expression ('Where(string.IsNullOrEmpty)')
    public static IEnumerable<string?> EmptyValues(IEnumerable<string?> values)
    {
        return values.Where(v => string.IsNullOrEmpty(v));
    }

    // REFACTOR [IDE0200]: Remove unnecessary lambda expression ('ForEach(writer.WriteLine)')
    public static void LogAll(List<string> messages, TextWriter writer)
    {
        messages.ForEach(m => writer.WriteLine(m));
    }

    // REFACTOR [IDE0039]: Use local function instead of lambda
    public static int Doubled(int value)
    {
        Func<int, int> twice = x => x * 2;
        return twice(value);
    }

    // REFACTOR [IDE0062]: Make local function 'static' (it captures nothing)
    public static int SumOfSquares(int a, int b)
    {
        return Square(a) + Square(b);

        int Square(int n) => n * n;
    }

    // REFACTOR [IDE0320]: Make anonymous function 'static' (it captures nothing)
    public static IEnumerable<decimal> LineTotals(Order order)
    {
        return order.Lines.Select(l => l.Quantity * l.UnitPrice);
    }

    // REFACTOR [IDE0053]: Use expression body for lambda ('amount => amount * rate')
    public static Func<decimal, decimal> TaxCalculator(decimal rate)
    {
        return amount =>
        {
            return amount * rate;
        };
    }

    // REFACTOR [IDE0350] (C# 14): Use implicitly typed lambda ('(text, out result) => ...')
    public static TryParser<int> IntParser()
    {
        return (string text, out int result) => int.TryParse(text, out result);
    }
}
