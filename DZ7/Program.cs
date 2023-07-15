namespace DZ7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(@"Выбери задачу
47: Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
50: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
52: Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
q - выход из программы");

            
            
                string select = Console.ReadLine();
                switch (select)
                {
                    case "47":
                        Zad47();
                        break;
                    case "50":
                        Zad50();
                        break;
                    case "52":
                        Zad52();
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
        }

        //
        //Создание вещественного массива
        //
        static double[,] CreateArray2m(int m, int n)
        {
            double[,] array2m = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array2m[i, j] = Math.Round(new Random().NextDouble()*10, 2);
                }
            }
            return array2m;
        }

        //
        //Вывод на экран вещественного массива
        //
        static void PrintArrayDouble(double[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //
        //Решение Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
        //
        static void Zad47()
        {
            double[,] array =  CreateArray2m(3, 4);
            PrintArrayDouble(array);

        }

        //
        //Решение Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
        //
        static void Zad50()
        {
            double[,] array = CreateArray2m(3, 4);
            PrintArrayDouble(array);

            Console.WriteLine("Введите столбец элемента массива, который нужно отобразить");
            int columnFindNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите строку элемента массива, который нужно отобразить");
            int rowsFindNumber = int.Parse(Console.ReadLine());

            string result = CheckArray(array, columnFindNumber, rowsFindNumber);
            Console.WriteLine(result);


        }

        //
        //Метод вывода элемента вещественного массива
        //
        static string CheckArray(double[,] array, int columnFindNumber, int rowsFindNumber)
        {
            //Проверяем, что числа входят в массив
            if (columnFindNumber >= 0 && columnFindNumber <= array.GetLength(0) 
                && rowsFindNumber >= 0 && rowsFindNumber <= array.GetLength(1)) 
            {

                return $"Элемент массива [{columnFindNumber} , {rowsFindNumber}] = {array[columnFindNumber, rowsFindNumber].ToString()}";
            }
            else
            {
                return "Извините, заданный массив не входит в диапазон текущего массива";
            }
        }

        //
        //Создание целочисленного массива
        //
        static int[,] CreateArray2mInt(int m, int n, int min, int max)
        {
            int[,] array = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = new Random().Next(min, max);
                }
            }
            return array;
        }

        //
        //Вывод на экран целочисленного массива
        //
        static void PrintArrayInt(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        //
        //Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
        //
        static void Zad52()
        {
            int[,] array = CreateArray2mInt(3, 4, 1, 100);
            PrintArrayInt(array);
            double avgColumns = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    avgColumns += (double) array[j, i];
                }
                Console.WriteLine($"Среднее арефметическое столбца - {i} = {Math.Round(avgColumns / array.GetLength(0), 2)}");
                avgColumns = 0;
            }


        }

    }
}