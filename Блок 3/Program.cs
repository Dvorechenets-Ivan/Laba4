using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace блок_3
{
    internal class Program
    {
        static void Output(int[][] massiv)
        {
            for (int i = 0; i < massiv.GetLength(0); i++)
            {
                for (int j = 0; j < massiv[i].GetLength(0); j++)
                {
                    Console.Write(massiv[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void NewRow(int[][] array, int cols, int rowind)
        {
            Console.WriteLine("Спосiб заповнення: 1- заповнити новий рядок нулями 2 - заповнити вручну");
            int x = int.Parse(Console.ReadLine());
            int count = 0;
            switch (x)
            {
                case 1:
                    int[] addedrow = new int[cols];
                    for (int i = 0; i < addedrow.Length; i++)
                    {
                        addedrow[i] = 0;
                    }
                    int[][] massiv = new int[array.GetLength(0) + 1][];

                    for (int i = 0; i < massiv.GetLength(0); i++)
                    {
                        massiv[i] = new int[cols];
                        if (i == rowind)
                        {
                            massiv[i] = addedrow;
                        }
                        else
                        {
                            massiv[i] = array[count];
                            count++;
                        }
                    }
                    Output(massiv);
                    break;
                case 2:
                    string[] newrow = Console.ReadLine().Split(' ');
                    addedrow = new int[cols];
                    for (int i = 0; i < addedrow.Length; i++)
                    {
                        addedrow[i] = int.Parse(newrow[i]);
                    }
                    massiv = new int[array.GetLength(0) + 1][];
                    for (int i = 0; i < massiv.GetLength(0); i++)
                    {
                        massiv[i] = new int[cols];
                        if (i == rowind)
                        {
                            massiv[i] = addedrow;
                        }
                        else
                        {
                            massiv[i] = array[count];
                            count++;
                        }
                    }
                    Output(massiv);
                    break;
            }
        }
        static int[][] RandomMet(int number, int cols)
        {
            Random random = new Random();
            int[][] array = new int[number][];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {

                    array[i][j] = random.Next(-151, 151);
                }
            }
            Output(array);
            Console.WriteLine();
            return array;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть розмiрнiсть  масиву");
            string[] data = Console.ReadLine().Split(' ');
            int rows = int.Parse(data[0]);
            int cols = int.Parse(data[1]);
            int[][] array = new int[rows][];
            int rowind = 1;
            Console.WriteLine("Введіть масив 1- вручну 2- рандомно");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:

                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write($"Заповнення  рядка {rowind}: ");
                        string[] values = Console.ReadLine().Trim().Split(' ');
                        array[i] = new int[cols];
                        for (int j = 0; j < values.Length; j++)
                        {
                            array[i][j] = int.Parse(values[j]);
                        }
                        for (int j = values.Length; j < cols; j++)
                        {
                            array[i][j] = 0;
                        }
                        rowind++;
                    }
                    break;
                case 2:
                    array = RandomMet(rows, cols);
                    break;
            }

            rowind = 0;//буде виступати рядком де знаходиться максимальний елемент
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].GetLength(0); j++)
                {
                    if (array[i][j] >= max)
                    {
                        max = array[i][j];
                        rowind = i;
                    }
                }
            }
            NewRow(array, cols, rowind);

        }
    }
}