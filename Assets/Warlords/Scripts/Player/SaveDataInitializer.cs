using System.Collections.Generic;
using Warlords.Infrastructure;
using Warlords.Inventory;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Player
{
    public class SaveDataInitializer : ISaveDataInitializer
    {
        private readonly PlayerInfoStaticData _staticData;

        public SaveDataInitializer(PlayerInfoStaticData staticData)
        {
            _staticData = staticData;
        }
        
        public SaveData Initialize()
        {
            var saveData = new SaveData();

            var playerInfo = saveData.PlayerInfo;

            PlayerAttribute[] staticPlayerAttributes =
                _staticData.PlayerAttributes.AttributesPerFactions[0].PlayerStartAttributes;

            playerInfo.CopyAndSetAttributes(staticPlayerAttributes);

            saveData.InventorySaveData.SlotsDatas = new List<InventorySlotData>(15);
            
            playerInfo.Faction = _staticData.WarlordFaction._faction;
            playerInfo.AttributesData.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);

            return saveData;
        }
    }
}