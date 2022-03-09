using System.Collections.Generic;
using System.Linq;
using Warlords.Factions;
using Warlords.Infrastructure;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributesProvider
    {
        private readonly PlayerInfoStaticData _staticData;

        public PlayerAttributesProvider(PlayerInfoStaticData staticData)
        {
            _staticData = staticData;
        }

        public PlayerAttribute[] GetAttributesByFaction(Faction targetFaction)
        {
            AttributesPerFaction attributesPerFaction =
                _staticData.PlayerAttributes.AttributesPerFactions.First(faction =>
                    faction.Faction.Value.Name == targetFaction.Name);

            var playerStartAttributes = attributesPerFaction.PlayerStartAttributes;

            return playerStartAttributes;
        }
        
    }
}