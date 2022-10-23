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
        public ICalculator[] Pool = new ICalculator[100];

        /// <summary>
        /// room numbers
        /// </summary>
        public  List<int> AvailableId = Enumerable.Range(0, 100).ToList<int>();

        public int Enroll()
        {
            int distributedID = AvailableId[Consts.FIRST];
            Pool[distributedID] = new MyCalculator();
            AvailableId.RemoveAt(Consts.FIRST);
            return distributedID;
        }

        public ICalculator GetCalculatorById(int id)
        {
            return Pool[id];
        }

        public bool LogOut(int id)
        {
            Pool[id] = null;
            AvailableId.Add(id);
            return true;
        }
    }
}
