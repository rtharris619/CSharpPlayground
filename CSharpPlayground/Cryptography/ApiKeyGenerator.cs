using System.Security.Cryptography;

namespace CSharpPlayground.Cryptography;

public sealed class ApiKeyGenerator
{
    public string GenerateApiKey(string prefix, int length = 64)
    {
        var bytes = RandomNumberGenerator.GetBytes(length);

        // Generate URL safe base64 string
        string base64String = Convert.ToBase64String(bytes)
            .Replace("+", "-")
            .Replace("/", "_");

        var keyLength = length - prefix.Length;

        return prefix + base64String[..keyLength];
    }

    public void Driver()
    {
        string key = GenerateApiKey("avenews-", 64);
        Console.WriteLine($"Your key is {key}");
    }
}
