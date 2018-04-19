using System.Web.Helpers;

public class Encryptor
{
    public static void GeneratePassword(string password, out string encrypted, out string salt)
    {
        salt = Crypto.GenerateSalt(16);
        encrypted = Crypto.Hash(password + salt, "SHA256");
    }
}