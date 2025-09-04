using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSystems.Controllers
{
    internal class Utils
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string characters = Config.random_password_characters;
            string password = "";
            int index;
            for (int i = 0; i < length; i++)
            {
                index = random.Next(characters.Length);
                password += characters[index];
            }
            return password;
        }
    }
}
