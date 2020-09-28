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
            return Players.First(p=>p.Id==playerId);
        }

    }
}