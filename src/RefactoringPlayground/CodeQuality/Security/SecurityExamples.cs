using System.Security.Cryptography;
using System.Text;

namespace RefactoringPlayground.CodeQuality.Security;

public static class SecurityExamples
{
    // REFACTOR [CA5351]: Do not use broken cryptographic algorithms (MD5 -> SHA256)
    public static byte[] HashWithMd5(string text)
    {
        using var md5 = MD5.Create();
        return md5.ComputeHash(Encoding.UTF8.GetBytes(text));
    }

    // REFACTOR [CA5350]: Do not use weak cryptographic algorithms (SHA1 -> SHA256)
    public static byte[] HashWithSha1(string text)
    {
        using var sha1 = SHA1.Create();
        return sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
    }

    // REFACTOR [CA5394]: Do not use insecure randomness ('RandomNumberGenerator.GetInt32')
    public static int RollForToken()
    {
        return new Random().Next(1000, 9999);
    }
}
