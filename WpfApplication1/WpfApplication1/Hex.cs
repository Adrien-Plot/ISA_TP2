using System;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public static class Hex
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            var output = BitConverter.ToString(Cipher(inputText));
            output = output.Replace("-", "");

            return $"{inputText} encrypted with Hexadecimal in {output} !";
        }
        
        private static string Decrypt(string inputText)
        {
            var output =  Encipher(inputText);
            return $"{inputText} was decrypted with Caesar in {output} !";
        }

        private static byte[] Cipher(string inputText) 
        {  
            var ba = Encoding.Default.GetBytes(inputText);
            return ba;
        }
        
        private static string Encipher(string input)
        {
            //Le code en commentaire retourne des caractères chinois ... pourquoi ?
            /*
            var bytes = new byte[input.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); 
            */
            
            var raw = new byte[input.Length / 2];
            for (var i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(input.Substring(i * 2, 2), 16);
            }
            return Encoding.ASCII.GetString(raw); 
        }
    }
}