using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RaidPlannerClient.Model;
using Newtonsoft.Json;
using System.Text;

namespace RaidPlannerClient.Service
{
    public class InstanceService : IInstanceService
    {
        private readonly HttpClient httpClient;

        public InstanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Instance>> GetInstances()
        {
            Console.WriteLine("InstanceService::GetInstances");

            Console.WriteLine("GETting rest/instances");
            var result = await httpClient.GetAsync("rest/instances");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var instances = JsonConvert.DeserializeObject<List<Instance>>(json);

            foreach (var Instance in instances)
            {
                Instance.Bosses.Sort((a, b) => a.Name.CompareTo(b.Name));
            }

            return instances;
        }
    }
}