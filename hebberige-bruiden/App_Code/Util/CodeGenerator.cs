using System;
using System.Text;

public class CodeGenerator
{
    private static string allowedLetters = "qwertyuioplkjhgfdazxcvbnmQWERTYUIOPASDFGHJKLMNBVCXZ1234567890";

    public static string GenerateCode(int length)
    {
        char[] characters = allowedLetters.ToCharArray();

        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = rnd.Next(0, characters.Length);
            result.Append(characters[index].ToString());
        }

        return result.ToString();
    }
}