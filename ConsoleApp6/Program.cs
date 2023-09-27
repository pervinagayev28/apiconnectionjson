using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await foo();
        }

        static async Task foo()
        {
            List<data> datas = new List<data>();
            using (HttpClient httpClient = new HttpClient())
            {
                string gistUrl = "https://api.first.org/data/v1/countries";
                string json = await httpClient.GetStringAsync(gistUrl);
                datas = JsonSerializer.Deserialize<List<data>>(json);
            }
            foreach (dynamic item in datas)
            {
                Console.WriteLine(item.name);
            }
        }
    }

    class data
    {
        public string country { get; set; }
        public string region { get; set; }
    }
}