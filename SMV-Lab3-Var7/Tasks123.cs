using SMV_Lab3_Var7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMV_Lab3_Var7
{
    internal class Tasks123
    {
        InputCheck IntCheck = new InputCheck();
        //поле двумерный массив
        public int[,] Mas { get; set; }

        public Tasks123(int n, int m)
        {
            Mas = new int[n, m];
        }

        public Tasks123(int n)
        {
            Mas = new int[n, n];
        }

        public void Print2Dmas(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Task1_1Normal(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = IntCheck.CheckInt();
                }
            }
            Print2Dmas(mas);
        }

        /*ручной ввод*/
        public void Task1_1ByHand(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);

            for (int j = 0; j < m; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    mas[i, j] = IntCheck.CheckInt();
                }
            }
            Print2Dmas(mas);
        }

        /*случайные числа*/
        public void Task1_2ByRandom(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            var rand = new Random();
            int temp = 0;

            //четырехзначные случайные числа, составленные из нечетных цифр

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    temp = rand.Next(1000, 10000);
                    while (((temp / 1000) % 2 == 0) || ((temp / 100 % 10) % 2 == 0) || ((temp / 10 % 100) % 2 == 0) || ((temp % 1000) % 2 == 0))
                    {
                        temp = rand.Next(1000, 10000);
                    }
                    mas[i, j] = temp;
                }
            }
            Print2Dmas(mas);
        }

        /*заполнение узором*/
        public void Task1_3ByPattern(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            int k = n - 1;

            //узор
            for (int i = 0; i < n; i++)
            {
                for (int j = m - 1; j >= k; j--)
                {
                    if ((i + j) % 2 == 0)
                    {
                        mas[i, j] = n - j;
                    }
                    else
                    {
                        mas[i, j] = n - i;
                    }
                }
                k--;
            }
            Print2Dmas(mas);
        }

        public void Task2ByRandom(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rand.Next(1, 10);
                }
            }
            Print2Dmas(mas);
        }

        public void Task2(int[,] mas)
        {
            // В двумерном массиве n х m найдите среднее арифметическое первого столбца и
            // количество элементов в каждом из следующих столбцов превышающих среднее арифметическое предыдущего столбца
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);

            if (m < 2)
            {
                Console.WriteLine("У вас только один столбец!");
                return;
            }
            else
            {
                double average = 0;
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    average += mas[i, 0];
                }
                average /= n;
                Console.WriteLine("Среднее арифметическое первого столбца: " + average);
                for (int j = 1; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (mas[i, j] > average) count++;
                    }
                    Console.WriteLine("Количество элементов в столбце " + (j + 1) + ", превыщающих среднее арифметическое предыдущего столбца: " + count);
                    count = 0;
                    average = 0;
                    for (int i = 0; i < n; i++)
                    {
                        average += mas[i, j];
                    }
                    average /= n;
                }
            }
        }

        public void Task3ByRandom(int[,] mas)
        {
            int n = mas.GetLength(0);
            int m = mas.GetLength(1);
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = rand.Next(1, 6);
                }
            }
            Print2Dmas(mas);
        }

        public Tasks123 TransposeMatrix(Tasks123 Object)
        {
            if (Object == null) { return null; }

            int n = Object.Mas.GetLength(0);
            int m = Object.Mas.GetLength(1);
            Tasks123 newMatrix = new Tasks123(m, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    newMatrix.Mas[j, i] = Mas[i, j];
                }
            }

            return newMatrix;
        }

        public static Tasks123 operator *(int con, Tasks123 Object)
        {
            if (Object == null) return null;

            int n = Object.Mas.GetLength(0);
            int m = Object.Mas.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Object.Mas[i, j] = Object.Mas[i, j] * con;
                }
            }
            return Object;
        }

        public static Tasks123 operator *(Tasks123 Object1, Tasks123 Object2)
        {
            if ((Object1 == null) || (Object2 == null)) return null;

            int n = Object1.Mas.GetLength(0);
            int m = Object1.Mas.GetLength(1);
            int a = Object2.Mas.GetLength(0);
            int b = Object2.Mas.GetLength(1);
            if (m == a)
            {
                Tasks123 newMatrix = new Tasks123(n, b);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            newMatrix.Mas[i, j] += Object1.Mas[i, k] * Object2.Mas[k, j];
                        }
                    }
                }
                return newMatrix;
            }
            else
            {
                Console.WriteLine("Ошибка! Количество строк 1-ой матрицы должно быть равно количеству столбцов 2-ой матрицы!");
                return null;
            }
        }

        public static Tasks123 operator -(Tasks123 Object1, Tasks123 Object2)
        {
            if ((Object1 == null) || (Object2 == null)) return null;

            int n = Object1.Mas.GetLength(0);
            int m = Object1.Mas.GetLength(1);
            int a = Object2.Mas.GetLength(0);
            int b = Object2.Mas.GetLength(1);
            if ((n == a) && (m == b))
            {
                Tasks123 newMatrix = new Tasks123(n, m);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        newMatrix.Mas[i, j] = Object1.Mas[i, j] - Object2.Mas[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                Console.WriteLine("Ошибка! Матрицы должны быть одного размера!");
                return null;
            }
        }
        
        public override string ToString()
        {
            int n = Mas.GetLength(0);
            int m = Mas.GetLength(1);
            string printedMas = "";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    printedMas += Mas[i, j] + " ";
                }
                printedMas += "\n";
            }
            return printedMas;
        }
    }
}
