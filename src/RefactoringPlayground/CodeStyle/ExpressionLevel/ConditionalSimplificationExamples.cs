namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class ConditionalSimplificationExamples
{
    // REFACTOR [IDE0075]: Simplify conditional expression ('order.Total > 100m')
    public static bool IsLarge(Order order)
    {
        return order.Total > 100m ? true : false;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('!isPaid')
    public static bool NeedsPayment(bool isPaid)
    {
        return isPaid ? false : true;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('isGold || hasCoupon')
    public static bool GetsDiscount(bool isGold, bool hasCoupon)
    {
        return isGold ? true : hasCoupon;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('isGold && hasCoupon')
    public static bool GetsBonus(bool isGold, bool hasCoupon)
    {
        return isGold ? hasCoupon : false;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('!isGold && hasCoupon')
    public static bool GetsSmallBonus(bool isGold, bool hasCoupon)
    {
        return isGold ? false : hasCoupon;
    }

    // REFACTOR [IDE0075]: Simplify conditional expression ('!isGold || hasCoupon')
    public static bool GetsNoPenalty(bool isGold, bool hasCoupon)
    {
        return isGold ? hasCoupon : true;
    }

    // REFACTOR [IDE0100]: Remove unnecessary equality operator ('isPaid')
    public static bool IsSettled(bool isPaid)
    {
        return isPaid == true;
    }

    // REFACTOR [IDE0100]: Remove unnecessary equality operator ('!isPaid')
    public static bool IsOutstanding(bool isPaid)
    {
        return isPaid == false;
    }

    // REFACTOR [IDE0045]: Convert 'if' to conditional expression (assignment)
    public static string Label(Customer customer)
    {
        string label;
        if (customer.Tier == CustomerTier.Gold)
        {
            label = "VIP";
        }
        else
        {
            label = "Regular";
        }

        return label;
    }

    // REFACTOR [IDE0046]: Convert 'if' to conditional expression (return), nested form
    public static decimal DiscountRate(Customer customer)
    {
        if (customer.Tier == CustomerTier.Platinum)
        {
            return 0.2m;
        }
        else if (customer.Tier == CustomerTier.Gold)
        {
            return 0.1m;
        }
        else
        {
            return 0m;
        }
    }
}
