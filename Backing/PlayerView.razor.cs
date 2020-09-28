using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidViewer.Pages
{
    public partial class PlayerView : ComponentBase
    {
        [Parameter]
        public List<Player> Players { get; set; }

        [Parameter]
        public List<Boss> Bosses { get; set; }

        [Parameter]
        public Raid Raid { get; set; }

        [Parameter]
        public Player Player { get; set; }

        public Boss GetBoss(int bossId)
        {
            return Bosses.First(b => b.Id == bossId);
        }

        public Character GetCharacter(int characterId) {
            return Player.Characters.First(c=>c.Id==characterId);
        }

        public Character GetCharacter(Player player, Encounter encounter) {
            List<int> selectedPlayers = encounter.Characters.Select(c=>c.PlayerId).ToList();
            if(selectedPlayers.Contains((int)player.Id)) {
                return GetCharacter(encounter.Characters.First(c=>c.PlayerId==player.Id).CharacterId);
            } else {
                return null;
            }
        }
    }
}