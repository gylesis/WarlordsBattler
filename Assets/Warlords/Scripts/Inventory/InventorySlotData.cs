using System;
using UniRx;
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

            set
            {
                _item = value;
                ItemChanged.OnNext(value);
            }
        }

        public IntStat Count = new IntStat();
        
        private Item _item;

        public Subject<Item> ItemChanged { get; } = new Subject<Item>();
        
        public InventorySlotData() { }

        public InventorySlotData(InventorySlotSaveData slotSaveData)
        {
            Item = slotSaveData.Item;
            Count.Value = slotSaveData.Count;
        }
        
    }

    [Serializable]
    public class Item
    {
        public string Name;
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