using System;

namespace CSEx07
{
    class Program
    {
        static void Main(string[] lenny)
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
            Console.WriteLine("Welcome to Console Roulette! what would you like to do?");
            Console.WriteLine("1: View the Spinner");
            Console.WriteLine("2: Place a bet and spin!");
            Console.WriteLine("3: exit");
            int menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    methodChoice1();
                    return true;

                case 2:
                    MethodChoice2();
                    return true;

                case 3:
                    Console.WriteLine("GoodBye");
                    Console.ReadLine();
                    return false;

                default:
                    Console.WriteLine("Thats not an option");
                    Console.ReadLine();
                    return true;
            }


        }
        private static void methodChoice1()
        {
            Spinner spinner = new Spinner();
            foreach (string hole in spinner.DisplaySpinner())
            {
                Console.WriteLine(hole);
            }
            Console.ReadLine();
        }


        private static void MethodChoice2()
        {
            Console.WriteLine("Place your bet - pick a number between 1 & 36");
            int bet = int.Parse(Console.ReadLine());
            
            Roll roll = new Roll();
            roll.Spin(bet);
            Console.WriteLine("Hit any key to go back to the menu");
            Console.ReadLine();
        }
    }


    class Spinner
    {
        public string[] DisplaySpinner()
        {
            string color;
            string[] newSpinner = new string[38];
            string[] Spinner = new string[38];
            for (int i = 0; i < Spinner.Length; i++)
            {
                switch (i % 2)
                {
                    case 0: color = "Black"; break;
                    default: color = "Red"; break;
                }
                int number;
                switch (i)
                {
                    case 0:
                        color = "Green";
                        number = -1; break;
                    case 1:
                        color = "Green";
                        number = 0; break;
                    default: number = i - 1; break;
                }
                newSpinner[i] = $"|{color}:{number}|";
                Spinner[i] = newSpinner[i];
            }
            return Spinner;
        }
    }
    class Roll : Spinner
    {
        public void Spin(int input)
        {
            Random ball = new Random();
            int winner = ball.Next(0, 38);
            string[] spinner = DisplaySpinner();
            string winStr = spinner[winner];
            int colon = winStr.IndexOf(":")+1;
            string color = winStr.Substring(1, colon-2);
            int pipe = winStr.LastIndexOf("|")-colon;
            int number = int.Parse(winStr.Substring(colon, pipe));
            Console.WriteLine($"Your bet is: {spinner[input+1]}");
            if (number < 1)
            {
                number.ToString("00");
                Console.WriteLine($"The ball lands in: {color} {number}");
                Console.WriteLine("The House Wins");
            }
            else
            {
                Console.WriteLine($"The ball lands in: {color} {number}");
                Console.WriteLine("The winners are:");

                Console.WriteLine($"Numbers: {number}");
                if (input == number) Console.WriteLine("You Win");
                else Console.Write("");

                if (number > 1 & number % 2 == 0) Console.WriteLine("Even/Odds: Evens");
                else Console.WriteLine("Even/Odds: Odds");

                Console.WriteLine($"Color: {color}");

                if (number <= 18) Console.WriteLine("Lows/Highs: Low");
                else Console.WriteLine("Lows/Highs: High");

                if (number <= 12) Console.WriteLine("Dozens: 1st 12");
                else if (number <= 24)
                {
                    Console.WriteLine("Dozens: 2nd 12");
                }
                else Console.WriteLine("Dozens: 3rd 12");

                int n = 1;
                do
                {
                    if (number == n) { Console.WriteLine("Columns: First Column"); break; }
                    else if (number == n - 1) { Console.WriteLine("Columns: Third Column"); break; }
                    else if (number == n + 1) { Console.WriteLine("Columns: Second Column"); break; }
                    else n++;
                } while (n < 37);


                int j = 1;
                do
                {
                    if (number == j || number == j + 1 || number == j + 2) { Console.WriteLine($"Row:{j}"); break; }
                    else j += 3;
                } while (j < 35);
                if (number == j || number == j + 1 || number == j + 2) Console.WriteLine($"You Win!");
                else Console.WriteLine("Not a winner here");

                int k = 1;
                do
                {
                    if (number >= k & number < (k + 6)) { Console.WriteLine($"Double Row:{k}"); break; }
                    else k += 6;
                } while (k < 32);
                if (input >= k & input < (k + 6)) Console.WriteLine($"You Win!"); 
                else Console.WriteLine("Not a winner here");

                int l = 1;
                do
                {
                    if (number == l + 1 || number == l + 3) { Console.WriteLine($"Split: {number}|{l}"); break; }
                    else l++;
                } while (l < number + 4);
                if (input == l + 1 || input == l + 3) Console.WriteLine($"You Win!");
                else Console.WriteLine("Not a winner here");

                int m = 1;
                do
                {
                    if (number == m + 1 || number == m + 3 || number == m + 4 & number % 3 != 0)
                    { Console.WriteLine($"Corner:{m}|{m + 1}|{m + 3}|{m + 4}"); break; }
                    else m++;
                } while (m < 33);
                if (input == m + 1 || input == m + 3 || input == m + 4 & input % 3 != 0)
                        Console.WriteLine($"You Win!");
                else Console.WriteLine("Not a winner here");

            }
        }
    }
}
