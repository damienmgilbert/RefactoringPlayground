using System.Runtime.InteropServices;

namespace RefactoringPlayground.CodeQuality.Interoperability;

public static class InteroperabilityExamples
{
    // REFACTOR [CA1401]: P/Invokes should not be visible (make it 'private' or 'internal')
    // REFACTOR [SYSLIB1054]: Use 'LibraryImport' instead of 'DllImport'
    [DllImport("kernel32.dll")]
    public static extern uint GetTickCount();

    // REFACTOR [CA1416]: Validate platform compatibility (the registry is Windows-only)
    public static bool HasUserSoftwareKey()
    {
        using var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software");
        return key is not null;
    }
}
