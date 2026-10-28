namespace RefactoringPlayground.CodeQuality.Usage;

public class UsageExamples
{
    // REFACTOR [CA2211]: Non-constant fields should not be visible (make it a property or 'private')
    public static int Counter;

    // REFACTOR [CA2227]: Collection properties should be read only (remove the setter)
    public List<string> Tags { get; set; } = [];

    // REFACTOR [CA2200]: Rethrow to preserve stack details ('throw;')
    public static void Rethrow(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            throw ex;
        }
    }

    // REFACTOR [CA2201]: Do not raise reserved exception types (use a specific exception)
    public static void Fail(string reason)
    {
        throw new Exception(reason);
    }

    // REFACTOR [CA2208]: Instantiate argument exceptions correctly (the name must match a parameter)
    public static void Check(string value)
    {
        if (value.Length == 0)
        {
            throw new ArgumentException("Value is empty.", "text");
        }
    }

    // REFACTOR [CA2241]: Provide correct arguments to formatting methods
    public static string Format(string first)
    {
        return string.Format("{0} {1}", first);
    }

    // REFACTOR [CA2249]: Consider using 'string.Contains' instead of 'string.IndexOf'
    public static bool HasDash(string text)
    {
        return text.IndexOf('-') >= 0;
    }
}

public class BaseWithVirtual
{
    // REFACTOR [CA2214]: Do not call overridable methods in constructors
    public BaseWithVirtual()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
    }
}
