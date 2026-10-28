using System.Runtime.Versioning;

namespace RefactoringPlayground.CodeQuality.Portability;

public static class PortabilityExamples
{
    // REFACTOR [CA1418]: Use valid platform string ('windows', not 'windows99')
    [SupportedOSPlatform("windows99")]
    public static string WindowsOnly()
    {
        return "windows";
    }

    // REFACTOR [CA1416]: Validate platform compatibility (guard with 'OperatingSystem.IsWindows()')
    public static string Call()
    {
        return OperatingSystem.IsWindows() ? WindowsHelper.Name() : "other";
    }

    [SupportedOSPlatform("windows")]
    private static class WindowsHelper
    {
        public static string Name()
        {
            return "windows";
        }
    }
}
