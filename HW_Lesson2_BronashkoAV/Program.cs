using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Lesson2_BronashkoAV
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в программу!");
            System.Threading.Thread.Sleep(1000);
            Login();
            Console.ReadKey();
        }

        static int ReadLineAndConvertationToInt()
        {
            bool isInt = false;
            int res;
            do
            {
                string s = Console.ReadLine();
                isInt = Int32.TryParse(s, out res);
                if (!isInt) Console.WriteLine("Вы ввели не число! повторите попытку!");
            } while (!isInt);
            return res;
        }

        static float ReadLineAndConvertationToFloat()
        {
            bool isFloat = false;
            float res;
            do
            {
                string s = Console.ReadLine();
                isFloat = float.TryParse(s, out res);
                if (!isFloat) Console.WriteLine("Вы ввели не число! повторите попытку!");
            } while (!isFloat);
            return res;
        }

        static void Login(string login="root", string password="GeekBrains")
        {
            int i = 0;
            do
            {
                Console.WriteLine("Введите логин:");
                string loginTest = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                string passwordTest = Console.ReadLine();
                bool flag = (loginTest == login && passwordTest == password) ? true : false;
                if (flag)
                {
                    Console.WriteLine("Welcome!!!");
                    System.Threading.Thread.Sleep(1000);
                    MainMenu();
                }
                else
                {
                    Console.WriteLine($"Логин или пароль не совпадают! Повторите попытку!\nУ вас осталось {2 - i} попыток");
                    System.Threading.Thread.Sleep(1000);
                }
                i++;
            } while (i < 3);
            Console.WriteLine("Вы превысили максимально допустимое количество попыток! До свидания!");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);

        }

        static void wait()
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        static void Minimal(float a, float b, float c)
        {
            float min = (a <= b && a <= c) ? a : (b <= a && b <= c) ? b : c;
            Console.WriteLine("Минимальное число: " + min);            
        }

        static void Amount(string s)
        {
            char[] ch = s.ToCharArray();
            int count = ch.Length;
            Console.WriteLine($"В строке {count} символов.");
        }

        static void SumOfOdd()
        {
            int sum = 0;
            int temp=0;
            do
            {
                temp = ReadLineAndConvertationToInt();
                sum = (temp % 2 != 0 && temp > 0) ? sum+temp : sum;
            } while (temp != 0);
            Console.WriteLine("Сумма положительных нечетных чисел раввна: " + sum);
        }

        static void Index()
        {
            float ideal, index;
            bool delta;
            Console.WriteLine("Введите вашу массу в кг:");
            float weight = ReadLineAndConvertationToFloat();
            Console.WriteLine("Введите ваш рост в см:");
            float height = ReadLineAndConvertationToFloat();
            index = weight / ((height/100)* (height / 100));
            ideal = (height - 105) * 1.15f;
            delta = (ideal - weight) > 0 ? true : false;
            if (delta) Console.WriteLine($"Индекс массы вашего тела составляет: {index}, для идеального веса вам нужно поправиться на {ideal - weight} кг.");
            else if (!delta) Console.WriteLine($"Индекс массы вашего тела составляет: {index}, для идеального веса вам нужно похудеть на {weight - ideal} кг.");
        }

        static void Good()
        {
            DateTime start, finish;
            TimeSpan delta;
            int good=0;
            start = DateTime.Now;
            for (int i = 1; i < 10000000; i++)
            {
                int sum=0;
                int[] digits = i.ToString().Select(digit => int.Parse(digit.ToString())).ToArray();
                for(int j = 0; j < digits.Length; j++)
                {
                    sum += digits[j];
                }
                if (i % sum == 0) good++;                
            }
            finish = DateTime.Now;
            delta = finish - start;
            Console.WriteLine($"от 1 до 10000000 {good} хороших чисел.\nПодсчет занял {delta} времени.");
        }

        static void Recurs(int a, int b, int sum=0)
        {            
            if (a < b)
            {
                Console.WriteLine(a);
                sum += a;
                Recurs(a+1, b, sum);
            }
            else
            {
                Console.WriteLine(sum);
            }
        }

        static void MainMenu()
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Это главное меню!\nВыберите пункт меню и введите соответствующую цифру:");
            Console.WriteLine("1)Минимальное из 3 чисел");
            Console.WriteLine("2)Подсчет количества символов в строке");
            Console.WriteLine("3)Сумма положительных нечетных");
            Console.WriteLine("4)Индекс массы тела");
            Console.WriteLine("5)Подсчет хороших чисел");
            Console.WriteLine("6)Рекурсия");
            Console.WriteLine("7)В разработке...");
            Console.WriteLine("8)В разработке...");
            Console.WriteLine("9)В разработке...");
            Console.WriteLine("0)Выйти");
            int flagMenu = ReadLineAndConvertationToInt();
            flagMenu = (flagMenu < 9) ? flagMenu : 9;
            switch (flagMenu)
            {
                case 1:
                    Console.WriteLine("введите поочередно 3 числа, а программа определит минимальное из них:");
                    Minimal(ReadLineAndConvertationToFloat(), ReadLineAndConvertationToFloat(), ReadLineAndConvertationToFloat());
                    wait();
                    MainMenu();
                    break;
                case 2:
                    Console.WriteLine("Введите что угодно, а мы подсчитаем количество символов:");
                    Amount(Console.ReadLine());
                    wait();
                    MainMenu();
                    break;
                case 3:
                    SumOfOdd();
                    wait();
                    MainMenu();
                    break;
                case 4:
                    Index();
                    wait();
                    MainMenu();
                    break;
                case 5:
                    Good();
                    wait();
                    MainMenu();
                    break;
                case 6:
                    Recurs(ReadLineAndConvertationToInt(), ReadLineAndConvertationToInt());
                    wait();
                    MainMenu();
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine("Данный пункт находится в разработке..\nВозврат к главному меню..");
                    wait();
                    MainMenu();
                    break;
                case 0:
                    Console.WriteLine("До свидания!");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
