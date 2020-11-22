using System;
using System.Collections.Generic;
using System.Text;

namespace LabBase
{
    class Cal
    {
        public static void Met2()
        {
            double a, b;
            char c;
            Console.WriteLine("Введите первый аргумент а ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите действие (+,-,*,/)");
            c = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Введите второй аргумент b ");
            b = Convert.ToDouble(Console.ReadLine());
            switch (c)
            {
                case '+':
                    Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
                    break;
                case '-':
                    Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
                    break;
                case '*':
                    Console.WriteLine("{0} * {1} = {2}", a, b, a * b);
                    break;
                case '/':
                    Console.WriteLine("{0} / {1} = {2}", a, b, a / b);
                    break;
                default:
                    Console.WriteLine("Ошибка");
                    break;
            }
            Console.ReadLine();
        }
        


    }
}
