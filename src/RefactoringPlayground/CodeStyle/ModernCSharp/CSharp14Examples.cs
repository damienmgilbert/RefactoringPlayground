namespace RefactoringPlayground.CodeStyle.ModernCSharp;

public class CSharp14Examples
{
    private string _displayName = string.Empty;

    // REFACTOR [C# 14 'field' keyword]: replace '_displayName' with 'field' and delete the private field
    //   public string DisplayName
    //   {
    //       get;
    //       set => field = value?.Trim() ?? string.Empty;
    //   }
    public string DisplayName
    {
        get => _displayName;
        set => _displayName = value?.Trim() ?? string.Empty;
    }

    // REFACTOR [C# 14 '?.=']: the null check + assignment can become 'customer?.Name = newName;'
    // (recent compilers offer this through IDE0031; otherwise apply it by hand)
    public static void Rename(Customer? customer, string newName)
    {
        if (customer != null)
        {
            customer.Name = newName;
        }
    }

    // REFACTOR [IDE0340]: Use unbound generic type in 'nameof' ('nameof(List<>)')
    public static string ListTypeName()
    {
        return nameof(List<int>);
    }
}

// MANUAL (C# 14): migrate these classic extension methods to an 'extension(Order order) { ... }' block,
// turning IsEmpty and Subtotal into extension properties.
public static class OrderExtensions
{
    public static bool IsEmpty(this Order order)
    {
        return order.Lines.Count == 0;
    }

    public static decimal Subtotal(this Order order)
    {
        return order.Lines.Sum(l => l.Quantity * l.UnitPrice);
    }
}

public class Counter
{
    // REFACTOR [IDE0330]: Prefer 'System.Threading.Lock' (and IDE0090: 'new()')
    private readonly object _gate = new object();
    private int _value;

    public int Increment()
    {
        lock (_gate)
        {
            _value++;
            return _value;
        }
    }
}
