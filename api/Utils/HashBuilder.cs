using System.Security.Cryptography;
using System.Text;

namespace MyFinancialTracker.api.Utils;

static class HashBuilder
{
    public static string Build(string hashString)
    {
        using (SHA256 hash = SHA256.Create())
        {
            // SHA256.Initialize();
            hash.ComputeHash(Encoding.UTF8.GetBytes(hashString));
            return Convert.ToBase64String(hash.Hash);
        }
    }
}