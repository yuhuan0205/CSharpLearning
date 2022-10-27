using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CalculatorAPI
{
    /// <summary>
    /// a pool implements ICalculatorPoll contains lots of isolated ICalculator.
    /// </summary>
    public class CalculatorPool : ICalculatorPool
    {
        /// <summary>
        /// a thread safe Dictionary which contains a key -id and value -ICalculator.
        /// </summary>
        private ConcurrentDictionary<string, ICalculator> Pool;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public CalculatorPool()
        {
            Pool = new ConcurrentDictionary<string, ICalculator>();
        }

        /// <summary>
        /// distribute id.
        /// </summary>
        /// <returns> a random Guid string. </returns>
        public string Enroll()
        {
            string id = Guid.NewGuid().ToString();
            while (!Pool.TryAdd(id, new MyCalculator()))
            {
                id = Guid.NewGuid().ToString();
            }

            return id;
        }

        /// <summary>
        /// get ICalculator by input id.
        /// </summary>
        /// <param name="id">input id</param>
        /// <returns> ICalculator with specific id </returns>
        public ICalculator GetCalculatorById(string id)
        {
            return Pool[id];
        }

        /// <summary>
        /// remove unused ICalculator.
        /// </summary>
        /// <param name="id"> input id </param>
        public void LogOut(string id)
        {
            ICalculator calculator = null;
            Pool.TryRemove(id, out calculator);
        }
    }
}