namespace RefactoringPlayground.CodeStyle.NullChecking;

public class NullHandlingExamples
{
    private List<string>? _cache;
    private string? _title;

    // REFACTOR [IDE0029 / IDE0030]: Use coalesce expression ('customer.Name ?? "Unknown"')
    public static string DisplayName(Customer customer)
    {
        return customer.Name != null ? customer.Name : "Unknown";
    }

    // REFACTOR [IDE0074]: Use compound coalesce assignment ('_cache ??= new List<string>()')
    public IReadOnlyList<string> GetCache()
    {
        if (_cache == null)
        {
            _cache = new List<string>();
        }

        return _cache;
    }

    // REFACTOR [IDE0074]: '_title = _title ?? "x"' becomes '_title ??= "x"'
    public string GetTitle()
    {
        _title = _title ?? "Untitled";
        return _title;
    }

    // REFACTOR [IDE0270]: Null check can be simplified ('customer.Address ?? new Address()')
    public static Address GetAddressOrDefault(Customer customer)
    {
        var address = customer.Address;
        if (address == null)
        {
            address = new Address();
        }

        return address;
    }

    // REFACTOR [IDE0031]: Use null propagation ('customer?.Name')
    public static string? GetCustomerName(Customer? customer)
    {
        return customer != null ? customer.Name : null;
    }

    // REFACTOR [IDE0031]: Use null propagation (collapses to 'customer?.Address?.City == city')
    public static bool IsInCity(Customer? customer, string city)
    {
        return customer != null && customer.Address != null && customer.Address.City == city;
    }
}

public class GreetingService
{
    private readonly string _greeting;

    // REFACTOR [IDE0016]: Use throw expression ('_greeting = greeting ?? throw new ...')
    // REFACTOR [CA1510]: Use ArgumentNullException.ThrowIfNull
    // REFACTOR [IDE0290]: Use primary constructor
    public GreetingService(string greeting)
    {
        if (greeting == null)
        {
            throw new ArgumentNullException(nameof(greeting));
        }

        _greeting = greeting;
    }

    public string Greet(string name)
    {
        return _greeting + ", " + name;
    }
}
