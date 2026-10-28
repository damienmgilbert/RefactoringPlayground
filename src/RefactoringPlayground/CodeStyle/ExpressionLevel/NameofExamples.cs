using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class NameofExamples
{
    // REFACTOR [IDE0082]: Convert 'typeof' to 'nameof' ('nameof(Customer)')
    public static string CustomerTypeName()
    {
        return typeof(Customer).Name;
    }

    // REFACTOR [IDE0082]: Convert 'typeof' to 'nameof' ('nameof(OrderStatus)')
    public static string StatusTypeName()
    {
        return typeof(OrderStatus).Name;
    }

    // REFACTOR [IDE0082]: Convert 'typeof' to 'nameof' inside an interpolated string
    public static string Describe()
    {
        return $"Working with {typeof(Order).Name} and {typeof(OrderLine).Name}";
    }

    // REFACTOR [IDE0280]: Use 'nameof' in an attribute that takes a parameter name ('nameof(input)')
    [return: NotNullIfNotNull("input")]
    public static string? Trim(string? input)
    {
        return input?.Trim();
    }

    // REFACTOR [IDE0280]: Use 'nameof' in 'CallerArgumentExpression' ('nameof(value)')
    public static void Require(object? value, [CallerArgumentExpression("value")] string? expression = null)
    {
        if (value is null)
        {
            throw new ArgumentException("Value is required.", expression);
        }
    }

    // REFACTOR [CA1507]: Use 'nameof' in place of string literal ('nameof(order)')
    // REFACTOR [CA1510]: Use 'ArgumentNullException.ThrowIfNull'
    public static void Process(Order order)
    {
        if (order is null)
        {
            throw new ArgumentNullException("order");
        }
    }
}
