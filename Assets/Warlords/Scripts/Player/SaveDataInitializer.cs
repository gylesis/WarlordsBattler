using System;
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

            var inventorySlotDatas = new List<InventorySlotData>(15);

            var item1 = new InventorySlotData() {Item = new Item{Name = "Shard1", }, Count = new IntStat{Value = 3}};
            var item2 = new InventorySlotData() {Item = new Item{Name = "Shard2", }, Count = new IntStat{Value = 7}};
            var item3 = new InventorySlotData() {Item = new Item{Name = "Shard3", }, Count = new IntStat{Value = 5}};
            
            inventorySlotDatas.Add(item1);
            inventorySlotDatas.Add(item2);
            inventorySlotDatas.Add(item3);

            var count = 15 - inventorySlotDatas.Count;
            
            for (int i = 0; i < count; i++)
            {
                var inventorySlotData = new InventorySlotData();
                inventorySlotData.Item = new Item {Name = String.Empty};
                
                inventorySlotDatas.Add(inventorySlotData);
            }
            
            saveData.InventorySaveData.SlotsDatas = inventorySlotDatas;
            
            playerInfo.Faction = _staticData.WarlordFaction._faction;
            playerInfo.AttributesData.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);

            return saveData;
        }
    }
}