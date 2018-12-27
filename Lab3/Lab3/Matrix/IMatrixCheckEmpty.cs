using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Matrix
{
    public interface IMatrixCheckEmpty<T>
    {
        T GetEmptyElement(); // return empty  obj
        bool CheckEmptyElement(T element); // check if obj is empty
    }
}
