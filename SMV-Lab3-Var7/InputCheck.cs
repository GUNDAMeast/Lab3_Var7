using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace SMV_Lab3_Var7
{
    class InputCheck
    {
        public double CheckDouble()
        {
            Console.WriteLine("Введите вещественное число: (через запятую)");
            string input = Console.ReadLine();
            while (double.TryParse(input, out _) == false)
            {
                Console.WriteLine("Невозможно принять это за вещественное число.\nДавайте ещё раз:");
                input = Console.ReadLine();
            }
            return Convert.ToDouble(input);
        }

        public char CheckNumChar()
        {
            Console.WriteLine("Введите числовой символ:");
            string input = Console.ReadLine();
            while ((char.TryParse(input, out _) == false) || (Char.IsDigit(Convert.ToChar(input)) == false))
            {
                Console.WriteLine("Невозможно принять это за числовой символ.\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToChar(input);
        }

        public int CheckInt()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();
            while (int.TryParse(input, out _) == false)
            {
                Console.WriteLine("Невозможно принять это за целое число.\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }

        public long CheckLong()
        {
            Console.WriteLine("Введите целое число:");
            string input = Console.ReadLine();
            while (long.TryParse(input, out _) == false)
            {
                Console.WriteLine("Невозможно принять это за расширенное целое число.\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToInt64(input);
        }
        
        public int[] CheckIntMas()
        {
            Console.WriteLine("Введите количество чисел в массиве:");
            int[] mas = new int[CheckIntForMas()];
            for (int i=0;i<mas.Length;i++)
            {
                mas[i] = CheckInt();
            }       
            PrintMas(mas);
            return mas;
        }

        public int CheckIntForMas()
        {
            Console.WriteLine("Введите положительное целое число:");
            string input = Console.ReadLine();
            while ((int.TryParse(input, out _) == false) || (Convert.ToInt32(input) <= 0))
            {
                Console.WriteLine("Невозможно принять это за положительное целое число.\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }

        public void PrintMas(int[] x)
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();
        }

        public int CheckIntPos(int[] x)
        {
            Console.WriteLine("Введите число. отражающее позицию в массиве:");
            string input = Console.ReadLine();
            while ((int.TryParse(input, out _) == false) || (Convert.ToInt32(input) > x.Length))
            {
                Console.WriteLine("Невозможно принять такое число.\nВ вашем массиве эелементов всего "+x.Length+".\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }

        public int CheckIntPlus()
        {
            Console.WriteLine("Введите положительное целое число:");
            string input = Console.ReadLine();
            while ((int.TryParse(input, out _) == false) || (Convert.ToInt32(input) <= 0))
            {
                Console.WriteLine("Невозможно принять это за положительное целое число.\nДавайте ещё раз:\n");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);
        }

        public double CheckDoublePlus()
        {
            Console.WriteLine("Введите положительное вещественное число: (через запятую)");
            string input = Console.ReadLine();
            while ((double.TryParse(input, out _) == false) || (Convert.ToDouble(input) <= 0))
            {
                Console.WriteLine("Невозможно принять это за положительное вещественное число.\nДавайте ещё раз:");
                input = Console.ReadLine();
            }
            return Convert.ToDouble(input);
        }

        public bool IsInRange(int a, int b, int num)
        {
            return (num >= a) & (num <= b);
        }
    }
}
