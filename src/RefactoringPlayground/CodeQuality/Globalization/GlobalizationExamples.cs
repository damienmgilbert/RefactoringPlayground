namespace RefactoringPlayground.CodeQuality.Globalization;

public static class GlobalizationExamples
{
    // REFACTOR [CA1305]: Specify IFormatProvider ('price.ToString(CultureInfo.InvariantCulture)')
    public static string FormatPrice(decimal price)
    {
        return price.ToString();
    }

    // REFACTOR [CA1305]: Specify IFormatProvider for 'string.Format'
    public static string Label(int count)
    {
        return string.Format("{0} items", count);
    }

    // REFACTOR [CA1304] / [CA1311]: Specify a culture ('ToUpperInvariant()')
    public static string Shout(string text)
    {
        return text.ToUpper();
    }

    // REFACTOR [CA1309] / [CA1310]: Use ordinal string comparison ('string.Equals(a, b, StringComparison.Ordinal)')
    public static bool SameName(string a, string b)
    {
        return string.Compare(a, b) == 0;
    }

    // REFACTOR [CA1307]: Specify StringComparison for clarity ('text.IndexOf("x", StringComparison.Ordinal)')
    public static int Find(string text)
    {
        return text.IndexOf("x");
    }

    // REFACTOR [CA1307]: Specify StringComparison for clarity ('Replace')
    public static string Clean(string text)
    {
        return text.Replace("\r\n", "\n");
    }
}
