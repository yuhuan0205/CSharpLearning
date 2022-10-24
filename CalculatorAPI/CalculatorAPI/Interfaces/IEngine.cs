using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Interfaces
{
    public interface IEngine
    {
        public MessageObject GetResult();
    }
}
