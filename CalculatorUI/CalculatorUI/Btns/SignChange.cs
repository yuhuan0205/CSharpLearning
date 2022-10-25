﻿using System.Net.Http;
using System.Threading.Tasks;

namespace CalculatorUI.Btns
{
    /// <summary>
    /// change the negative and postive sign.
    /// </summary>
    public class SignChange : AbstractBtn
    {
        /// <summary>
        /// override AbstractBtn's OnClick.
        /// </summary>
        /// <param name="id"> id of this application</param>
        /// <param name="client"> a object to call api </param>
        public async override Task OnClick(string id, HttpClient client)
        {
            _ = await client.GetAsync($"changesign/{id}");
            //HttpResponseMessage response = await client.GetAsync($"/changesign/{id}"); 
            //string x = await response.Content.ReadAsStringAsync();
        }
    }
}