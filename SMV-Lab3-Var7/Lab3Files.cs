using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static SMV_Lab3_Var7.Lab3Files;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMV_Lab3_Var7
{
    public class Lab3Files
    {
        /*
         * Задания 4 – 8 выполнить в виде статических методов
         * 
         * В задании 4 бинарные файлы, содержат числовые данные, исходный файл необходимо заполнить 
         * случайными данными, заполнение организовать отдельным методом.
         * 
         * В задании 5 бинарные файлы содержат величины типа struct, заполнение исходного файла
         * необходимо организовать отдельным методом, обязательно использовать xml сериализацию, 
         * решение без сериализации не принимается.
         * 
         * В задании 6 в текстовом файле хранятся целые числа по одному в строке, исходный файл 
         * необходимо заполнить случайными данными, заполнение организовать отдельным методом.
         * 
         * В задании 7 в текстовом файле хранятся целые числа по несколько в строке, исходный файл 
         * необходимо заполнить случайными данными, заполнение организовать отдельным методом.
         * 
         * В задании 8 в текстовом файле хранится текст.
        */

        public static void FillTask4BinFile(string s)
        {
            BinaryWriter binwrt = null;
            InputCheck InputCheck = new InputCheck();
            Console.WriteLine("Сколько чисел будет в файле?");
            int n = InputCheck.CheckIntPlus();
            try
            {
                binwrt = new BinaryWriter(File.Open(s, FileMode.OpenOrCreate));
                var rand = new Random();

                for (int i = 0; i < n; i++)
                {
                    binwrt.Write(rand.Next(1, 100));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не смогли создать файл!");
            }
            finally
            {
                binwrt?.Close();
            }
        }

        //Задание 4 Бинарные файлы
        //Найти разность максимального и минимального элементов заданного файла.
        public static double Task4(string s)
        {
            BinaryReader binrdr = null;        
            try
            {
                binrdr = new BinaryReader(File.Open(s, FileMode.Open));

                string binText = "";
                int mn = Int32.MaxValue;
                int mx = Int32.MinValue;

                while (binrdr.PeekChar() > -1)
                {
                    int temp = binrdr.ReadInt32();
                    binText += temp + " ";
                    if (temp < mn)
                    {
                        mn = temp;
                    }
                    if (temp > mx)
                    {
                        mx = temp;
                    }
                }
                Console.WriteLine("Содержимое файла: " + binText);
                return mx - mn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не обнаружен!");
            }
            finally
            {
                binrdr?.Close();
            }
            return 0;
        }

        public struct Toy
        {
            public string name;
            public double price;
            public int minAge;
            public int maxAge;
        }

        // Через xml сериализацию, но файл - не бинарный!
        public static void WriteTask5ToyFile(string s)
        {
            try
            {
                InputCheck InputCheck = new InputCheck();
                int minCheck;
                int maxCheck;
                Console.WriteLine("Сколько игрушек?");
                int n = Convert.ToInt32(Console.ReadLine());
                Toy[] toys = new Toy[n];
                for (int i = 0; i < n; i++)
                {
                    Toy toy = new Toy();
                    Console.WriteLine("Имя игрушки:");
                    toy.name = Console.ReadLine();
                    Console.WriteLine("Цена игрушки:");
                    toy.price = InputCheck.CheckDoublePlus();
                    Console.WriteLine("Минимальный возраст для игрушки:");
                    toy.minAge = InputCheck.CheckIntPlus();
                    Console.WriteLine("Максимальный возраст для игрушки:");
                    toy.maxAge = InputCheck.CheckIntPlus();
                    while (toy.minAge > toy.maxAge)
                    {
                        Console.WriteLine("Некорректный диапазон возраста!");
                        Console.WriteLine("Минимальный возраст для игрушки:");
                        minCheck = InputCheck.CheckIntPlus();
                        Console.WriteLine("Максимальный возраст для игрушки:");
                        maxCheck = InputCheck.CheckIntPlus();
                        if (minCheck <= maxCheck)
                        {
                            toy.minAge = minCheck;
                            toy.maxAge = maxCheck;
                        }
                    }
                    toys[i] = toy;
                }
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Toy[]));
                using (TextWriter fs = new StreamWriter(s))
                {
                    xmlSerializer.Serialize(fs, toys);
                }
            }
            finally
            {
            }
        }

        public static Toy[] ReadTask5ToyFile(string s)
        {
            try
            {
                if (s!="")
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Toy[]));

                    using (FileStream fs = new FileStream(s, FileMode.Open))
                    {
                        return (Toy[])xmlSerializer.Deserialize(fs);
                    }
                }
                return null;
            }
            finally
            {
            }
        }

        public static void Task5(string s, int k)
        {
            Toy[] toys = ReadTask5ToyFile(s);
            if (toys !=null)
            {
                double maxprice = toys[0].price;
                for (int i = 1; i < toys.Length; i++)
                {
                    if (toys[i].price > maxprice) maxprice = toys[i].price;
                }

                Console.WriteLine("\nРезультат:");
                for (int i = 0; i < toys.Length; i++)
                {
                    if (toys[i].price >= maxprice - k) Console.WriteLine(toys[i].name);
                }
            }
        }

        //В задании 6 в текстовом файле хранятся целые числа по одному в строке
        public static void FillTask6TextFile(string s)
        {
            InputCheck InputCheck = new InputCheck();
            StreamWriter wstream = null;
            Console.WriteLine("Сколько целых чисел по одному в строке будет в файле?");
            int n = InputCheck.CheckIntPlus();
            try
            {
                wstream = new StreamWriter(s);               
                var rand = new Random();

                for (int i = 0; i < n; i++)
                {
                    wstream.WriteLine(rand.Next(1, 10));
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Не смогли создать файл!");
            }
            finally
            {
                wstream?.Close();
            }
        }

        // Задание 6 Текстовые файлы
        // Подсчитать количество вхождений максимального элемента в файл
        public static double Task6(string s)
        {
            StreamReader rstream = null;
            string line;
            int mx = Int32.MinValue;
            int cnt = 1;
            try
            {
                rstream = new StreamReader(s);
                string filText = "";
                line = rstream.ReadLine();
                while (line != null)
                {
                    bool success = int.TryParse(line, out int number);
                    if (success)
                    {
                        filText += line + "\n";
                        if (Convert.ToInt32(line) > mx)
                        {
                            mx = Convert.ToInt32(line);
                            cnt = 1;
                        }
                        else if (Convert.ToInt32(line) == mx)
                        {
                            cnt++;
                        }                   
                    }
                    line = rstream.ReadLine();
                }
                Console.WriteLine("Содержимое файла:\n" + filText);
                return cnt;
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не обнаружен!");
            }
            finally
            {
                rstream?.Close();
            }
            return 0;
        }

        //В задании 7 в текстовом файле хранятся целые числа по несколько в строке
        public static void FillTask7TextFile(string s)
        {
            InputCheck InputCheck = new InputCheck();
            StreamWriter wstream = null;
            Console.WriteLine("Сколько строк с целыми числами будет в файле?");
            int n = InputCheck.CheckIntPlus();
            int num;
            try
            {
                wstream = new StreamWriter(s);
                var rand = new Random();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Сколько целых чисел будет в строке?");
                    num = InputCheck.CheckIntPlus();
                    for (int j=0;j<num;j++)
                    {
                        wstream.Write(rand.Next(1, 10)+" ");
                    }
                    wstream.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не смогли создать файл!");
            }
            finally
            {
                wstream?.Close();
            }
        }

        // Задание 7 Текстовые файлы
        // Вычислить количество чётных элементов
        public static int Task7(string s)
        {
            StreamReader rstream = null;
            string line;
            int count = 0;
            try
            {
                rstream = new StreamReader(s);
                line = rstream.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    string[] splitNums = line.Split(" ");
                    foreach (string n in splitNums)
                    {                       
                        try
                        {
                            if ((Convert.ToInt32(n)) % 2 == 0)
                            {
                                count++;
                            }
                        }
                        catch { }
                    }
                    line = rstream.ReadLine();
                }
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не обнаружен!");
            }
            finally
            {
                rstream?.Close();
            }
            return 0;           
        }

        //Переписать в другой файл строки, содержащие заданную комбинацию символов. Например, 
        //строка «Сегодня старшеклассники выполняли ЕГЭ по информатике и ИКТ» содержит комбинацию «форма»
        public static void Task8(string s,string findcomb)
        {
            StreamReader rstream = null;
            StreamWriter wstream = new StreamWriter(s + "out.txt");
            string line;
            try
            {
                rstream = new StreamReader(s);
                line = rstream.ReadLine();
                while (line != null)
                {
                    if (line.ToLower().Contains(findcomb))
                    {
                        wstream.WriteLine(line);
                    }
                    line = rstream.ReadLine();
                }
                Console.WriteLine("Был создан файл " + s + "out.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не обнаружен!");
            }
            finally
            {
                rstream?.Close();
                wstream?.Close();
            }
        }
    }
}
