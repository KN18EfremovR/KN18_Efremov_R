using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, result;
            char oper;

            Console.WriteLine("Введите первое число");
            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите оператор");
            oper = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Введите второе число");
            b = Convert.ToDouble(Console.ReadLine());

            if (oper == '+')
            {
                result = a + b;
                Console.WriteLine(a + "+" + b + "=" + result);
            }
            else if (oper == '-')
            {
                result = a - b;
                Console.WriteLine(a + "-" + b + "=" + result);
            }
            else if (oper == '*' )
            {
                result = a * b;
                Console.WriteLine(a + "*" + b + "=" + result);
            }
            else if (oper == '/')
            {
                result = a / b;
                Console.WriteLine(a + "/" + b + "=" + result);
            }
            else if (oper == '=')
            {
                result = a;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Неизвестный оператор");
            }

        }
    }
}