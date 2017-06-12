using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Matrix3 : BaseMatrix
    {
        public Matrix3(params double[] coeffs) :
            base(MatrixSize, coeffs)
        {
        }
        
        public Matrix3(double[,] matrix) :
            base(MatrixSize, matrix)
        {
        }

        public override double Determinant()
        {
            return
                m[0, 0] * m[1, 1] * m[2, 2] +
                m[1, 0] * m[2, 1] * m[0, 2] +
                m[2, 0] * m[0, 1] * m[1, 2] -

                m[2, 0] * m[1, 1] * m[0, 2] -
                m[0, 0] * m[2, 1] * m[1, 2] -
                m[1, 0] * m[0, 1] * m[2, 2];
        }

        /// <summary>
        /// Нахождение обратной матрицы.
        /// </summary>
        /// <returns>Матрица, обратная данной.</returns>
        /// <exception cref="CalculationException"></exception>
        public override BaseMatrix Inverse()
        {
            double det = Determinant();

            if (det == 0.0)
                throw new CalculationException("Определитель равен нулю.");

            var minorsSigned = new List<double>();

            for (int i = 0; i < MatrixSize; ++i)
                for (int j = 0; j < MatrixSize; ++j)
                    minorsSigned.Add(Minor(i, j) * (((i + j) & 1) == 1 ? -1 : 1));

            m = (double[,])(new Matrix3(minorsSigned.ToArray()).Transpone() / det);
            
            return this;
        }

        public override double Minor(int x, int y)
        {
            var list = new List<double>();

            for (int i = 0; i < MatrixSize; ++i)
                for (int j = 0; j < MatrixSize; ++j)
                    if (i != x && j != y)
                        list.Add(m[i, j]);

            return new Matrix2(list.ToArray()).Determinant();
        }

        private const int MatrixSize = 3;
    }
}
