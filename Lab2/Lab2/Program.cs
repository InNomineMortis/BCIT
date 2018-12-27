using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rect = new Rectangle(8, 9);
            var squ = new Square(22);
            var crcl = new Circle(4);
            rect.Print();
            squ.Print();
            crcl.Print();
            Console.WriteLine();
            PrintF(crcl);
        }
        static void PrintF(Figure figure) {
            var sub = figure.Area();
            Console.WriteLine(sub);
            figure.Print();
        }
    }
}
