namespace RefactoringPlayground.CodeStyle.Naming;

// REFACTOR [IDE1006]: Interface names must begin with 'I'
public interface Printable
{
    string Print();
}

// The naming rules live in .editorconfig ("Naming rules" section) and are reported as IDE1006.
public class NamingExamples : Printable
{
    // REFACTOR [IDE1006]: Private fields must be '_camelCase' ('_counter')
    private int Counter;

    // REFACTOR [IDE1006]: Private static readonly fields must be 'PascalCase'
    private static readonly string defaultLabel = "label";

    // REFACTOR [IDE1006]: Constants must be PascalCase ('MaxItems')
    private const int max_items = 10;

    // REFACTOR [IDE1006]: Properties must be PascalCase ('Total')
    public int total { get; set; }

    // REFACTOR [IDE1006]: Methods must be PascalCase ('Increment')
    public int increment()
    {
        Counter++;
        return Counter < max_items ? Counter : max_items;
    }

    // REFACTOR [IDE1006]: Async methods must end in 'Async' ('LoadAsync')
    public async Task<string> Load()
    {
        await Task.Delay(1);
        return defaultLabel;
    }

    // REFACTOR [IDE1006]: Parameters must be camelCase ('itemCount')
    public string Describe(int ItemCount)
    {
        return $"{ItemCount} items";
    }

    public string Print()
    {
        return Describe(total);
    }
}
