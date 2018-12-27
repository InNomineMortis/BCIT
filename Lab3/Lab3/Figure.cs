using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public abstract class Figure : IPrint, IComparable
    {
        public abstract double Area();
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case Figure figure:
                    return Area().CompareTo(figure.Area());
                default:
                    throw new ArgumentException("Used object is not a figure");
            }
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
