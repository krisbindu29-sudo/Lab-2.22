using System;

namespace Lab2_Task2
{
   
    class Program
    {
        
        // Повертає значення double або викидає виключну ситуацію за потреби
        static double F(double x)
        {
            
            // але ми додаємо перевірку на коректність аргументу x (не NaN / не нескінченність)
            if (double.IsNaN(x) || double.IsInfinity(x))
            {
                throw new ArgumentException("Некоректний аргумент x!");
            }

            double result = Math.Cos(x) * Math.Sin(x);

            // Перевірка на невизначеність результату обчислення
            if (double.IsNaN(result) || double.IsInfinity(result))
            {
                throw new ArithmeticException("Виникла виключна ситуація під час обчислення f(x)!");
            }

            return result;
        }

        
        static void CalculateWithWhile(double a, double b, double dx)
        {
            Console.WriteLine("\n--- Обчислення за допомогою циклу while ---");
            
            Console.WriteLine("|    X       |   y=f(x)  |");
           

            double x = a; // Початкове значення аргументу

            // dx / 2.0 додається для уникнення втрати останнього кроку через похибку double
            while (x <= b + dx / 2.0)
            {
                // Конструкція try-catch для обробки можливих виключних ситуацій
                try
                {
                    double y = F(x);
                    Console.WriteLine($"| {x,10:F4} | {y,9:F4} |");
                }
                catch (Exception ex)
                {
                    // У разі виключної ситуації виводимо повідомлення про помилку замість значення
                    Console.WriteLine($"| {x,10:F4} | {"Помилка",9} |");
                }

                x += dx; // Крок зміни аргументу
            }

            
        }

        // Обчислення та виведення у табличному вигляді за допомогою циклу з післяумовою (do...while)
        static void CalculateWithDoWhile(double a, double b, double dx)
        {
            Console.WriteLine("\n--- Обчислення за допомогою циклу do...while ---");
           
            Console.WriteLine("|    X       |   y=f(x)  |");
           

            double x = a; // Початкове значення аргументу

            // Цикл із післяумовою виконання
            do
            {
                // Конструкція try-catch для перехоплення виключень
                try
                {
                    double y = F(x);
                    Console.WriteLine($"| {x,10:F4} | {y,9:F4} |");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"| {x,10:F4} | {"Помилка",9} |");
                }

                x += dx; // Крок зміни аргументу
            } while (x <= b + dx / 2.0);

           
        }

        // Точка входу в програму — метод Main (розміщений у самому кінці класу)
        static void Main(string[] args)
        {
            // Налаштування UTF-8 для українських символів
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Вхідні дані згідно з Варіантом 9
            double a = -Math.PI;
            double b = Math.PI;
            double dx = Math.PI / 10.0;

            while (true)
            {
               

                Console.WriteLine("Натисніть Enter для табуляції функції або введіть 0 для виходу:");
               

                string input = Console.ReadLine();

                // Вихід із циклу при введенні 0
                if (input.Trim() == "0")
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }

                Console.WriteLine($"\nРезультати обчислення y = cos(x)*sin(x) на [{a:F2}, {b:F2}] з кроком dx = {dx:F4}");

                
                CalculateWithWhile(a, b, dx);
                CalculateWithDoWhile(a, b, dx);
            }
        }
    }
}