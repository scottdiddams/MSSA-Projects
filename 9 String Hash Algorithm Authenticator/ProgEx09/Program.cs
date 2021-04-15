using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace ProgEx09
{
    class Program
    {
        static void Main(string[] args)
        {
            bool startMenu = true;
            while (startMenu)
            {
                Console.Clear();
                startMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("PASSWORD AUTHENTICATION SYSTEM");
            Console.WriteLine("***********************************");
            Console.WriteLine("|     Please Select an Option:    |");
            Console.WriteLine("|     1: Establish an Account     |");
            Console.WriteLine("|     2: Authenticate a User      |");
            Console.WriteLine("|     3: Show Existing Users      |");
            Console.WriteLine("|     4: Exit                     |");
            Console.WriteLine("***********************************");
            int menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Util.getNewUser();
                    return true;

                case 2:
                    Util.getUser();
                    return true;

                case 3:
                    Util.printUsers();
                    return true;

                case 4:
                    Console.WriteLine("GoodBye");
                    Console.ReadLine();
                    return false;

                default:
                    Console.WriteLine("Thats not an option");
                    Console.ReadLine();
                    return true;
            }
        }
    }

    class Util
    {
        static Dictionary<string, string> Users = new Dictionary<string, string>();

        public static string SHA1HashStringForUTF8String(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }
        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
        public static void getNewUser()
        {
            Console.WriteLine("Enter a unique user name:");
            string userName = Console.ReadLine();
            //Console.WriteLine(passHash); Console.ReadLine();

            if (!Users.ContainsKey(userName))
            {
                Console.WriteLine("Enter a password");
                string passWord = Console.ReadLine();
                string passHash = SHA1HashStringForUTF8String(passWord);
                Users.Add(userName,passHash);
                Console.WriteLine("You are registerred in the system");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This user name already exists in the system - try again");
                Console.ReadLine();
                getNewUser();
            }
        }

        internal static void getUser()
        {
            Console.WriteLine("Enter Your Username:");
            string userName = Console.ReadLine();
            if (Users.ContainsKey(userName))
            {
                Console.WriteLine($"Hello {userName}, Enter Your Password:");
                Users.TryGetValue(userName, out string value);
                string passWord = Console.ReadLine();
                string passHash = SHA1HashStringForUTF8String(passWord);
                if (passHash == value)
                {
                    Console.WriteLine($"User Authenticated!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"That password does not exist in the system - try again");
                    getUser();
                }
            }
            else
            {
                Console.WriteLine($"{userName} does not exist in the system");
                Console.ReadLine();
                Console.Clear();
            }
           
        }

        internal static void printUsers()
        {
            foreach (KeyValuePair<string, string> kvp in Users)
            {
                Console.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }
            Console.ReadLine();
        }
 
    }
    
}
