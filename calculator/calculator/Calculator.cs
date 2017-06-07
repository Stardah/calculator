using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{

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
        /// <exception cref="ArgumentException">Отсутствуют решения системы.</exception>
        public double[] Solve()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Список уравнений.
        /// </summary>
        private List<List<double>> coeffs;
    }
}
