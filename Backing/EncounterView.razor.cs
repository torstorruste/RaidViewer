using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidViewer.Pages
{
    public partial class EncounterView : ComponentBase
    {
        [Parameter]
        public List<Player> Players { get; set; }

        [Parameter]
        public List<Boss> Bosses { get; set; }

        [Parameter]
        public Encounter Encounter { get; set; }

        public Boss GetBoss(int bossId)
        {
            return Bosses.First(b => b.Id == bossId);
        }

        public Character GetCharacter(int characterId)
        {
            return Players.SelectMany(p => p.Characters).First(c => c.Id == characterId);
        }

        public List<Character> GetCharactersByRole(Role role)
        {
            return Encounter.Characters
                    .Where(c => c.Role == role)
                    .Select(c => GetCharacter(c.CharacterId))
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public List<Role> GetRoles()
        {
            return new List<Role> { Role.Tank, Role.Healer, Role.Melee, Role.Ranged };
        }
    }
}