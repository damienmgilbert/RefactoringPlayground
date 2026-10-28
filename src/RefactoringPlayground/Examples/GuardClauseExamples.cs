namespace RefactoringPlayground.Examples;

public static class GuardClauseExamples
{
    // REFACTOR [CA1510]: Use 'ArgumentNullException.ThrowIfNull(order)'
    public static decimal OrderTotal(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        return order.Lines.Sum(l => l.Quantity * l.UnitPrice);
    }

    // REFACTOR [CA1511]: Use 'ArgumentException.ThrowIfNullOrEmpty(sku)'
    public static string NormalizeSku(string sku)
    {
        if (string.IsNullOrEmpty(sku))
        {
            throw new ArgumentException("SKU is required.", nameof(sku));
        }

        return sku.Trim().ToUpperInvariant();
    }

    // REFACTOR [CA1512]: Use 'ArgumentOutOfRangeException.ThrowIfNegativeOrZero' / 'ThrowIfNegative'
    public static decimal LineTotal(decimal unitPrice, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        if (unitPrice < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(unitPrice));
        }

        return unitPrice * quantity;
    }

    // REFACTOR [refactoring]: "Invert 'if'" repeatedly, or "Merge nested 'if'", to flatten arrow code into guard clauses
    public static string? ShippingCity(Order? order)
    {
        if (order != null)
        {
            if (order.Customer != null)
            {
                if (order.Customer.Address != null)
                {
                    if (!string.IsNullOrWhiteSpace(order.Customer.Address.City))
                    {
                        return order.Customer.Address.City.Trim();
                    }
                }
            }
        }

        return null;
    }

    // REFACTOR [refactoring]: "Invert 'if'" to use early returns instead of a 'shipped' flag
    public static bool Ship(Order? order, INotifier? notifier)
    {
        var shipped = false;
        if (order != null)
        {
            if (order.Status == OrderStatus.Paid)
            {
                order.Status = OrderStatus.Shipped;
                notifier?.Notify("Order " + order.Id + " shipped");
                shipped = true;
            }
        }

        return shipped;
    }
}

public sealed class ResourceHolder : IDisposable
{
    private bool _disposed;

    // REFACTOR [CA1513]: Use 'ObjectDisposedException.ThrowIf(_disposed, this)'
    public int DoWork()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(ResourceHolder));
        }

        return 42;
    }

    public void Dispose()
    {
        _disposed = true;
    }
}
