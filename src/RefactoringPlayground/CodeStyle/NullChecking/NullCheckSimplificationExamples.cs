namespace RefactoringPlayground.CodeStyle.NullChecking;

public class NullCheckSimplificationExamples
{
    private string? _name;
    private Address? _address;

    // REFACTOR [IDE0029]: Null check can be simplified ('name ?? "Guest"')
    public static string OrGuest(string? name)
    {
        return name == null ? "Guest" : name;
    }

    // REFACTOR [IDE0030]: Null check can be simplified for a nullable value type ('quantity ?? 1')
    public static int OrOne(int? quantity)
    {
        return quantity.HasValue ? quantity.Value : 1;
    }

    // REFACTOR [IDE0270]: Null check can be simplified ('var email = customer.Email ?? "n/a"')
    public static string EmailOrDefault(Customer customer)
    {
        var email = customer.Email;
        if (email == null)
        {
            email = "n/a";
        }

        return email;
    }

    // REFACTOR [IDE0270]: Null check can be simplified ('throw' variant)
    public static Address RequireAddress(Customer customer)
    {
        var address = customer.Address;
        if (address == null)
        {
            throw new InvalidOperationException("Customer has no address.");
        }

        return address;
    }

    // REFACTOR [IDE0074]: Use coalesce compound assignment ('_address ??= new Address()')
    public Address GetAddress()
    {
        if (_address == null)
        {
            _address = new Address();
        }

        return _address;
    }

    // REFACTOR [IDE0016]: Use throw expression ('_name = value ?? throw new ...')
    // REFACTOR [CA1510]: Use ArgumentNullException.ThrowIfNull
    public void SetName(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _name = value;
    }

    public string? Name => _name;
}
