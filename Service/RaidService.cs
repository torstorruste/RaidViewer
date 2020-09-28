using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RaidPlannerClient.Model;

namespace RaidPlannerClient.Service
{
    public class RaidService : IRaidService
    {
        private readonly HttpClient httpClient;

        public RaidService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Raid> GetLatest()
        {
            Console.WriteLine("RaidService::GetLatest");

            Console.WriteLine("GETting rest/raids/latest");
            var result = await httpClient.GetAsync("rest/raids/latest");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var raids = JsonConvert.DeserializeObject<Raid>(json);

            return raids;
        }
    }
}