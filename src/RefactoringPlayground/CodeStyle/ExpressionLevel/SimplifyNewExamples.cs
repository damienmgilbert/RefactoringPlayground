namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public class SimplifyNewExamples
{
    // REFACTOR [IDE0090]: 'new' expression can be simplified ('= new();')
    private readonly Dictionary<string, int> _counts = new Dictionary<string, int>();

    // REFACTOR [IDE0090]: 'new' expression can be simplified on a property initializer
    public List<Order> Orders { get; } = new List<Order>();

    // REFACTOR [IDE0090]: 'new' expression can be simplified for a local with an explicit type
    public static Customer CreateCustomer(string name)
    {
        Customer customer = new Customer();
        customer.Name = name;
        return customer;
    }

    // REFACTOR [IDE0090]: 'new' expression can be simplified for a nested generic type
    public static Dictionary<string, List<OrderLine>> GroupBySku(IEnumerable<OrderLine> lines)
    {
        Dictionary<string, List<OrderLine>> groups = new Dictionary<string, List<OrderLine>>();
        foreach (var line in lines)
        {
            if (!groups.TryGetValue(line.Sku, out var group))
            {
                group = new List<OrderLine>();
                groups[line.Sku] = group;
            }

            group.Add(line);
        }

        return groups;
    }

    // REFACTOR [IDE0090]: 'new' expression can be simplified on a field with an object initializer
    private readonly Address _defaultAddress = new Address { City = "Unknown" };

    public void Count(string key)
    {
        _counts[key] = _counts.GetValueOrDefault(key) + 1;
    }

    public Address DefaultAddress => _defaultAddress;
}
