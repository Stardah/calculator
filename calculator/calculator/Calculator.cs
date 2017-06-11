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
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Calculator()
        {
            Clear();
        }

        public Calculator(double[,] array)
        {
            SetMatrix(array);
        }


        /// <summary>
        /// Индексатор по свободным членам.
        /// </summary>
        /// <param name="index">Индекс свободного члена (с 0).</param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                return m_free[index];
            }
            set
            {
                m_free[index] = value;
            }
        }

        /// <summary>
        /// Индексатор по системе уравнений.
        /// Нумерация с 0.
        /// Для свободных членов другой индексатор.
        /// </summary>
        /// <param name="variableIndex">Индекс переменной.</param>
        /// <param name="equationIndex">Индекс уравнения.</param>
        /// <returns>Коэффициент перед переменной.</returns>
        public double this[int variableIndex, int equationIndex]
        {
            get
            {
                return m_matrix[equationIndex, variableIndex];
            }
            set
            {
                m_matrix[equationIndex, variableIndex] = value;
            }
        }

        /// <summary>
        /// Очистить калькулятор от всех значений.
        /// </summary>
        public void Clear()
        {
            m_matrix = new Matrix3();
        }

        public void SetMatrix(double[,] coeffs)
        {
            m_matrix = new Matrix3(coeffs);
        }

        public void SetFree(params double[] free)
        {
            if (free.Length != EquationNumber)
                throw new ArgumentException("Неверное количество свободных членов.");

            Array.Copy(free, m_free, EquationNumber);
        }

        /// <summary>
        /// Решить текущую систему уравнений. Возвращает массив решений.
        /// Если система не может быть разрешена, то выбрасывается исключение.
        /// </summary>
        /// <returns>Массив значений неизвестных.</returns>
        /// <exception cref="CalculationException">Отсутствуют решения системы.</exception>
        public double[] Solve()
        {
            return Solve(m_matrix, m_free);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variableCoeffs"></param>
        /// <param name="freeCoeffs"></param>
        /// <returns></returns>
        /// <exception cref="CalculationException">Отсутствуют решения системы.</exception>
        public double[] Solve(Matrix3 variableCoeffs, double[] freeCoeffs)
        {
            var inv = BaseMatrix.Copy(variableCoeffs).Inverse();
            var x = new double[EquationNumber];
            x[0] = inv[0, 0] * freeCoeffs[0] + inv[1, 0] * freeCoeffs[1] + inv[2, 0] * freeCoeffs[2];
            x[1] = inv[0, 1] * freeCoeffs[0] + inv[1, 1] * freeCoeffs[1] + inv[2, 1] * freeCoeffs[2];
            x[2] = inv[0, 2] * freeCoeffs[0] + inv[1, 2] * freeCoeffs[1] + inv[2, 2] * freeCoeffs[2];

            return x;
        }

        private const int EquationNumber = 3;

        /// <summary>
        /// Список уравнений.
        /// </summary>
        private Matrix3 m_matrix;

        /// <summary>
        /// Список свободных членов.
        /// </summary>
        private double[] m_free = new double[EquationNumber];
    }
}
