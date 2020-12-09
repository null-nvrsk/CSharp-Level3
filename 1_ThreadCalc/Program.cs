using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1_ThreadCalc
{
    class Program
    {
        private static object locker = new object();

        static void Main(string[] args)
        {
            Console.Write("Введите цисло для возведения в факториал = ");
            int nForFact = int.Parse(Console.ReadLine());


            Console.Write("Введите цисло для суммирования = ");
            int nForSum = int.Parse(Console.ReadLine());

            Thread factThread = new Thread(new ParameterizedThreadStart(MyFact));
            factThread.Name = "Поток 1";
            factThread.Start(nForFact);

            Thread sumThread = new Thread(new ParameterizedThreadStart(MySum));
            sumThread.Name = "Поток 2";           
            sumThread.Start(nForSum);

            Console.WriteLine("Ждем окончания работы потоков\n");
            Console.ReadKey();
        }

        //---------------------------------------------------------------------------------
        static void MyFact(object n)
        {
            lock (locker)
            {
                decimal result = 1;
                int _n = (int)n;

                if (_n > 0 && _n < 28)
                {
                    for (int i = 1; i <= _n; i++)
                        result *= (decimal)i;
                    Console.WriteLine($"{_n}! = {result}");
                }
                else if (_n >= 28)
                    Console.WriteLine("Слижком большое число (можно <= 27)");

                else result = 0;

                Console.WriteLine($"{Thread.CurrentThread.Name} завершен.\n");
            }
        }

        //---------------------------------------------------------------------------------
        static void MySum(object n)
        {
            lock (locker)
            {
                decimal result = 0;
                int _n = (int)n;

                if (_n > 0 && _n <= 1_000_000_000)
                {
                    for (int i = 1; i <= _n; i++)
                        result += (decimal)i;
                } else
                    Console.WriteLine("Недопустимое число (от 1 и до 1.000.000.000)");


                Console.WriteLine($"{Thread.CurrentThread.Name} завершен.");
                Console.WriteLine($"Сумма чисел от 1 до {_n} = {result}\n");
            }
        }
    }
}
