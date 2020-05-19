using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace AppWebClient.Tools
{

    public static class ApiHttpClient
    {

        // Our Api Server URL
        public readonly static string _url = "http://localhost:5001";

        public readonly static string UserID = "002078C2AB";

        // Our Api Consumer 
        public static HttpClient ApiClient { get; set; }



        public static HttpClient ConnectClient()
        {

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(_url);

            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return ApiClient;
        }


    }// End Class 
}
