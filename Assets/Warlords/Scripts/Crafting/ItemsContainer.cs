using System;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "StaticData/ItemsContainer", fileName = "ItemsContainer", order = 0)]
    public class ItemsContainer : ScriptableObject
    {
        public ItemInfo[] Items;
    }

    [Serializable]
    public struct ItemInfo
    {
        public Item Item;
        public Sprite Image;
    }
}