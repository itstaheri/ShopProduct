using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generator
{
    public static class RandomTextGenerator
    {
        public static string GenerateStrongPassword(int length = 8)
        {
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            string allChars = uppercase + lowercase + numbers + specialChars;
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // اطمینان از اینکه حداقل یک کاراکتر از هر دسته استفاده می‌شود
            password.Append(uppercase[random.Next(uppercase.Length)]);
            password.Append(lowercase[random.Next(lowercase.Length)]);
            password.Append(numbers[random.Next(numbers.Length)]);
            password.Append(specialChars[random.Next(specialChars.Length)]);

            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            return ShufflePassword(password.ToString());
        }

        private static string ShufflePassword(string password)
        {
            char[] array = password.ToCharArray();
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }
        public static string OTPCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

     
    }
}
