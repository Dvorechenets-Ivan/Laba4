using System;

namespace Блок_4
{
    internal class Program
    {

        static void BubleSort(ref int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                bool b = true;
                for (var j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        b = false;
                    }
                }
                if (b) break;
            }
        }
        static void ReversedBuble(ref int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                bool b = true;
                for (var j = 0; j < array.Length - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        b = false;
                    }
                }
                if (b) break;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть розмiрнiсть  масиву");
            string[] data = Console.ReadLine().Split(' ');
            int rows = int.Parse(data[0]);
            int cols = int.Parse(data[1]);
            if (rows % 2 != 0)
            {
                Console.WriteLine("Кiлькiсть рядкiв є не парною");
                return;
            }
            int[] max = new int[rows];
            int[][] array = new int[rows][];
            int maxelement;
            Inputelements(array, cols);
            for (int i = 0; i < rows; i++)
            {
                maxelement = int.MinValue;

                for (int j = 0; j < cols; j++)// 2 +1 <=3
                {

                    if (i % 2 == 0)
                    {
                        BubleSort(ref array[i]);
                    }
                    else
                    {
                        ReversedBuble(ref array[i]);
                    }
                    if (array[i][j] > maxelement)
                    {
                        maxelement = array[i][j];

                        max[i] = array[i][j];
                    }
                }
            }
            Console.WriteLine();
            Output(array, cols);
            Console.WriteLine("\n ", "Максимальнi елементи з кожного рядка");
            Singlemass(max);
            for (int i = 0; i < max.Length / 2; i++)
            {
                int temp = max[i];
                max[i] = max[max.Length - i - 1];
                max[max.Length - i - 1] = temp;

            }
            Console.WriteLine("\n Iнвертованi максимальнi елементи з кожного рядка");
            Singlemass(max);
        }

        static void Inputelements(int[][] array, int cols)
        {
            int counterofrow = 1;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Заповнить рядок {counterofrow}: ");
                string[] count = Console.ReadLine().Trim().Split(' ');
                if (count.Length > cols) { Console.WriteLine("Ви ввели число яке бiльше заданої розмiрностi"); return; }

                array[i] = new int[cols];
                for (int j = 0; j < count.Length; j++)
                {
                    array[i][j] = int.Parse(count[j]);
                }
                for (int j = count.Length; j < cols; j++)
                {
                    array[i][j] = 0;
                }
                counterofrow++;
            }
        }

        static void Output(int[][] array, int cols)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Singlemass(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
