namespace WpfApplication1
{
    public static class Vigenere
    {
        public static string Code(string inputText, bool toDecrypt, string key)
        {
            return toDecrypt ? Decrypt(inputText, key) : Encrypt(inputText, key);
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            var output = string.Empty;
            var nonAlphaCharCount = 0;

            for (var i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    var cIsUpper = char.IsUpper(input[i]);
                    var offset = cIsUpper ? 'A' : 'a';
                    var keyIndex = (i - nonAlphaCharCount) % key.Length;
                    var k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    var temp = (((input[i] + k) - offset) % 26);
                    if (temp<0)
                    {
                        temp += 26;
                    }
                    var ch = (char)(temp + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        private static string Encrypt(string input, string key)
        {
            return Cipher(input, key, true);
        }

        private static string Decrypt(string input, string key)
        {
            return Cipher(input, key, false);
        }
    }
}