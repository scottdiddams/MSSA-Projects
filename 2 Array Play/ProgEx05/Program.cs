using System;

namespace ProgEx05
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayA = { 0, 2, 4, 6, 8, 10 };
            int[] arrayB = { 1, 3, 5, 7, 9 };
            int[] arrayC = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            Console.WriteLine("Array A");
            foreach (int i in arrayA)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine("");
            CalculateArray(arrayA);
            ReverseArray(arrayA);
            RotateArray("left", 2, arrayA);


            Console.WriteLine("--------------------");
            Console.WriteLine("Array B:");
            foreach (int i in arrayB)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine("");
            CalculateArray(arrayB);
            ReverseArray(arrayB);
            RotateArray("right", 2, arrayB);


            Console.WriteLine("--------------------");
            Console.WriteLine("Array C:");
            foreach (int i in arrayC)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine("");
            CalculateArray(arrayC);
            ReverseArray(arrayC);
            RotateArray("left", 4, arrayC);
            SortArray(arrayC);
            Console.WriteLine("This array Sorted from smallest to greatest is:");
            foreach (int i in arrayC)
            {
                Console.Write($"{i}, ");
            }
            Console.ReadLine();

        }

        private static int[] SortArray(int[] array)
        {
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int big = array[i];
                    int small = array[i + 1];

                    array[i] = small;
                    array[i + 1] = big;
                    SortArray(array);
                }
            }
            return array;
            
        }

        private static void RotateArray(string dir, int space, int[] array)
        {
            Console.WriteLine($"This Array rotated to the {dir} by {space} spaces is:");
            if (dir == "left")
            {
                int[] leftArray = new int[array.Length - space]; //leftArrayA has 4 elements 0000
                for (int i = space, j = 0; i < array.Length; i++, j++) 
                {
                    leftArray[j] = array[i]; //leftArrayA gets 4,6,8,10
                }
                for (int i = space, j = 0; i < array.Length; i++, j++) 
                {
                    array[i] = array[j]; //arrayA[i] gets i[0]=0 i[1]=2|j[2]=0 j[3]=2 02|02 - arrayC gets 3141|3141
                }
                for (int i = 0; i < leftArray.Length; i++)
                {
                    array[i] = leftArray[i]; //arrayA[i] gets 4,6,8,10|0,2
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]}, ");
                }
                Console.WriteLine("");
            }
            if (dir == "right")
            {
                int[] rightArray = new int[array.Length];

                for (int i = 0; i < rightArray.Length; i++)
                {
                    rightArray[i] = array[i];
                }

                for (int i = 0, j = rightArray.Length - space; j < rightArray.Length; i++, j++)
                {
                    array[i] = rightArray[j];
                }

                for (int i = space, j = 0; i < array.Length; i++, j++)
                {
                    array[i] = rightArray[j];
                }

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]}, ");
                }
                Console.WriteLine("");


            }

        }
    

        private static void ReverseArray(int[] array)
        {
            Console.WriteLine("This array in reverse is:");
            for (int i=array.Length-1; i>=0; i--)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine("");
        }

        private static void CalculateArray(int[] array)
        {
            int sum = 0;
            double mean = 0.0;

            Console.WriteLine($"There are {array.Length} elements in this array");

            for (int i=0; i <= array.Length -1 ; i++)
            {
                sum = array[i] + sum;
            }
            Console.WriteLine($"The sum of the elements in this array is {sum}");
            mean = Convert.ToDouble(sum) / array.Length;
            Console.WriteLine($"The mean of this array is {mean}");
        }
    }
}
