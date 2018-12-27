using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Rectangle : Figure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public override double Area()
        {
            return Height * Width;
        }
        public override string ToString()
        {
            return "Height: " + Height + " Width: " + Width + " Area: " + Area();
        }
    }
}
