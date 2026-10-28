namespace RefactoringPlayground.CodeStyle.ExpressionLevel;

public static class RangeIndexExamples
{
    // REFACTOR [IDE0056]: Use index operator ('values[^1]')
    public static int Last(IList<int> values)
    {
        return values[values.Count - 1];
    }

    // REFACTOR [IDE0056]: Use index operator on a string ('text[^1]')
    public static char LastChar(string text)
    {
        return text[text.Length - 1];
    }

    // REFACTOR [IDE0057]: Use range operator ('text[1..]')
    public static string DropFirst(string text)
    {
        return text.Substring(1);
    }

    // REFACTOR [IDE0057]: Use range operator ('text[..3]')
    public static string FirstThree(string text)
    {
        return text.Substring(0, 3);
    }

    // REFACTOR [IDE0057]: Use range operator ('text[2..5]')
    public static string Middle(string text)
    {
        return text.Substring(2, 3);
    }

    // REFACTOR [IDE0057]: Use range operator ('text[1..^1]')
    public static string Unquote(string text)
    {
        return text.Substring(1, text.Length - 2);
    }

    // REFACTOR [IDE0057]: Use range operator ('text[^4..]')
    public static string LastFour(string text)
    {
        return text.Substring(text.Length - 4);
    }

    // REFACTOR [IDE0057]: Use range operator on a Span ('values[2..]')
    public static int SumAfterTwo(int[] values)
    {
        var tail = values.AsSpan().Slice(2);
        int sum = 0;
        foreach (var value in tail)
        {
            sum += value;
        }

        return sum;
    }

    // REFACTOR [IDE0056] + [IDE0057]: both operators in one method
    public static string MaskCard(string cardNumber)
    {
        var lastDigit = cardNumber[cardNumber.Length - 1];
        return new string('*', cardNumber.Length - 4) + cardNumber.Substring(cardNumber.Length - 4, 3) + lastDigit;
    }
}
