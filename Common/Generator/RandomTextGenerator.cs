using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generator
{
    public static class RandomTextGenerator
    {
        private static char[] specialCharecters = new char[] { '@', '\\', '\\', '!', '#' };
        private static char[] charecters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static string Password()
        {
            Random random = new Random();
            int number = random.Next(1000, 99999);
            char spc1 = specialCharecters[random.Next(0, specialCharecters.Length - 1)];
            char spc2 = specialCharecters[random.Next(0, specialCharecters.Length - 1)];
            char lc1 = specialCharecters[random.Next(0, charecters.Length - 1)];
            char lc2 = specialCharecters[random.Next(0, charecters.Length - 1)];
            char lc3 = specialCharecters[random.Next(0, charecters.Length - 1)];

            char uc1 = specialCharecters[random.Next(0, charecters.Length - 1)];
            char uc2 = specialCharecters[random.Next(0, charecters.Length - 1)];
            char uc3 = specialCharecters[random.Next(0, charecters.Length - 1)];

            string pass = spc1 + spc2 + number.ToString() + lc1 + lc2 + lc3 + uc1.ToString().ToUpper() + uc2.ToString().ToUpper() + uc3.ToString().ToUpper();

            random.Shuffle<char>(pass.ToArray());

            return pass;


        }

        public static string OTPCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

     
    }
}
