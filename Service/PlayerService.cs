using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RaidPlannerClient.Model;
using Newtonsoft.Json;
using System.Text;

namespace RaidPlannerClient.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient httpClient;

        public PlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Player>> GetPlayers()
        {
            Console.WriteLine("PlayerService::GetPlayers");

            Console.WriteLine("GETting rest/players");
            var result = await httpClient.GetAsync("rest/players");
            result.EnsureSuccessStatusCode();

            var json = await result.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<List<Player>>(json);

            foreach (var player in players)
            {
                player.Characters.Sort((a, b) => a.Name.CompareTo(b.Name));
            }

            return players;
        }
    }
}