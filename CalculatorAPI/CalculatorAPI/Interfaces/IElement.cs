using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Interfaces
{
    public interface IElement
    {
        public int GetPriority();
        public decimal DoOperation();
        public decimal GetValue();
    }
}
