using System;

namespace Блок_1
{
    partial class Program
    {
        static void ResizeMass(ref int[] array)
        {
            Console.WriteLine("Введiть скiльки елементiв треба знищити");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Bведiть з якого елемента K");
            int k = int.Parse(Console.ReadLine());
            if (k < 0)
            {
                Console.WriteLine();
                return;
            }
            int count = 0;
            for (int i = k - 1; i < array.Length; i++)
            {
                if (count != t)
                {
                    count++;
                    array[i] = int.MinValue;
                }
                else
                {
                    break;
                }
            }
            int[] massiv = new int[array.Length - count];
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != int.MinValue)
                {
                    massiv[count] = array[i];
                    count++;
                }
            }
            Output(massiv);
        }

        static void Output(int[] massiv)
        {
            foreach (int i in massiv)
            {
                Console.Write(i + " ");
            }
        }

        static int[] RandomMet(ref int number)
        {
            Random random = new Random();
            int[] array = new int[number];
            for (int i = 0; i < number; i++)
            {
                array[i] = random.Next(-101, 101);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            return array;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть спосіб вводу 1 - рандомно 2 - вручну");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.WriteLine("Введіть кількість елементів масиву");
                    int number = int.Parse(Console.ReadLine());
                    int[] array = new int[number];
                    array = RandomMet(ref number);
                    ResizeMass(ref array);
                    break;
                case 2:
                    Console.WriteLine("Введiть масив");
                    array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                    ResizeMass(ref array);
                    break;
            }
        }
    }
}
