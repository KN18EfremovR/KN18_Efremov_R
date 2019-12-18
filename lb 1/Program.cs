using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace lb_1
{
    [Serializable]

    public class Calc
    {
        public Calc()
        {

        }

        public double first_number;
        public double second_number;
        public string oper;
        public double result;

        public Calc(string oper, double first_number, double second_number)
        {
            this.first_number = first_number;
            this.second_number = second_number;
            this.oper = oper;
        }
        public double Results()
        {
            switch (oper)
            {
                case "+":
                    return result = first_number + second_number;
                    break;
                case "-":
                    return result = first_number - second_number;
                    break;
                case "*":
                    return result = first_number * second_number;
                    break;
                case "/":
                    return result = first_number / second_number;
                    break;
                default:
                    return 0;
                    break;
            }
        }
    }
    public class Eng_Calc : Calc
    {
        public Eng_Calc(string oper, double first_number, double second_number = 0)
        {
            this.first_number = first_number;
            this.second_number = second_number;
            this.oper = oper;
        }
        public Eng_Calc()
        {

        }
        public double Results()
        {
            switch (oper)
            {
                case "+":
                    return result = first_number + second_number;
                    break;
                case "-":
                    return result = first_number - second_number;
                    break;
                case "*":
                    return result = first_number * second_number;
                    break;
                case "/":
                    return result = first_number / second_number;
                    break;
                case "sin":
                    return result = Math.Sin(first_number);
                case "cos":
                    return result = Math.Sin(first_number);
                case "sqrt":
                    return result = Math.Sqrt(first_number);
                case "tan":
                    return result = Math.Tan(first_number);
                case "ctan":
                    return result = 1 / Math.Tan(first_number);
                default:
                    return 0;
                    break;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            char[] opers = { '+', '-', '*', '/' };
            string[] opers_ing = { "sin", "cos", "sqrt", "tan", "ctan" };
            string task;
            string[] number = { "" };
            int i;
            string oper = "";
            Choose:
            Console.WriteLine("Menu: \n 1 - Standard calculator \n 2 - Engineering calculator \n 3 - Exit");
            string choose = Console.ReadLine();
            XmlSerializer result = new XmlSerializer(typeof(Calc));
            XmlSerializer result1 = new XmlSerializer(typeof(Eng_Calc));
            switch (choose)
            {
                case "1":

                    Console.WriteLine("Standard calculator:");
                    Console.WriteLine("Operations '+','-','*','/':");
                    Console.WriteLine("Example: 3,5*2");
                    task = Console.ReadLine();
                    for (i = 0; i < opers.Length; i++)
                    {
                        number = task.Split(opers[i]);
                        if (number.Length == 2)
                        {
                            break;
                        }

                    }

                    Calc calc = new Calc(Convert.ToString(opers[i]), Convert.ToDouble(number[0]), Convert.ToDouble(number[1]));
                    Console.WriteLine(calc.Results());


                    using (FileStream fs = new FileStream("results.xml", FileMode.OpenOrCreate))
                    {
                        result.Serialize(fs, calc);
                    }

                    goto Choose;


                case "2":
                    Console.WriteLine("Engineering calculator:");
                    Console.WriteLine("Operations '+','-','*','/',sin,cos,sqrt,tan,ctan:");
                    Console.WriteLine("Example: 3,5*2, sin(2,5)");
                    task = Console.ReadLine();

                    i = 0;
                    for (i = 0; i < 4; i++)
                    {
                        number = task.Split(opers[i]);
                        if (number.Length == 2)
                        {
                            oper = Convert.ToString(opers[i]);

                            goto Create;
                        }

                    }
                    number = task.Split('(');


                    number[1] = number[1].Remove(number[1].Length - 1);
                    oper = number[0];
                    number[0] = number[1];

                    Create:
                    Eng_Calc eng_calc = new Eng_Calc(oper, Convert.ToDouble(number[0]), Convert.ToDouble(number[1]));
                    Console.WriteLine(eng_calc.Results());


                    using (FileStream fs = new FileStream("results.xml", FileMode.OpenOrCreate))
                    {
                        result1.Serialize(fs, eng_calc);
                    }
                    goto Choose;
                default:
                    break;
            }


        }

    }
}