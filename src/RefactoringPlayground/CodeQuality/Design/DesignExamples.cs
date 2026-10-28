namespace RefactoringPlayground.CodeQuality.Design;

// REFACTOR [CA1052]: Static holder types should be 'static' (all members are static)
public class PriceMath
{
    public static decimal Round(decimal value)
    {
        return Math.Round(value, 2);
    }
}

public class DesignExamples
{
    // REFACTOR [CA1051]: Do not declare visible instance fields (use a property)
    public string Title = string.Empty;

    // REFACTOR [CA1002]: Do not expose generic lists (use Collection<T> / IReadOnlyList<T>)
    public List<string> Tags { get; } = [];

    // REFACTOR [CA1024]: Use properties where appropriate
    public int GetTagCount()
    {
        return Tags.Count;
    }
}

// REFACTOR [CA1000]: Do not declare static members on generic types
public class Box<T>
{
    public static Box<T> Empty()
    {
        return new Box<T>();
    }
}
