using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace Loja.Util
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri(WebConfigurationManager.AppSettings["URL_API"]);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}