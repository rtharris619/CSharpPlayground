using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Cryptography;

public sealed class AesEncryption
{
    public void GenerateEncryptionKey()
    {
        using var aes = System.Security.Cryptography.Aes.Create();
        aes.KeySize = 256;
        aes.GenerateKey();
        aes.GenerateIV();
        Console.WriteLine($"Key: {Convert.ToBase64String(aes.Key)}");
        Console.WriteLine($"IV: {Convert.ToBase64String(aes.IV)}");
    }

    public void Driver()
    {
        GenerateEncryptionKey();
    }
}
