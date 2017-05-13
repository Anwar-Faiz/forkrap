using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForkRap
{
    class LoopThrough
    {
        private String api = null;
        private int times = 0;
        private String destination = null;

        public LoopThrough(String api, int times, String destination)
        {
            this.api = api;
            this.times = times;
            this.destination = destination;
        }

        static async Task RunAsync(String api, Action<string> callback)
        {
            // Forking a new client
            HttpClient client = new HttpClient();

            // Setting headers of request
            client.BaseAddress = new Uri(api);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Act : Call the Api and get the response
            String responseString = null;
            HttpResponseMessage response = await client.GetAsync(api);
            if (response.IsSuccessStatusCode)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            // execute the call back function
            callback(responseString);
        }

        public void getRap()
        {
            Action<String> callbackFunction = WhenResponseCameClass.PrintResponseAsString;

            for(int i=0;i<times;i++)
            {
                RunAsync(api, callbackFunction).Wait();
            }
        }
    }
}
