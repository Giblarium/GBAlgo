using System;

namespace GBAlgo
{
    internal class Program
    {
        public static int[,] matrix = new int[7, 7]; // 14, 20

        static void Main(string[] args)
        {
            //добавление препятствий
            matrix[1, 1] = -1;
            matrix[4, 2] = -1;
            matrix[2, 5] = -1;
            matrix[3, 5] = -1;
            matrix[0, 3] = -1;

            bool exit;
            //PrtinMatrix();

            do
            {
                Console.Clear();
                PrtinMatrix();
                exit = true;
                //ввод номера строки
                Console.Write($"Введите номер строки от 1 до {matrix.GetLength(1)}:\t ");
                exit = int.TryParse(Console.ReadLine(), out int columns);
                if (columns < 0 || columns > matrix.GetLength(1))
                {
                    Console.WriteLine("Введеный номер строки за пределами массива!");
                    Console.ReadLine();
                    continue;
                }

                //ввод номера столбца
                Console.Write($"Введите номер столбца от 1 до {matrix.GetLength(0)}:\t ");
                exit = int.TryParse(Console.ReadLine(), out int rows);
                if (rows < 0 || rows > matrix.GetLength(0))
                {
                    Console.WriteLine("Введеный номер столбца за пределами массива!");
                    Console.ReadLine();
                    continue;
                }


                //вызов рекурсии
                int maxOptions = CountMaxOptions(rows - 1, columns - 1); // -1 для человекочитаемого ввода



                Console.WriteLine($"Количество вариантов для достижения позиции {rows} {columns}: {maxOptions}.");
                Console.ReadLine();


            } while (exit); //false, если не удалось преобразовать ввод в число или число вне размеров массива
        }

        //решение задачи
        private static int CountMaxOptions(int rows, int columns)
        {

            if (rows == 0 || columns == 0)
            {
                return 1;
            }
            if (matrix[columns, rows] == -1) // если препятствие, то вернуть ноль
            {
                return 0;
            }
            int res = CountMaxOptions(rows, columns - 1) + CountMaxOptions(rows - 1, columns);
            matrix[columns, rows] = res; //запись результата в массив
            //PrtinMatrix();
            return res;
        }

        //красивый вывод. Работает для массива до [7,7]
        private static void PrtinMatrix()
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i == 0)
                {
                    Console.Write($"  ");

                    for (int t = 0; t < matrix.GetLength(0); t++)
                    {
                        Console.Write($"|{t + 1,3}");
                    }
                    Console.Write($"|");
                    Console.WriteLine();

                }
                Console.Write($"{i + 1,2}");
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == -1)
                    {
                        Console.Write($"| X "); //типо препятствие
                    }
                    else
                    {
                        Console.Write($"|{matrix[j, i],3}");
                    }
                }
                Console.Write($"|");
                Console.WriteLine();
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    Console.Write("----");
                }
                Console.Write("---");
                Console.WriteLine();
            }
        }
    }
}
