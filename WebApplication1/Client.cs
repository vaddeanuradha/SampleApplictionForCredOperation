using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Formatting;
using System.Configuration;

namespace WebApplication1
{
    public static class Client
    {
        public static HttpClient http = new HttpClient();

        static Client()
        {
            http.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUrl"]);
            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}