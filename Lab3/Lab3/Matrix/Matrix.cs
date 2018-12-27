using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Matrix
{
    public class Matrix<T>
    {
        private Dictionary<string, T> _matrix = new Dictionary<string, T>();

        private int _maxX;
        private int _maxY;
        private int _maxZ;

        private IMatrixCheckEmpty<T> _checkEmpty;

        // Constructor
        public Matrix(int t_maxX, int t_maxY, int t_maxZ, IMatrixCheckEmpty<T> t_checkEmpty)
        {
            _maxX = t_maxX;
            _maxY = t_maxY;
            _maxZ = t_maxZ;

            _checkEmpty = t_checkEmpty;
        }

        //Data access index
        public T this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                var key = DictKey(x, y, z);

                return _matrix.ContainsKey(key) ? _matrix[key] : _checkEmpty.GetEmptyElement();
            }
            set
            {
                CheckBounds(x, y, z);
                var key = DictKey(x, y, z);
                _matrix.Add(key, value);
            }
        }

        // Bounds check with different output 
        private void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(x), $"x = {x} выходит за границу");
            }
            if (y < 0 || y > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(y), $"y = {y} выходит за границу");
            }
            if (z < 0 || z > _maxX)
            {
                throw new ArgumentOutOfRangeException(nameof(z), $"z = {z} выходит за границу");
            }
        }
        //key creation with different output method
        private string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }

        //
        public override string ToString()
        {
            var builder = new StringBuilder(); // builder is a method to create string

            for (var k = 0; k < _maxZ; k++)
            {
                builder.Append("[\n");
                for (var j = 0; j < _maxY; j++)
                {
                    builder.Append("\t");
                    builder.Append("[");
                    for (int i = 0; i < _maxX; i++)
                    {
                        if (i > 0)
                        {
                            builder.Append("\t"); // adding tab divider
                        }

                        if (!_checkEmpty.CheckEmptyElement(this[i, j, k]))
                        {
                            builder.Append(this[i, j, k]); // add changed element to a string
                        }
                        else
                        {
                            builder.Append(" - "); // if value is missing
                        }
                    }

                    builder.Append("]\n");
                }

                builder.Append("]\n");
            }

            return builder.ToString();
        }
    }
}
