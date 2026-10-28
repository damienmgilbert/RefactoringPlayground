namespace RefactoringPlayground.CodeStyle.PatternMatching;

public static class NullCheckOverTypeCheckExamples
{
    // REFACTOR [IDE0150]: Prefer 'null' check over type check ('value is not null')
    public static bool HasValue(object? value)
    {
        return value is object;
    }

    // REFACTOR [IDE0150]: Prefer 'null' check over type check ('value is null')
    public static bool IsMissing(object? value)
    {
        return value is not object;
    }

    // REFACTOR [IDE0150]: Prefer 'null' check over type check (negated form)
    public static bool IsMissingNegated(object? value)
    {
        return !(value is object);
    }

    // REFACTOR [IDE0150]: Prefer 'null' check over type check on a reference-typed variable
    public static string NameOrDefault(Customer? customer)
    {
        if (customer is Customer)
        {
            return customer.Name ?? "Unnamed";
        }

        return "Unknown";
    }

    // REFACTOR [IDE0150]: Prefer 'null' check over type check (in a LINQ predicate)
    public static int CountPresent(IEnumerable<Order?> orders)
    {
        return orders.Count(order => order is Order);
    }

    // REFACTOR [IDE0041]: Use 'is null' check
    public static bool IsNullViaReferenceEquals(Order? order)
    {
        return ReferenceEquals(order, null);
    }

    // REFACTOR [IDE0041]: Use 'is null' check
    public static bool IsNullViaObjectEquals(Order? order)
    {
        return object.ReferenceEquals(null, order);
    }
}
