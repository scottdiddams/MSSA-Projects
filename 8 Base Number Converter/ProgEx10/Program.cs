using System;

namespace ProgEx10
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Q to exit, N to Continue");
                string exit = Console.ReadLine();
                if (exit == "Q" || exit == "q")
                    Environment.Exit(0);

                Console.WriteLine("enter the base to convert from: |2|8|10|16|: ");
                int from = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter the integer to convert: ");
                string n1 = Console.ReadLine();
                bool success = Int32.TryParse(n1, out int number);
                if (success)
                {
                    Console.WriteLine($"Number: {number}, Base: {from}");
                }
                else
                {
                    Console.WriteLine($"Hexadecimal: {n1}, Base: {from}");
                }

                long result = 0;
                string str_result = "";

                if(from == 10)
                {
                    result = Util.dec2bin(number);
                    Console.WriteLine($"Decimal {number} in binary is {result}");
                    result = Util.dec2oct(number);
                    Console.WriteLine($"Decimal {number} in octal is {result}");
                    str_result = Util.dec2hex(number);
                    Console.WriteLine($"Decimal {number} in hexadecimal is {str_result}");
                }
                else if(from == 2)
                {
                    result = Util.bin2dec(number);
                    Console.WriteLine($"Binary {number} in Decimal is {result}");
                    result = Util.bin2oct(number);
                    Console.WriteLine($"Binary {number} in octal is {result}");
                    str_result = Util.bin2hex(number);
                    Console.WriteLine($"Binary {number} in hexadecimal is {str_result}");
                }
                else if(from == 8)
                {
                    result = Util.oct2dec(number);
                    Console.WriteLine($"Octal {number} in Decimal is {result}");
                    result = Util.oct2bin(number);
                    Console.WriteLine($"Octal {number} in Binary is {result}");
                    str_result = Util.oct2hex(number);
                    Console.WriteLine($"Octal {number} in hexadecimal is {str_result}");
                }
                else if(from == 16)
                {
                    result = Util.hex2dec(n1);
                    Console.WriteLine($"Hexadecimal {n1} in Decimal is {result}");
                    result = Util.hex2bin(n1);
                    Console.WriteLine($"Hexadecimal {n1} in Binary is {result}");
                    result = Util.hex2oct(n1);
                    Console.WriteLine($"Hexadecimal {n1} in Octal is {result}");
                }

            }
        }
    }

    class Util
    {
        internal static long dec2bin(int number)
        {
            string res = "";
            while (number > 0)
            {
                string remainder = (number % 2).ToString();
                res += remainder;
                number /= 2;
            }
            char[] strA = res.ToCharArray();
            Array.Reverse(strA);
            string resS = string.Join("", strA);
            long result = long.Parse(resS);
            return result;
        }

        internal static string dec2hex(int number)
        {
            string[] hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "10" };
            string str_result = "";
            
            while (number > 0)
            {
                int decRemain = number % 16;
                str_result += hex[decRemain];
                number /= 16;
            }
            char[] strA = str_result.ToCharArray();
            Array.Reverse(strA);
            str_result = string.Join("", strA);
            return str_result;
        }

        internal static long dec2oct(int number)
        {
            string res = "";
            while (number > 0)
            {
                int remainder = number % 8;
                res+=remainder.ToString();
                number /= 8;
            }

            char[] resA = res.ToCharArray();
            Array.Reverse(resA);
            string str_result = string.Join("", resA);
            long result = long.Parse(str_result);
            return result;
        }

        internal static long bin2dec(int number)
        {
            int result = 0;
            int base1 = 1;

            while (number > 0)
            {
                int reminder = number % 10;
                number /= 10;
                result += reminder * base1;
                base1 *= 2;
            }
            return result;
        }

        internal static long bin2oct(int number)
        {
            long result = dec2oct(Int32.Parse(bin2dec(number).ToString()));
            return result;
        }

        internal static string bin2hex(int number)
        {
            string str_result = dec2hex(Int32.Parse(bin2dec(number).ToString()));
            return str_result;
        }

        internal static long oct2dec(int number)
        {
            /*
            string numstr = number.ToString();
            string[] num = numstr.Split();
            int n = (num.Length)-1;
            double result = 0;
            for (int i=0; i< num.Length; i++)
            {
                double intnum = Double.Parse(num[i]);
                double calc = intnum * Math.Pow(8, n);
                result += calc;
                n -= 1;
            }
            return long.Parse(result.ToString());
            */
            int num = number;
            int dec_value = 0;
            int b_ase = 1;
            int temp = num;
            while (temp > 0)
            {
                int last_digit = temp % 10;
                temp /= 10;
                dec_value += last_digit * b_ase;
                b_ase *= 8;
            }
            return dec_value;
        }

        internal static long oct2bin(int number)
        {
            long result = dec2bin(Int32.Parse(oct2dec(number).ToString()));
            return result;
        }

        internal static string oct2hex(int number)
        {
            string str_result = dec2hex(Int32.Parse(oct2dec(number).ToString()));
            return str_result;
        }

        internal static long hex2dec(string n1)
        {
            /*
            string[] hex = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "10" };
            string[] num = n1.Split();
            int n = (num.Length)-1;
            double result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                double calc;
                if (double.TryParse(num[i], out double numd))
                {
                    calc = numd * Math.Pow(16, n);
                }
                else
                {
                    int index = Array.IndexOf(hex, num[i]);
                    calc = index * Math.Pow(16, n);
                }
                result += calc;
                n -= 1;
            }
            return long.Parse(result.ToString());
            */

            int len = n1.Length;
            int base1 = 1;
            int dec_val = 0;

            for (int i = len - 1; i >= 0; i--)
            {

                if (n1[i] >= '0' && n1[i] <= '9')
                {
                    dec_val += (n1[i] - 48) * base1;
                    base1 *= 16;
                }
                else if (n1[i] >= 'A' && n1[i] <= 'F')
                {
                    dec_val += (n1[i] - 55) * base1;
                    base1 *= 16;
                }
            }
            return dec_val;
        }

        internal static long hex2bin(string n1)
        {
            long result = dec2bin(Int32.Parse(hex2dec(n1).ToString()));
            return result;
        }

        internal static long hex2oct(string n1)
        {
            long result = dec2oct(Int32.Parse(hex2dec(n1).ToString()));
            return result;
        }
    }
}
