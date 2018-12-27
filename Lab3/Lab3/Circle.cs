using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Circle : Figure
    {
        public double Radius { get; set; }      
        public Circle(double rad)
        {
            Radius = rad;
        }
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
        public override string ToString()
        {
            return "Radius: " + Radius + " Area: " + Area();
        }
    }
}
