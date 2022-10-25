using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI
{
    public class CalculatorPool : ICalculatorPool
    {
        /// <summary>
        /// rooms
        /// </summary>
        private Dictionary<string, ICalculator> Pool;
        
        public CalculatorPool()
        {
            Pool = new Dictionary<string, ICalculator>();
        }

        public string Enroll()
        {
            string id = Guid.NewGuid().ToString();
            while( !Pool.TryAdd(id, new MyCalculator()))
            {
                id = Guid.NewGuid().ToString();
            }

            return id;
        }

        public ICalculator GetCalculatorById(string id)
        {
            return Pool[id];
        }

        public bool LogOut(string id)
        {
            Pool[id] = null;
            return true;
        }
    }
}
