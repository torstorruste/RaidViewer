using System;
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

        private string Visible = "collapse";

        public Boss GetBoss(int bossId)
        {
            return Bosses.First(b => b.Id == bossId);
        }

        public Character GetCharacter(int characterId) {
            Console.WriteLine($"Getting character {characterId} for player {Player.Id}");
            if(Player.Characters.Exists(c=>c.Id==characterId)) {
                return Player.Characters.First(c=>c.Id==characterId);
            } else {
                return new Character{Name="Unknown"};
            }
        }

        public Role GetRole(Encounter encounter, Character character) {
            return encounter.Characters.First(c=>c.CharacterId==character.Id).Role;
        }

        public Character GetCharacter(Player player, Encounter encounter) {
            Console.WriteLine($"Getting character for player {player.Name} and encounter {encounter.BossId}");
            List<int> selectedPlayers = encounter.Characters.Select(c=>c.PlayerId).ToList();
            if(player.Id!=null && selectedPlayers.Contains((int)player.Id)) {
                return GetCharacter(encounter.Characters.First(c=>c.PlayerId==player.Id).CharacterId);
            } else {
                return null;
            }
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