using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;
using RaidPlannerClient.Service;
using System.Linq;
using System;

namespace RaidViewer.Pages
{
    public partial class ViewRaid : ComponentBase
    {
        [Inject]
        public IRaidService RaidService { get; set; }

        [Inject]
        public IPlayerService PlayerService { get; set; }

        [Inject]
        public IInstanceService InstanceService { get; set; }

        private Raid Raid;
        private List<Player> Players;

        private List<Boss> Bosses;

        private string ErrorMessage;

        private string EncountersVisible = "collapse";
        private string PlayersVisible = "collapse";

        protected override async Task OnInitializedAsync()
        {
            try {
                Raid = await RaidService.GetLatest();
                Players = await PlayerService.GetPlayers();
                Bosses = (await InstanceService.GetInstances()).SelectMany(i=>i.Bosses).ToList();
            } catch(Exception e) {
                ErrorMessage = "Unable to fetch latest raid";
            }
        }

        public Player GetPlayer(int playerId) {
            if(Players.Exists(p=>p.Id==playerId)) {
                return Players.First(p=>p.Id==playerId);
            } else {
                Console.WriteLine($"Unknown player with id {playerId}");
                return new Player{Name="Unknown", Characters=new List<Character>()};
            }
        }

        public void ToggleEncounters() {
            if(EncountersVisible=="collapse") {
                EncountersVisible = "";
            } else {
                EncountersVisible = "collapse";
            }
        }

        public void TogglePlayers() {
            if(PlayersVisible=="collapse") {
                PlayersVisible = "";
            } else {
                PlayersVisible = "collapse";
            }
        }
    }
}