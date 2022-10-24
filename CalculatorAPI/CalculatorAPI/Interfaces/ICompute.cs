using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Interfaces
{
    public interface ICompute
    {
        public MessageObject GetResult(string calculatedProcess);
    }
}
