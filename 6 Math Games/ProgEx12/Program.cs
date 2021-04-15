using System;

namespace ProgEx12
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                Console.Clear();
                menu = mainMenu();
            }
        }

        private static bool mainMenu()
        {
            Console.WriteLine("Welcome to Math Games Choose below:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Division");
            Console.WriteLine("4. Multiplication");
            Console.WriteLine("5: Exit");

            int select = Int32.Parse(Console.ReadLine());

            switch (select)
            {
                case 1:
                    addGame();
                    return true;
                case 2:
                    subtractGame();
                    return true;
                case 3:
                    divGame();
                    return true;
                case 4:
                    prodGame();
                    return true;
                default:
                    return false;
            }
        }

        private static void prodGame()
        {
            Console.WriteLine("How many problems do you want to attempt? Enter an integer:");
            int cardCount = Int32.Parse(Console.ReadLine());
            Random random = new Random();
            int c = 0;
            for (int i = 1; i <= cardCount; i++)
            {
                int left = random.Next(0, 13);
                int right = random.Next(0, 13);
                int answer = (left * right);
                Console.WriteLine($"What is {left} X {right}:");
                int entry = Int32.Parse(Console.ReadLine());
                if (Math.Abs(answer - entry) < 0.9)
                {
                    c++;
                    Console.WriteLine($"Correct! good job, {c} out of {i} answered correctly");
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer is: {answer}");
                }
            }
            Console.WriteLine($"You answered {c} of {cardCount} correct");
            Console.ReadLine();
        }

        private static void divGame()
        {
            Console.WriteLine("How many problems do you want to attempt? Enter an integer:");
            int cardCount = Int32.Parse(Console.ReadLine());
            Random random = new Random();
            int c = 0;
            for (int i = 1; i <= cardCount; i++)
            {
                decimal left = Decimal.Round(random.Next(0, 13),1);
                decimal right = Decimal.Round(random.Next(0, 13),1);
                decimal answer = Decimal.Round((left/right),2);
                Console.WriteLine($"What is {left}/{right}:");
                decimal entry = decimal.Parse(Console.ReadLine());
                decimal diff = Math.Abs(answer - entry);

                if (diff < 0.5M)
                {
                    c++;
                    Console.WriteLine($"Correct! good job, {c} out of {i} answered correctly");
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer is: {answer}");
                }
            }
            Console.WriteLine($"You answered {c} of {cardCount} correct");
            Console.ReadLine();
        }

        private static void subtractGame()
        {
            Console.WriteLine("How many problems do you want to attempt? Enter an integer:");
            int cardCount = Int32.Parse(Console.ReadLine());
            Random random = new Random();
            int c = 0;
            for (int i = 1; i <= cardCount; i++)
            {
                int left = random.Next(0, 13);
                int right = random.Next(0, 13);
                int answer = (left - right);
                Console.WriteLine($"What is {left} - {right}:");
                int entry = Int32.Parse(Console.ReadLine());
                if (Math.Abs(answer - entry) < 0.9)
                {
                    c++;
                    Console.WriteLine($"Correct! good job, {c} out of {i} answered correctly");
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer is: {answer}");
                }
            }
            Console.WriteLine($"You answered {c} of {cardCount} correct");
            Console.ReadLine();
        }

        private static void addGame()
        {
            Console.WriteLine("How many problems do you want to attempt? Enter an integer:");
            int cardCount = Int32.Parse(Console.ReadLine());
            Random random = new Random();
            int c = 0;
            for(int i=1; i<=cardCount; i++)
            {
                int left = random.Next(0, 13);
                int right = random.Next(0, 13);
                int answer = (left + right);
                Console.WriteLine($"What is {left} + {right}:");
                int entry = Int32.Parse(Console.ReadLine());
                if (Math.Abs(answer - entry) < 0.9)
                {
                    c++;
                    Console.WriteLine($"Correct! good job, {c} out of {i} answered correctly");
                }
                else
                {
                    Console.WriteLine($"Incorrect, the answer is: {answer}");
                }
            }
            Console.WriteLine($"You answered {c} of {cardCount} correct");
            Console.ReadLine();

        }
    }
}
