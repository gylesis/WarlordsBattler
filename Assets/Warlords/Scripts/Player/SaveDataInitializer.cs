using System;
using System.Collections.Generic;
using System.Linq;
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

            var item1 = new InventorySlotData() {Item = new Ingredient{Name = "DarkGreenFragment",Type = IngredientType.Fragment, Color = IngredientColor.DarkGreen}, Count = new IntStat{Value = 9}};
            //var item2 = new InventorySlotData() {Item = new Ingredient{Name = "DarkGreenShard",Type = IngredientType.Shard, Color = IngredientColor.DarkBlue}, Count = new IntStat{Value = 9}};
            
            inventorySlotDatas.Add(item1);
           // inventorySlotDatas.Add(item2);

            var count = 15 - inventorySlotDatas.Count;
            
            for (int i = 0; i < count; i++)
            {
                var inventorySlotData = new InventorySlotData();
                inventorySlotData.Item = new Item {Name = String.Empty};
                
                inventorySlotDatas.Add(inventorySlotData);
            }
            
            saveData.InventorySaveData.SlotsDatas = inventorySlotDatas.Select(x => new InventorySlotSaveData(x)).ToList();
            
            playerInfo.Faction = _staticData.WarlordFaction._faction;
            playerInfo.AttributesData.LeftUpgrades = _staticData.PlayerAttributes.Upgrades.GetUpgradesAmount(1);

            return saveData;
        }
    }
}