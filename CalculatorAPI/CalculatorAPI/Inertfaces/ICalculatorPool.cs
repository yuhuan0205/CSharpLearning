using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public interface ICalculatorPool
    {
        public int Enroll();
        public ICalculator GetCalculatorById(int id);
        public bool LogOut(int id);
    }
}
