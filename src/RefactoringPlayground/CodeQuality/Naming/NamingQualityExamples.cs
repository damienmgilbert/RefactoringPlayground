namespace RefactoringPlayground.CodeQuality.Naming;

// REFACTOR [CA1710]: Identifiers should have the correct suffix ('OrderChangedEventArgs')
public class OrderChange : EventArgs
{
    public int OrderId { get; init; }
}

// REFACTOR [CA1710]: Identifiers should have the correct suffix ('OrderFailedException')
public class OrderFailed : Exception
{
}

public class NamingQualityExamples
{
    // REFACTOR [CA1707]: Remove underscores from member names ('MaxItems')
    public const int Max_Items = 10;

    // REFACTOR [CA1707]: Remove underscores from member names ('CalculateTotal')
    public decimal Calculate_Total(IEnumerable<OrderLine> lines)
    {
        return lines.Sum(l => l.Quantity * l.UnitPrice);
    }

    // REFACTOR [CA1720]: Identifier contains type name ('value' instead of 'int32')
    public int Echo(int int32)
    {
        return int32;
    }
}

// REFACTOR [CA1716]: Identifiers should not match keywords (a VB keyword used as a member name)
public interface IWalker
{
    void Next();
}
