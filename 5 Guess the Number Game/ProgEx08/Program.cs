using System;

namespace ProgEx08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Guess My Number Game!");
            bool startMenu = true;
            while (startMenu)
            {
                Console.Clear();
                startMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
                Console.WriteLine("Select An Option Below");
                Console.WriteLine("1: Guess my Number");
                Console.WriteLine("2: Let me Guess your Number");
                Console.WriteLine("3: Bisection algorithm demo");
                Console.WriteLine("4: exit");
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
                        MethodChoice3();
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

        private static void MethodChoice3()
        {
            int[] array = new int[10];
            Console.WriteLine("Here is our array:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i+1;
                Console.Write($"{array[i]} ");
            }
            Console.ReadLine();
            Console.WriteLine("Lets implement a bisection method and step through finding a number");
            Console.WriteLine("enter a number between 1 and 10");
            int number = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Lets find {number} in the array");
            Console.WriteLine("We'll set a halfway point and test if the number is greater than or less than that value");
            Console.WriteLine("If we dont find the number, we'll set a new halfway point and try again!");
            Console.WriteLine("our max value is 10 and our min value is 0 so we'll start at the half-way point: 5");
            if (number == 5) Console.WriteLine("we found it!");
            else if (number > 10) Console.WriteLine("you didn't enter a number between 1 & 10");
            else if (number < 5)
            {
                Console.WriteLine($"Now we know {number} is between 1 & 4 now - our new halfway point is now 2");
                if (number == 2) Console.WriteLine("We found it!");
                else if (number < 2)
                {
                    Console.WriteLine($"Now we know {number} is 1 - we found it!");
                    Console.ReadLine();
                }
                else if (number > 2) Console.WriteLine($"We now know {number} is either 3 or 4 - I'll guess either one and we found it!");
            }
            else if (number > 5)
            {
                Console.WriteLine($"Now we know {number} is between 6 & 10, our new halfway point is now 8");
                if (number == 8) Console.WriteLine("We found it!");
                else if (number > 8) Console.WriteLine($"We now know {number} is 9 or 10 - I'll guess either one and we found it!");
                else if (number < 7) Console.WriteLine($"if {number} is less than 8 it must be 6 or 7 - I'll guess either one and we found it!");
            }
            Console.ReadLine();
        }

        private static void methodChoice1()
            {
            Console.WriteLine("I have chosen a number between 0 & 1000");
            
            Random random = new Random();
            int CpuGuess = random.Next(0, 1001);
            int entry;
            do
            {
                Console.WriteLine("Enter your guess");
                entry = Int32.Parse(Console.ReadLine());
                int counter = 1;
                guessCPU(entry, CpuGuess, counter);

            } while (entry != CpuGuess);
            Console.ReadLine();
            }

        private static void guessCPU(int entry, int cpuGuess, int counter)
        {
            int guess;
            if (entry >= 0 & entry <= 100) guess = entry;
            else
            {
                Console.WriteLine("Thats not a correct input - go back and try again");
                return;
            }
            if (guess == cpuGuess) Console.WriteLine($"Thats correct! {cpuGuess} is what I was thinking! Guesses:{counter}");
            else if (guess > cpuGuess) { Console.WriteLine("too high"); counter++; guessCPU(entry, cpuGuess, counter); }
            else if (guess < cpuGuess) { Console.WriteLine("too low"); counter++; guessCPU(entry, cpuGuess, counter); }
        }

        private static void MethodChoice2()
            {
            Console.WriteLine("Pick a Number between 1 and 100");
            int max = 101;
            int min = 0;
            int counter = 1;
            guessPlayer(max, min, counter);
            Console.ReadLine();
            }

        private static void guessPlayer(int highNum, int lowNum, int counter)
        {
            int guess = ((highNum - lowNum) / 2) + lowNum;
            Console.WriteLine($"is {guess} your number?");
            Console.WriteLine("1 = too high, 2 = too low, 3 = Thats my number");
            int response = Int32.Parse(Console.ReadLine());
                if (response == 1)
                {
                    counter++;
                    guessPlayer(guess, lowNum, counter);
                    
                }
                else if (response == 2)
                {
                    counter++;
                    guessPlayer(highNum, guess, counter);
                    
                }
                else if (response == 3)
                {
                Console.WriteLine($"It took me {counter} guesses");
                }
                else
                {
                    Console.WriteLine("Thats not an available response - try again");
                }

        }
    }
}
