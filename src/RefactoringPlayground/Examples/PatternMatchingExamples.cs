namespace RefactoringPlayground.Examples;

/// <summary>
/// Every method here is intentionally written the "old" way.
/// Put the caret on the flagged code and press Ctrl+. (or Alt+Enter) to apply the quick action.
/// </summary>
public static class PatternMatchingExamples
{
    // REFACTOR [IDE0066]: Convert switch statement to expression
    public static string DescribeStatus(OrderStatus status)
    {
        switch (status)
        {
            case OrderStatus.Pending:
                return "Waiting for payment";
            case OrderStatus.Paid:
                return "Payment received";
            case OrderStatus.Shipped:
                return "On its way";
            case OrderStatus.Delivered:
                return "Delivered";
            case OrderStatus.Cancelled:
                return "Cancelled";
            default:
                return "Unknown";
        }
    }

    // REFACTOR [IDE0066]: Convert switch statement to expression (assignment form, stacked case labels)
    public static decimal ShippingCost(CustomerTier tier)
    {
        decimal cost;
        switch (tier)
        {
            case CustomerTier.Platinum:
            case CustomerTier.Gold:
                cost = 0m;
                break;
            case CustomerTier.Silver:
                cost = 2.50m;
                break;
            default:
                cost = 5.00m;
                break;
        }

        return cost;
    }

    // REFACTOR [IDE0066]: type patterns and 'when' guards also convert to a switch expression
    public static string ShapeName(Shape shape)
    {
        switch (shape)
        {
            case Circle c when c.Radius > 100:
                return "Large circle";
            case Circle:
                return "Circle";
            case Rectangle r when r.Width == r.Height:
                return "Square";
            case Rectangle:
                return "Rectangle";
            case Triangle:
                return "Triangle";
            default:
                throw new ArgumentException("Unknown shape", nameof(shape));
        }
    }

    // REFACTOR [refactoring]: Convert an if / else-if chain to a 'switch' statement or expression
    public static decimal DiscountRate(CustomerTier tier)
    {
        if (tier == CustomerTier.Platinum)
        {
            return 0.20m;
        }
        else if (tier == CustomerTier.Gold)
        {
            return 0.10m;
        }
        else if (tier == CustomerTier.Silver)
        {
            return 0.05m;
        }
        else
        {
            return 0m;
        }
    }

    // REFACTOR [IDE0019]: Use pattern matching instead of 'as' followed by a null check
    public static double AreaViaAs(Shape shape)
    {
        var circle = shape as Circle;
        if (circle != null)
        {
            return Math.PI * circle.Radius * circle.Radius;
        }

        var rectangle = shape as Rectangle;
        if (rectangle != null)
        {
            return rectangle.Width * rectangle.Height;
        }

        return 0;
    }

    // REFACTOR [IDE0020 / IDE0038]: Use pattern matching instead of 'is' followed by a cast
    public static double AreaViaCast(Shape shape)
    {
        if (shape is Triangle)
        {
            var triangle = (Triangle)shape;
            return 0.5 * triangle.Base * triangle.Height;
        }

        if (shape is Circle)
        {
            Circle circle = (Circle)shape;
            return Math.PI * circle.Radius * circle.Radius;
        }

        return 0;
    }

    // REFACTOR [IDE0078]: Use pattern matching ('is Circle or Rectangle')
    public static bool IsRoundOrRectangular(Shape shape)
    {
        return shape is Circle || shape is Rectangle;
    }

    // REFACTOR [IDE0078]: Use pattern matching ('is >= 0 and <= 100')
    public static bool IsValidPercentage(int value)
    {
        return value >= 0 && value <= 100;
    }

    // REFACTOR [IDE0078]: Use pattern matching ('day is DayOfWeek.Saturday or DayOfWeek.Sunday')
    public static bool IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    // REFACTOR [IDE0083]: Use 'is not' pattern
    public static bool IsNotCircle(Shape shape)
    {
        return !(shape is Circle);
    }

    // REFACTOR [IDE0041]: Use 'is null' check
    public static bool IsMissing(Customer? customer)
    {
        return object.ReferenceEquals(customer, null);
    }

    // REFACTOR [IDE0150]: Prefer 'null' check over type check ('is not null')
    public static bool HasCustomer(Order order)
    {
        return order.Customer is object;
    }

    // REFACTOR [IDE0170]: Simplify property pattern (extended property pattern: Customer.Tier: Gold)
    public static bool IsGoldCustomerOrder(Order order)
    {
        return order is { Customer: { Tier: CustomerTier.Gold } };
    }
}
