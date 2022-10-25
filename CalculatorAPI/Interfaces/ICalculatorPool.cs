using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface ICalculatorPool
    {
        public string Enroll();
        public ICalculator GetCalculatorById(string id);
        public bool LogOut(string id);
    }
}
