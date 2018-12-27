using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6._1
{
    delegate int PlusOrMinus(int p1, int p2);
    class Program
    {
        //Методы, реализующие делегат (методы "типа" делегата)
        static int Plus(int p1, int p2) { return p1 + p2; }
        static int Minus(int p1, int p2) { return p1 - p2; }
        //Пример объявления метода с делегатным параметром
        static void PlusOrMinusMethod(string str, int i1, int i2, PlusOrMinus PlusOrMinusParam)
        {
            int Result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
        }
        static void PlusOrMinusMethodFunc(string str, int i1, int i2, Func<int, int, int> PlusOrMinusParam)
        {
            int Result = PlusOrMinusParam(i1, i2);
            Console.WriteLine(str + Result.ToString());
        }
        static void Main(string[] args)
        {
            int i1 = 3;
            int i2 = 2;
            PlusOrMinusMethod("+: ", i1, i2, Plus);
            PlusOrMinusMethod("_: ", i1, i2, Minus);
            //Создание экземпляра делегата на основе метода
            PlusOrMinus pm1 = new PlusOrMinus(Plus);
            PlusOrMinusMethod("Delegate instance creation based on method  : ",
           i1, i2, pm1);
            //Создание экземпляра делегата на основе 'предположения' делегата
            //Компилятор 'пердполагает' что метод Plus типа делегата
            PlusOrMinus pm2 = Plus;
            PlusOrMinusMethod("Delegate instance creation based on delegate assumption :", i1, i2, pm2);            Console.WriteLine("Anonymous method : ");
            //Создание анонимного метода
            PlusOrMinus pm3 = delegate (int param1, int param2)
            {
                return param1 + param2;
            };
            PlusOrMinusMethod("Delegate instance creation based on anonymous method : ", i1, i2, pm2);
            PlusOrMinusMethod("Delegate instance creation based on lambda function : ", i1, i2,
            (int x, int y) =>
            {
                int z = x + y;
                return z;
            }
            );
            Console.WriteLine("Generalized method : ");
            //Для обобщённого делегата 
            PlusOrMinusMethodFunc("Delegate instance creation based on method : ", i1, i2, Minus);            PlusOrMinusMethodFunc("Delegate instance creation based on lambda function :", i1, i2, (x, y) => x - y);
            Console.ReadKey();
        }
    }
}
