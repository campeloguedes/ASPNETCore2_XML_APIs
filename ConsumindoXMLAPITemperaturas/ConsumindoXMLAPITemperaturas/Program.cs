using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace ConsumindoXMLAPITemperaturas
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            string urlBase =
                config.GetSection("UrlBase").Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/xml"));

                HttpResponseMessage response;

                response = client.GetAsync(
                     urlBase + "conversortemperaturas/fahrenheit/32").Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadKey();
        }
    }
}