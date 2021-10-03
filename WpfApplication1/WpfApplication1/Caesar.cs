using System.Linq;
using System.Windows.Markup;

namespace WpfApplication1
{
    public static class Caesar
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            var caesarKey = int.Parse(key);
            return toDecrypt ? Decrypt(inputText, caesarKey) : Encrypt(inputText, caesarKey);
        }

        private static string Encrypt(string inputText, int key)
        {
            var output = inputText.Aggregate(string.Empty, (current, ch) => current + Cipher(ch, key));
            return $"{inputText} encrypted with Caesar in {output} !";
        }
        
        private static string Decrypt(string inputText, int key)
        {
            var output =  Encipher(inputText, 26-key);
            return $"{inputText} was decrypted with Caesar in {output} !";
        }

        private static char Cipher(char ch, int key) 
        {  
            if (!char.IsLetter(ch))
                return ch;

            var d = char.IsUpper(ch) ? 'A' : 'a';  
            return (char)((((ch + key) - d) % 26) + d);
        }
        
        private static string Encipher(string input, int key)
        {
            return input.Aggregate(string.Empty, (current, ch) => current + Cipher(ch, key));
        }
    }
}