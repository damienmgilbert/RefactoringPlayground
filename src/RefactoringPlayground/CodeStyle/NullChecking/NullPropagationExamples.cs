namespace RefactoringPlayground.CodeStyle.NullChecking;

public static class NullPropagationExamples
{
    // REFACTOR [IDE0031]: Use null propagation ('customer?.Address?.City')
    public static string? CityOf(Customer? customer)
    {
        return customer != null && customer.Address != null ? customer.Address.City : null;
    }

    // REFACTOR [IDE0031]: Use null propagation ('customer?.Name')
    public static string? NameOf(Customer? customer)
    {
        return customer == null ? null : customer.Name;
    }

    // REFACTOR [IDE0031]: Use null propagation with a method call ('customer?.Name?.ToUpperInvariant()')
    public static string? ShoutedName(Customer? customer)
    {
        return customer != null && customer.Name != null ? customer.Name.ToUpperInvariant() : null;
    }

    // REFACTOR [IDE0031]: Use null propagation with a value type ('orders?.Count')
    public static int? OrderCount(Customer? customer)
    {
        return customer != null && customer.Orders != null ? customer.Orders.Count : null;
    }

    // REFACTOR [IDE0031]: Use null propagation (collapses to 'order?.Customer?.Address?.PostalCode')
    public static string? PostalCodeOf(Order? order)
    {
        if (order != null && order.Customer != null && order.Customer.Address != null)
        {
            return order.Customer.Address.PostalCode;
        }

        return null;
    }

    // REFACTOR [IDE0031]: Use null propagation in a condition ('customer?.Name?.Length > 0')
    public static bool HasName(Customer? customer)
    {
        return customer != null && customer.Name != null && customer.Name.Length > 0;
    }

    // REFACTOR [IDE0031]: Use null propagation with an indexer ('customer?.Orders?[0]')
    public static Order? FirstOrder(Customer? customer)
    {
        return customer != null && customer.Orders != null ? customer.Orders[0] : null;
    }
}
