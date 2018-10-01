using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Input(1);
            var b = Input(2);
            var c = Input(3);
            var D = b * b - 4 * a * c;
           
                if (D < 0)
                {
                    Console.Write("No real roots!");
                    return;
                }
                if (D > 0)
                {
                    var d = Math.Sqrt(D);
                    var x1 = (-b - d) / (2 * a);
                    var x2 = (-b + d) / (2 * a);
                    Console.WriteLine("This equality have 2 different roots : x1 = {0} x2 = {1} ",x1, x2);
                    return;
                }
                var x = -b / (2 * a);
                Console.Write("2 same roots: x = {0}", x);
                return;    
        }
        public static double Input(int y){
        var num = 0.0;
        do
        {
            Console.WriteLine("Input {0} numeral!", y);
            var line = double.TryParse(Console.ReadLine(), out num);
            if (line)
            {
                return num;
            }
            Console.WriteLine("Error, try again!\n");
        } while (true);
       }
    }
    
}
