using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Matrix;

namespace Lab3
{
    public class MatrixEmpty : IMatrixCheckEmpty<Figure>
    {
        public Figure GetEmptyElement()
        {
            return null;
        }
        public bool CheckEmptyElement(Figure element)
        {
            return element == null;
        }
    }
}
