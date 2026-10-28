namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class ConditionalExamples
{
    // REFACTOR [IDE0045]: Convert 'if' to conditional expression (assignment)
    public static string ShippingLabel(Order order)
    {
        string label;
        if (order.Status == OrderStatus.Shipped)
        {
            label = "In transit";
        }
        else
        {
            label = "Not shipped";
        }

        return label;
    }

    // REFACTOR [IDE0046]: Convert 'if' to conditional expression (return)
    public static decimal Fee(decimal amount)
    {
        if (amount > 1000m)
        {
            return amount * 0.01m;
        }
        else
        {
            return 5m;
        }
    }

    // REFACTOR [refactoring]: Merge nested 'if' statements ('if (a && b)')
    public static bool CanShip(Order order)
    {
        if (order.Status == OrderStatus.Paid)
        {
            if (order.Lines.Count > 0)
            {
                return true;
            }
        }

        return false;
    }

    // REFACTOR [refactoring]: Merge consecutive 'if' statements that share a body ('a || b')
    public static bool IsClosed(Order order)
    {
        if (order.Status == OrderStatus.Delivered)
        {
            return true;
        }

        if (order.Status == OrderStatus.Cancelled)
        {
            return true;
        }

        return false;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('order.Lines.Count > 10')
    public static bool IsLarge(Order order)
    {
        return order.Lines.Count > 10 ? true : false;
    }

    // REFACTOR [IDE0100]: Remove unnecessary equality operator ('verified && ...')
    public static bool IsVerifiedAndPaid(Order order, bool verified)
    {
        return verified == true && order.Status == OrderStatus.Paid;
    }

    // REFACTOR [IDE0048]: Add parentheses for clarity (mixed '&&' and '||')
    public static bool QualifiesForFreeShipping(Order order, Customer customer)
    {
        return order.Total > 100m && customer.Tier != CustomerTier.Standard || customer.Tier == CustomerTier.Platinum;
    }

    // REFACTOR [IDE0011]: Add braces to 'if' statements
    public static int Clamp(int value, int min, int max)
    {
        if (value < min)
            return min;
        if (value > max)
            return max;
        return value;
    }

    // REFACTOR [IDE0056]: Use index operator ('lines[^1]')
    public static OrderLine LastLine(List<OrderLine> lines)
    {
        return lines[lines.Count - 1];
    }

    // REFACTOR [IDE0057]: Use range operator ('text[1..^1]')
    public static string TrimQuotes(string text)
    {
        return text.Substring(1, text.Length - 2);
    }

    // REFACTOR [IDE0120]: Simplify LINQ expression ('Any(l => l.Quantity > 100)')
    public static bool HasBigLine(Order order)
    {
        return order.Lines.Where(l => l.Quantity > 100).Any();
    }

    // REFACTOR [refactoring]: Convert 'foreach' to LINQ ('Where(...).Select(...)')
    public static List<string> SkusOfBulkLines(Order order)
    {
        var skus = new List<string>();
        foreach (var line in order.Lines)
        {
            if (line.Quantity >= 10)
            {
                skus.Add(line.Sku);
            }
        }

        return skus;
    }

    // REFACTOR [refactoring]: Convert 'for' to 'foreach'
    public static decimal SumPrices(List<OrderLine> lines)
    {
        decimal sum = 0m;
        for (int i = 0; i < lines.Count; i++)
        {
            sum += lines[i].UnitPrice;
        }

        return sum;
    }

    // REFACTOR [IDE0063]: Use simple 'using' statement ('using var reader = ...;')
    public static int CountLines(string text)
    {
        using (var reader = new StringReader(text))
        {
            var count = 0;
            while (reader.ReadLine() != null)
            {
                count++;
            }

            return count;
        }
    }

    // REFACTOR [refactoring]: Convert to interpolated string
    public static string Summary(Order order)
    {
        return "Order #" + order.Id + " has " + order.Lines.Count + " line(s), total " + order.Total.ToString("C");
    }

    // REFACTOR [IDE0071]: Simplify interpolation (drop '.ToString()')
    public static string Label(Order order)
    {
        return $"Order {order.Id.ToString()} is {order.Status.ToString()}";
    }

    // REFACTOR [IDE0082]: Convert 'typeof(...).Name' to 'nameof(Customer)'
    public static string TypeLabel()
    {
        return typeof(Customer).Name;
    }
}
