namespace RefactoringPlayground.CodeQuality.Documentation;

public static class DocumentationExamples
{
    /// <summary>
    /// REFACTOR [CA1200]: Avoid using cref tags with a prefix.
    /// Use <see cref="T:RefactoringPlayground.Models.Order" /> as <see cref="Order" /> instead.
    /// </summary>
    /// <param name="order">The order to describe.</param>
    /// <returns>A short description.</returns>
    public static string Describe(Order order)
    {
        return $"Order {order.Id}";
    }
}
