using System;
using Warlords.Infrastructure;
using Warlords.Utils;

namespace Warlords.Inventory
{
    [Serializable]
    public class InventorySlotData
    {
        public Item Item
        {
            get => _item;

            set => _item = value;
        }

        public IntStat Count = new IntStat();
        
        private Item _item;

        public InventorySlotData() { }

        public InventorySlotData(InventorySlotSaveData slotSaveData)
        {
            Item = slotSaveData.Item;
            Count.Value.Value = slotSaveData.Count;
        }
        
    }

    [Serializable]
    public class Item
    {
        public string Name = "";
    }

    [Serializable]
    public class Ingredient : Item
    {
        public IngredientType Type;
        public IngredientColor Color;
    }

    public enum IngredientType
    {
        Shard,
        Fragment
    }
        
    public enum IngredientColor
    {
        Orange,
        Gray,
        Yellow,
        Red,
        Purple,
        White,
        LightGreen,
        LightBlue,
        DarkGreen,
        DarkBlue,
        Translucent,
        GoldLaced,
        Obsidian,
        Reforging
    }
}