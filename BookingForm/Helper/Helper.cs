using System;
using System.Net.Http;

namespace BookingForm.Helper
{
    public class SaleAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44382/");
            return Client;
        }
    }
}
