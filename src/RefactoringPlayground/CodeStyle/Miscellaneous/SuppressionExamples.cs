namespace RefactoringPlayground.CodeStyle.Miscellaneous;

public static class SuppressionExamples
{
    // REFACTOR [IDE0079]: Remove unnecessary suppression (nothing below triggers IDE0011; IDE0079 only reports inside the IDE)
#pragma warning disable IDE0011
    public static int Twice(int value)
    {
        return value * 2;
    }
#pragma warning restore IDE0011

    // REFACTOR [IDE0079]: Remove unnecessary suppression (the code analyzed here has no CA2201 violation)
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2201:Do not raise reserved exception types")]
    public static int Triple(int value)
    {
        return value * 3;
    }

    // Necessary suppression: the pragma hides a real violation, so IDE0079 leaves it alone.
#pragma warning disable IDE0059
    public static int KeepAssignment()
    {
        int unused = 5;
        unused = 6;
        return unused;
    }
#pragma warning restore IDE0059
}
