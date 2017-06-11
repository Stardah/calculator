using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public abstract class BaseMatrix
    {
        public BaseMatrix(int matrixSize, params double[] coeffs)
        {
            if (matrixSize < 1)
                throw new ArgumentException("Некорректный размер матрицы.");

            m_matrixSize = matrixSize;

            if (coeffs.Length != m_matrixSize * m_matrixSize)
                throw new ArgumentException("Некорректное количество элементов матрицы.");

            m = new double[m_matrixSize, m_matrixSize];

            int i = 0;

            foreach (var v in coeffs)
                m[i % m_matrixSize, i / m_matrixSize] = v;
        }

        public BaseMatrix(double[,] matrix)
        {
            if (matrix.Length != 3 * 3)
                throw new ArgumentException("Некорректное количество элементов матрицы.");
            m_matrixSize = 3;
            m = matrix;
        }

        public static BaseMatrix Copy(BaseMatrix matrix)
        {
            switch (matrix.m_matrixSize)
            {
                case 2:
                    return new Matrix2(matrix.m);

                case 3:
                    return new Matrix3(matrix.m);

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Индексатор матрицы.
        /// </summary>
        /// <param name="i">Столбец матрицы.</param>
        /// <param name="j">Строка матрицы.</param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get
            {
                return m[i, j];
            }
            set
            {
                m[i, j] = value;
            }
        }

        public static explicit operator double[,](BaseMatrix lhs)
        {
            return lhs.m;
        }

        public static BaseMatrix operator/(BaseMatrix lhs, double rhs)
        {
            BaseMatrix matrix = Copy(lhs);

            for (int i = 0; i < lhs.m_matrixSize; ++i)
                for (int j = 0; j < lhs.m_matrixSize; ++j)
                    matrix[i, j] /= rhs;

            return matrix;
        }

        // ToDo: сделать виртуальным.
        /// <summary>
        /// Нахождение определителя матрицы.
        /// </summary>
        /// <returns>Определитель.</returns>
        public abstract double Determinant();

        /// <summary>
        /// Нахождение обратной матрицы.
        /// </summary>
        /// <returns>Матрица, обратная данной.</returns>
        /// <exception cref="CalculationException"></exception>
        public abstract BaseMatrix Inverse();

        public abstract double Minor(int x, int y);

        /// <summary>
        /// Транспонирование исходной матрицы.
        /// </summary>
        /// <returns>Транспонированная матрица.</returns>
        public BaseMatrix Transpone()
        {
            double[,] temp = new double[m_matrixSize, m_matrixSize];

            int i = 0;

            foreach (var v in m)
                temp[i / m_matrixSize, i % m_matrixSize] = v;

            m = temp;

            return this;
        }

        public int Size { get { return m_matrixSize; } }

        protected int m_matrixSize;
        protected double[,] m;
    }
}
