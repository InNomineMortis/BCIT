using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public abstract class Figure : IPrint
    {
        public abstract double Area();
        public void Print() {
            Console.WriteLine(ToString());
        }
    }
}
