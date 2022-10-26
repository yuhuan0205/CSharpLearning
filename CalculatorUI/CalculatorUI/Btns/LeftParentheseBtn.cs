﻿using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI
{
    /// <summary>
    /// a button that user can add LeftParenthese Operator into server.
    /// </summary>
    public class LeftParentheseBtn : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        /// <returns> task </returns>
        public async override Task OnClick(string id, HttpClient client)
        {
            await client.GetAsync($"leftparenthese/{id}");
        }
    }
}
