using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    /// <summary>
    /// Максим Сунцев, 07.06.17 23:06
    /// Исключение, выбрасываемое в случае ошибки в расчетах.
    /// </summary>
    public class CalculationException : ApplicationException
    {
        public CalculationException()
        {
        }

        public CalculationException(string message) :
            base(message)
        {
        }

        public CalculationException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }

        protected CalculationException(SerializationInfo info, StreamingContext context) : 
            base(info, context)
        {
        }
    }
}
