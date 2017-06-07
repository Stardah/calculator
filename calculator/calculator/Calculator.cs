using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    /// <summary>
    /// Максим Сунцев, 07.06.17 12:04
    /// Класс вычислительной логики калькулятора.
    /// </summary>
    public class Calculator
    {
        public class Matrix
        {
            Matrix(params double[] coeffs)
            {
                if (coeffs.Length != MatrixSize * MatrixSize)
                    throw new ArgumentException("Некорректное количество элементов матрицы.");

                int i = 0;

                foreach (var v in coeffs)
                    m[i % MatrixSize, i / MatrixSize] = v;
            }

            public Matrix(double[,] matrix)
            {
                matrix.CopyTo(m, 0);
            }

            public static Matrix operator-(Matrix matrix)
            {
                throw new NotImplementedException();
            }

            public double Determinant()
            {
                return
                    m[0, 0] * m[1, 1] * m[2, 2] +
                    m[1, 0] * m[2, 1] * m[0, 2] +
                    m[2, 0] * m[0, 1] * m[1, 2] -

                    m[2, 0] * m[1, 1] * m[0, 2] -
                    m[0, 0] * m[2, 1] * m[1, 2] -
                    m[1, 0] * m[0, 1] * m[2, 2];
            }

            public void Transpone()
            {
                double[,] temp = new double[MatrixSize, MatrixSize];

                int i = 0;

                foreach (var v in m)
                    temp[i / MatrixSize, i % MatrixSize] = v;

                m = temp;
            }

            private const int MatrixSize = 3;

            private double[,] m = new double[MatrixSize, MatrixSize];
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Calculator()
        {
            Clear();
        }

        /// <summary>
        /// Индексатор по системе уравнений.
        /// Нумерация с 1, как в матане.
        /// Индекс 0 для свободного члена.
        /// </summary>
        /// <param name="variableIndex">Индекс переменной.</param>
        /// <param name="equationIndex">Индекс уравнения.</param>
        /// <returns>Коэффициент перед переменной.</returns>
        public double this[int variableIndex, int equationIndex]
        {
            get
            {
                return coeffs[equationIndex][variableIndex];
            }
            set
            {
                coeffs[equationIndex][variableIndex] = value;
            }
        }

        /// <summary>
        /// Очистить калькулятор от всех значений.
        /// </summary>
        public void Clear()
        {
            coeffs = new List<List<double>>();
        }

        /// <summary>
        /// Решить текущую систему уравнений. Возвращает массив решений.
        /// Если система не может быть разрешена, то выбрасывается исключение.
        /// </summary>
        /// <returns>Массив значений неизвестных.</returns>
        /// <exception cref="CalculationException">Отсутствуют решения системы.</exception>
        public double[] Solve()
        {
            if (coeffs.Count < EquationNumber)
                throw new CalculationException("Неверное количество уравнений.");

            double[,] matrixVar = new double[EquationNumber, coeffs.Count];
            double[] matrixFree = new double[coeffs.Count];

            // Индекс уравнения в цикле.
            int eq = 0;

            // Перебираем все элементы массива и строим матрицу.
            // В случае отсутствия коэффициента(-ов) приравниваем их к нулю.
            foreach (var v in coeffs)
            {
                if (v.Count > EquationNumber + 1)
                    throw new CalculationException("Слишком много переменных.");

                // Заполняем матрицу свободных членов.
                matrixFree[eq] = v[0];

                // Заполняем матрицу переменных коэффициентами.
                for (int i = 1; i < EquationNumber; ++i)
                    matrixVar[i - 1, eq] = (v.Count > i) ? v[i] : 0;
            }
        }

        private const int EquationNumber = 3;

        /// <summary>
        /// Список уравнений.
        /// </summary>
        private List<List<double>> coeffs;
    }
}
