using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using RaidPlannerClient.Model;

namespace RaidViewer.Pages
{
    public partial class RoleView : ComponentBase
    {
        [Parameter]
        public List<Player> Players { get; set; }

        [Parameter]
        public Encounter Encounter { get; set; }

        [Parameter]
        public Role Role { get; set; }

        public List<Character> GetCharactersByRole()
        {
            return Encounter.Characters
                    .Where(c => c.Role == Role)
                    .Select(c => GetCharacter(c.CharacterId))
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public Character GetCharacter(int characterId)
        {
            return Players.SelectMany(p => p.Characters).First(c => c.Id == characterId);
        }
    }
}