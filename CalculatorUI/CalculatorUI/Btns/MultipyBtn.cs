﻿using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI
{
    /// <summary>
    /// a button that user can add Multipy Operator into server.
    /// </summary>
    public class MultipysBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        public async override Task OnClick(int id, HttpClient client)
        {
            _ = await client.GetAsync($"multipy/{id}");
        }
    }
}
