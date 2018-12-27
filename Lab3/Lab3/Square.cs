using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Square : Rectangle
    {
        public double Side { get { return Height; } set { Height = value; Width = value; } }
        public Square(double side) : base(side, side) { }
        public override string ToString()
        {
            return "Side: " + Side + " Area: " + Area();
        }
    }
}
