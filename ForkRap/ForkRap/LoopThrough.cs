﻿using System;
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

        public static int threadsOpened = 0;
        public static int threadsClosed = 0;

        public static Boolean noWaitMode = false;

        public LoopThrough(String api, int times, String destination)
        {
            this.api = api;
            this.times = times;
            this.destination = destination;
        }

        static async Task RunAsync(String api, int threadNum, Action<string> callback)
        {
            // Forking a new client
            threadsOpened++;
            HttpClient client;
            String responseString = null;

            try
            {
                client = new HttpClient();
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Error Stacktrace : " + e.ToString());
                responseString = "**Error: HttpClient can't be initiated**";
                callback(responseString);
                System.Console.WriteLine("<-- end thread : " + threadNum.ToString());
                threadsClosed++;
                return;
            }

            // Setting headers of request
            client.BaseAddress = new Uri(api);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Act: Call the Api and get the response
            try
            {
                HttpResponseMessage response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    responseString = await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine("Error Stacktrace : " + e.ToString());
                responseString = "**Error: Possible Network Issue**";
                callback(responseString);
                System.Console.WriteLine("<-- end thread : " + threadNum.ToString());
                threadsClosed++;
                return;
            }
            
            // execute the call back function
            callback(responseString);
            System.Console.WriteLine("<-- end thread : " + threadNum.ToString());
            threadsClosed++;
        }

        public void getRap()
        {
            Action<String> callbackFunction = WhenResponseCameClass.PrintResponseAsString;

            for(int i=0;i<times;i++)
            {
                System.Console.WriteLine("\n--> Spawning new thread : " + i.ToString());

                if(noWaitMode == true)
                {
                    RunAsync(api, i, callbackFunction);
                }
                else
                {
                    RunAsync(api, i, callbackFunction).Wait();
                }
            }
        }
    }
}
