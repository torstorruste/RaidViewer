using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidViewer.Pages
{
    public partial class MissingPlayers : ComponentBase
    {
        [Parameter]
        public Raid Raid { get; set; }

        [Parameter]
        public List<Player> Players { get; set; }

        private string Visible = "collapse";

        public List<Player> GetMissingPlayers() {
            return Players.Where(p=>!Raid.SignedUp.Contains((int)p.Id)).ToList();
        }

        public void ToggleVisible() {
            if(Visible=="collapse") {
                Visible = "";
            } else {
                Visible = "collapse";
            }
        }
    }
}