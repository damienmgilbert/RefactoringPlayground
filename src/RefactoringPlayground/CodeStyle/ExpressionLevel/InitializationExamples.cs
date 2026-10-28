namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class InitializationExamples
{
    // REFACTOR [IDE0017]: Simplify object initialization ('new Customer { Name = name, ... }')
    public static Customer CreateCustomer(string name, string email)
    {
        var customer = new Customer();
        customer.Name = name;
        customer.Email = email;
        customer.Tier = CustomerTier.Standard;
        return customer;
    }

    // REFACTOR [IDE0028]: Simplify collection initialization (collection initializer / collection expression)
    public static List<string> DefaultSkus()
    {
        var skus = new List<string>();
        skus.Add("SKU-001");
        skus.Add("SKU-002");
        skus.Add("SKU-003");
        return skus;
    }

    // REFACTOR [IDE0090]: 'new' expression can be simplified (target-typed 'new()')
    public static Address EmptyAddress()
    {
        Address address = new Address();
        return address;
    }

    // REFACTOR [IDE0090] + [IDE0028]: target-typed 'new()' and collection initializer for the Add calls
    public static Dictionary<string, int> DefaultStock()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();
        stock.Add("A", 10);
        stock.Add("B", 20);
        return stock;
    }

    // REFACTOR [IDE0300]: Collection initialization can be simplified ('[2, 3, 5, 7]')
    public static int[] FirstPrimes()
    {
        int[] primes = new int[] { 2, 3, 5, 7 };
        return primes;
    }

    // REFACTOR [IDE0301]: Collection initialization can be simplified ('[]')
    public static string[] NoTags()
    {
        return Array.Empty<string>();
    }

    // REFACTOR [IDE0305]: Collection initialization can be simplified ('[.. query]' instead of '.ToList()')
    public static List<decimal> ExpensiveUnitPrices(Order order)
    {
        return order.Lines.Where(l => l.UnitPrice > 100m).Select(l => l.UnitPrice).ToList();
    }
}
