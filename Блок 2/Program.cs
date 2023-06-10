using System;

namespace Блок_2
{
    class YourClass
    {
        static void Main()
        {
            Console.WriteLine("Введіть єдине натуральне число");
            
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            Console.WriteLine("0 : ");
            for (int i = 1; i < n; i++)
            {
                int count = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (j % SumOfNumbers(i) == 0)
                    {
                        count++;
                    }
                }
                matrix[i] = new int[count];
                int a = 0;
                for (int m = 1; m <= n; m++)
                {
                    if (SumOfNumbers(i) == m && i > 9)
                    {
                        matrix[i] = matrix[SumOfNumbers(i)];
                        break;
                    }
                    if (m % SumOfNumbers(i) == 0)
                    {
                        matrix[i][a] = m;
                        a++;
                    }
                }
                Console.Write($"{i} : ");
                PrintCal(matrix[i]);
                Console.WriteLine();
            }
        }

        static int SumOfNumbers(int i)
        {
            int sum = 0;
            do
            {
                sum += Math.Abs(i % 10);
                i = Math.Abs(i / 10);
            } while (i / 10 != 0);
            sum += i;
            return sum;
        }

        static void PrintCal(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write($"{element} ");
            }
        }
    }
}

