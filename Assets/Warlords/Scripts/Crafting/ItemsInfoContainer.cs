using System;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    [CreateAssetMenu(menuName = "StaticData/ItemsContainer", fileName = "ItemsContainer", order = 0)]
    public class ItemsInfoContainer : ScriptableObject
    {
        public Sprite DefaultSprite;
        public ItemInfo[] Items;
    }

    [Serializable]
    public class ItemInfo
    {
        public Item Item;
        public Sprite Image;
    }
}