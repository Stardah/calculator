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

        /// <summary>
        /// Конструктор из массива double.
        /// </summary>
        /// <param name="array">Массив double, представляющий матрицу коэффициентов.</param>
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
        public double this[int equationIndex, int variableIndex]
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
        /// Удалить систему из память.
        /// </summary>
        /// <param name="index">Индекс удаляемой системы.</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void DeleteSystemFromMemory(int index)
        {
            if (index < 0 || index > MemoryCount || MemoryCount == 0)
                throw new IndexOutOfRangeException("Нет такого уравнения.");

            m_memory.RemoveAt(index);
        }

        /// <summary>
        /// Очистить калькулятор от всех значений.
        /// </summary>
        public void Clear()
        {
            m_matrix = new Matrix3();
        }

        /// <summary>
        /// Достать систему из памяти.
        /// </summary>
        /// <param name="index">Индекс системы.</param>
        /// <returns>Массив с системой уравнений по заданному индексу.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double[,] GetSystemFromMemory(int index)
        {
            if (index < 0 || index > MemoryCount || MemoryCount == 0)
                throw new IndexOutOfRangeException("Нет такого уравнения.");

            var tuple = m_memory[index];
            var matr = new double[EquationNumber + 2, EquationNumber];

            for (int i = 0; i < EquationNumber; ++i)
                for (int j = 0; j < EquationNumber; ++j)
                    matr[i, j] = tuple.Item1[i, j];

            for (int i = 0; i < EquationNumber; ++i)
                matr[EquationNumber + 1, i] = tuple.Item2[i];

            for (int i = 0; i < EquationNumber; ++i)
                matr[EquationNumber + 2, i] = tuple.Item3[i];

            return matr;
        }

        /// <summary>
        /// Достать систему из памяти и превратить в строку.
        /// </summary>
        /// <param name="index">Индекс системы.</param>
        /// <returns>Массив с системой уравнений по заданному индексу.</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public string[] GetSystemStringsFromMemory(int index)
        {
            if (index < 0 || index > MemoryCount || MemoryCount == 0)
                throw new IndexOutOfRangeException("Нет такого уравнения.");

            var tuple = m_memory[index];

            StringBuilder sb = new StringBuilder(tuple.Item1.ToStringWithFree(tuple.Item2));

            for (int i = 0; i < EquationNumber; ++i)
                sb.AppendFormat("x{0} = {1}; ", i + 1, tuple.Item3[i]);

            return (
                from v in sb.ToString().Split('\n', '\r')
                where v.Length > 0
                select v
                ).ToArray(); 
        }

        /// <summary>
        /// Установить матрицу коэффициентов.
        /// </summary>
        /// <param name="coeffs">Коэффициенты.</param>
        public void SetMatrix(double[,] coeffs)
        {
            m_matrix = new Matrix3(coeffs);
        }

        /// <summary>
        /// Установить матрицу-столбец свободных членов.
        /// </summary>
        /// <param name="free">Матрица-столбец свободных членов.</param>
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
            x[0] = inv[0, 0] * freeCoeffs[0] + inv[0, 1] * freeCoeffs[1] + inv[0, 2] * freeCoeffs[2];
            x[1] = inv[1, 0] * freeCoeffs[0] + inv[1, 1] * freeCoeffs[1] + inv[1, 2] * freeCoeffs[2];
            x[2] = inv[2, 0] * freeCoeffs[0] + inv[2, 1] * freeCoeffs[1] + inv[2, 2] * freeCoeffs[2];

            m_memory.Add(new Tuple<Matrix3, double[], double[]>(
                (Matrix3)BaseMatrix.Copy(m_matrix),
                (double[])m_free.Clone(),
                (double[])x.Clone()
            ));

            return x;
        }

        private const int EquationNumber = 3;

        public int MemoryCount { get { return m_memory.Count; } }

        /// <summary>
        /// Список уравнений.
        /// </summary>
        private Matrix3 m_matrix;

        /// <summary>
        /// Список свободных членов.
        /// </summary>
        private double[] m_free = new double[EquationNumber];

        /// <summary>
        /// Массив, хранящий историю решений.
        /// </summary>
        private List<Tuple<Matrix3, double[], double[]>> m_memory = 
            new List<Tuple<Matrix3, double[], double[]>>();
    }
}
