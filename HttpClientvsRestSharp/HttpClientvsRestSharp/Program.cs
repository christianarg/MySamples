using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHttpClient
{
    class Program
    {
        const string localHost = "http://127.0.0.1/";
        const string google = "https://www.google.es";
        const string localApi = "http://localhost:24925/api/homeapi/listcoso";

        static string url;


        static void Main(string[] args)
        {
            url = google;
            //var httpClientHandler = new HttpClientHandler();

            // 216.58.201.131 google
            //EjecutarConHttpClientFactoryBaseAddress().Wait();
            //EjecutarConHttpClientFactory().Wait();
            //EjecutarSingleHttpClient().Wait();
            //EjecutarHttpClient().Wait();
            //EjecutarRestSharp().Wait();

            ReproducirSocketExhaustion();
            Console.ReadLine();
        }

        public static void ReproducirSocketExhaustion()
        {
            while (true)
            {
                try
                {
                    var client = new HttpClient();
                    client.GetStringAsync(url);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static async Task EjecutarConHttpClientFactoryBaseAddress()
        {
            var stopWatch = Stopwatch.StartNew();

            var client = HttpClientFactory.CreateHttpClient(new Uri("http://localhost:24925/"));

            for (int i = 0; i < 10; i++)
            {
                var response = await client.GetStringAsync("/api/homeapi/listcoso/");
            }
            stopWatch.Stop();
            Console.WriteLine($"{nameof(EjecutarConHttpClientFactoryBaseAddress)}:{stopWatch.ElapsedMilliseconds}ms");
        }

        public static async Task EjecutarConHttpClientFactory()
        {
            var stopWatch = Stopwatch.StartNew();

            var client = HttpClientFactory.CreateHttpClient(new Uri(url));

            for (int i = 0; i < 10; i++)
            {
                var response = await client.GetStringAsync(url);
            }
            stopWatch.Stop();
            Console.WriteLine($"{nameof(EjecutarConHttpClientFactory)}:{stopWatch.ElapsedMilliseconds}ms");
        }

        public static async Task EjecutarSingleHttpClient()
        {
            var stopWatch = Stopwatch.StartNew();
            var endpoint = new Uri(url);
            var client = new HttpClient();
            for (int i = 0; i < 10; i++)
            {
                var response = await client.GetStringAsync(endpoint);
            }
            stopWatch.Stop();
            Console.WriteLine($"{nameof(EjecutarSingleHttpClient)}:{stopWatch.ElapsedMilliseconds}ms");
        }

        public static async Task EjecutarHttpClient()
        {
            var stopWatch = Stopwatch.StartNew();
            var endpoint = new Uri(url);
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetStringAsync(endpoint);
                    //Console.WriteLine(response);
                }
            }
            stopWatch.Stop();
            Console.WriteLine($"{nameof(EjecutarHttpClient)}:{stopWatch.ElapsedMilliseconds}ms");
        }

        public static async Task EjecutarRestSharp()
        {
            var stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < 10; i++)
            {
                var client = new RestClient(url);
                var response = await client.ExecuteTaskAsync(new RestRequest(Method.GET));
                //Console.WriteLine(response.Content);
            }
            stopWatch.Stop();
            Console.WriteLine($"{nameof(EjecutarRestSharp)}:{stopWatch.ElapsedMilliseconds}ms");
        }
    }
}
