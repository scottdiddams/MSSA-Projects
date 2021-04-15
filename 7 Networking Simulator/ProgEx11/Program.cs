using System;

namespace ProgEx11
{
    class Program
    {
        static void Main(string[] args)
        {

            bool startMenu = true;
            while (startMenu)
            {
                startMenu=start();
            }

            Environment.Exit(0);
        }

        private static bool start()
        {
            Console.WriteLine("See the following Options:");
            Console.WriteLine("1: run network sort simulation");
            Console.WriteLine("2: Exit");
            int selection = Int32.Parse(Console.ReadLine());

            if (selection == 1)
            {
                Execute();
                return true;
            }
            else
            {
                
                return false;
            }

        }

        private static void Execute()
        {
            int[][] points = Calculate.create2Points();

            //TEST:
            //int[] arrA = { points[1][0], points[1][1] };
            //int[] arrB = { points[2][0], points[2][1] };
            //Console.WriteLine($"a = ({arrA[0]},{arrA[1]}) b = ({arrB[0]},{arrB[1]})");
            //Console.WriteLine($"Distance between a & b is {Calculate.twoDimDist(arrA,arrB)}" );
            //Console.ReadLine();

            Calculate.closest2Points(points);
            Console.ReadLine();

            int[][] threePoints = Calculate.create3Points();
            Calculate.closest3Points(threePoints);
            Console.ReadLine(); ;
        }
    }

    class Calculate
    {
        public static double twoDimDist(int[] arrA, int[] arrB)
        {
            int a = arrA[0] - arrB[0];
            int b = arrA[1] - arrB[1];
            double dist = Math.Sqrt((a * a) + (b * b));
            return dist;
        }
        public static double threeDimDist(int[] arrA, int[] arrB)
        {
            int a = arrA[0] - arrB[0];
            int b = arrA[1] - arrB[1];
            int c = arrA[2] - arrB[2];
            double dist = Math.Sqrt((a * a) + (b * b)+(c * c));
            return dist;
        }
        public static int[][] create2Points()
        {
            int[][] points = new int[100][];
            Random random = new Random();
            for(int i=0;i<points.Length; i++)
            {
                points[i] = new int[2] { random.Next(0, 101), random.Next(0, 101) };
            }
            return points;
        }
        public static int[][] create3Points()
        {
            int[][] points = new int[1000][];
            Random random = new Random();
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new int[3] { random.Next(0, 1001), random.Next(0, 1001), random.Next(0, 1001) };
            }
            return points;
        }
        public static void closest2Points(int[][] arr)
        {
            int[][] temp = new int[1][];
            int n = 0;
            for(int i=0; i < arr.Length-1; i++)
            {
                for (int j = i + 1; j < arr.Length-1;j++) 
                {
                    if (Calculate.twoDimDist(arr[i], arr[j]) > Calculate.twoDimDist(arr[i], arr[j+1]))
                    {
                        temp[0] = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp[0];
                        n++;
                    }
                }
            }
            Console.WriteLine($"The closest points are {arr[0][0]},{arr[0][1]} and {arr[1][0]},{arr[1][1]}");
            Console.WriteLine($"The distance between them is {twoDimDist(arr[0],arr[1])}");
            Console.WriteLine($"Number of comparrisons: {n}");
        }
        public static void closest3Points(int[][] arr)
        {
            int[][] temp = new int[1][];
            int n = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    if (Calculate.threeDimDist(arr[i], arr[j]) > Calculate.threeDimDist(arr[i], arr[j + 1]))
                    {
                        temp[0] = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp[0];
                        n++;
                    }
                }
            }
            Console.WriteLine($"The closest points are ({arr[0][0]},{arr[0][1]},{arr[0][2]}) and ({arr[1][0]},{arr[1][1]},{arr[1][2]})");
            Console.WriteLine($"The distance between them is {twoDimDist(arr[0], arr[1])}");
            Console.WriteLine($"Number of comparrisons: {n}");
        }
    }
}
