using SMV_Lab3_Var7;
using System;
using System.Data;

var InputCheck = new InputCheck();
int n;
int m;
string pathToFile;
Tasks123 result;
bool stopTasks = false;
string answer;

while (stopTasks==false)
{
    Console.WriteLine("\nСписок заданий:");
    for (int i = 1; i<9; i++)
    {
        if (i == 1) Console.Write(i + ".1   " + i + ".2   " + i + ".3   ");
        else Console.Write(i + "   ");
    }
    Console.WriteLine("\nКакое задание выполнить? Введите 0 чтобы прекратить выполнение заданий.");
    answer = Console.ReadLine();
    Console.Clear();
    switch (answer)
    {
        case "0":
            stopTasks = true;
            break;
        case "1.1":
            Console.WriteLine("Задание 1.7 (1)");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            Console.WriteLine("Введите число m:");
            m = InputCheck.CheckIntPlus();
            var Task1_1 = new Tasks123(n, m);
            Task1_1.Task1_1ByHand(Task1_1.Mas);
            break;
        case "1.2":
            Console.WriteLine("Задание 1.7 (2)");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            var Task1_2 = new Tasks123(n);
            Task1_2.Task1_2ByRandom(Task1_2.Mas);
            break;
        case "1.3":
            Console.WriteLine("Задание 1.7 (3)");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            var Task1_3 = new Tasks123(n);
            Task1_3.Task1_3ByPattern(Task1_3.Mas);
            break;
        case "2":
            Console.WriteLine("Задание 2.7");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            Console.WriteLine("Введите число m:");
            m = InputCheck.CheckIntPlus();
            var Task2 = new Tasks123(n, m);
            Task2.Task2ByRandom(Task2.Mas);
            Task2.Task2(Task2.Mas);
            break;
        case "3":
            Console.WriteLine("Задание 3");
            Console.WriteLine("Операция: 7*A*(Transpose(B) - C)"); // 7 * A * ( Bтранс - C )

            Console.WriteLine("Матрица А:");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            Console.WriteLine("Введите число m:");
            m = InputCheck.CheckIntPlus();
            var A = new Tasks123(n, m);
            A.Task3ByRandom(A.Mas);

            Console.WriteLine("Матрица B:");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            Console.WriteLine("Введите число m:");
            m = InputCheck.CheckIntPlus();
            var B = new Tasks123(n, m);
            B.Task3ByRandom(B.Mas);
            B = B.TransposeMatrix(B);

            Console.WriteLine("Матрица C:");
            Console.WriteLine("Введите число n:");
            n = InputCheck.CheckIntPlus();
            Console.WriteLine("Введите число m:");
            m = InputCheck.CheckIntPlus();
            var C = new Tasks123(n, m);
            C.Task3ByRandom(C.Mas);

            Console.WriteLine("\nРезультат:");
            result = 7 * A * (B - C);
            
            if (result != null)
            {
                Console.WriteLine(result);
            }
            else Console.WriteLine("Выражение не было высчитано.");
            
            break;
        case "4":
            Console.WriteLine("Задание 4.7");

            Console.WriteLine("Если хотите создать бинарный файл то введите 1");
            pathToFile = Console.ReadLine();
            if (pathToFile == "1")
            {
                Console.WriteLine("Как будет называться файл?");
                Lab3Files.FillTask4BinFile(Console.ReadLine());
            }
            Console.WriteLine("Введите название существующего файла:");
            Console.WriteLine("Разность максимального и минимального: " + Lab3Files.Task4(Console.ReadLine()));
            break;
        case "5":
            Console.WriteLine("Если хотите создать файл то введите 1");
            pathToFile = Console.ReadLine();
            if (pathToFile == "1")
            {
                Console.WriteLine("Как будет называться файл?");
                Lab3Files.WriteTask5ToyFile(Console.ReadLine());
            }
            Console.WriteLine("Введите название существующего файла:");
            pathToFile = Console.ReadLine();
            Console.WriteLine("На сколько может отличаться цена?");
            Lab3Files.Task5(pathToFile, InputCheck.CheckIntPlus());
            break;
        case "6":
            Console.WriteLine("Задание 6.7");
            Console.WriteLine("Если хотите создать текстовый файл то введите 1");
            pathToFile = Console.ReadLine();
            if (pathToFile == "1")
            {
                Console.WriteLine("Как будет называться файл?");
                Lab3Files.FillTask6TextFile(Console.ReadLine());
            }
            Console.WriteLine("Введите название существующего файла:");
            Console.WriteLine("Кол-во вхождений максимального элемента: " + Lab3Files.Task6(Console.ReadLine()));
            break;
        case "7":
            Console.WriteLine("Задание 7.7");
            Console.WriteLine("Если хотите создать текстовый файл то введите 1");
            pathToFile = Console.ReadLine();
            if (pathToFile == "1")
            {
                Console.WriteLine("Как будет называться файл?");
                Lab3Files.FillTask7TextFile(Console.ReadLine());
            }
            Console.WriteLine("Введите название существующего файла:");
            Console.WriteLine("Кол-во чётных элементов: " + Lab3Files.Task7(Console.ReadLine()));
            break;
        case "8":
            Console.WriteLine("Задание 8.7");
            Console.WriteLine("Введите файл или путь к нему:");
            pathToFile = Console.ReadLine();
            Console.WriteLine("Введите комбинацию:");
            string comb = Console.ReadLine();
            Lab3Files.Task8(pathToFile, comb);
            break;

        default:
            Console.WriteLine("Нет такого задания!");
            break;
    }
}