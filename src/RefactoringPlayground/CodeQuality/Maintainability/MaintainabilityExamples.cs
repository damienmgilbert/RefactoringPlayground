namespace RefactoringPlayground.CodeQuality.Maintainability;

public static class MaintainabilityExamples
{
    // REFACTOR [CA1507]: Use 'nameof' in place of string literal ('nameof(order)')
    public static void Ship(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException("order");
        }

        order.Status = OrderStatus.Shipped;
    }

    // REFACTOR [CA1508]: Avoid dead conditional code ('value' can never be null here)
    public static string Normalize(string? text)
    {
        var value = text ?? "unknown";
        if (value == null)
        {
            return "never";
        }

        return value.Trim();
    }

    // REFACTOR [CA1508]: Avoid dead conditional code (the second check repeats the first)
    public static string Classify(int amount)
    {
        if (amount > 10)
        {
            if (amount > 5)
            {
                return "big";
            }
        }

        return "small";
    }
}
