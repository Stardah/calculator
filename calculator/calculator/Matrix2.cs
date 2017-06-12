using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Matrix2 : BaseMatrix
    {
        public Matrix2(params double[] coeffs) :
            base(2, coeffs)
        {
        }

        public Matrix2(double[,] matrix) :
            base(MatrixSize, matrix)
        {
        }

        public override double Determinant()
        {
            return
                m[0, 0] * m[1, 1] -
                m[1, 0] * m[0, 1];
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

            m = (double[,])(new Matrix2(minorsSigned.ToArray()).Transpone() / det);

            return this;
        }

        public override double Minor(int x, int y)
        {
            return m[y, x];
        }

        private const int MatrixSize = 2;
    }
}
