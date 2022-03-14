using System.Linq;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class ItemsInfoService
    {
        private readonly ItemsContainer _itemsContainer;

        public ItemsInfoService(ItemsContainer itemsContainer)
        {
            _itemsContainer = itemsContainer;
        }

        public Sprite GetItemImage(Item item)
        {
            ItemInfo itemInfo = _itemsContainer.Items.First(info => info.Item.Name == item.Name);
            Sprite itemImage = itemInfo.Image;

            if (itemImage == null)
            {
                Debug.LogError($"Sprite is not set for an item {item.Name}");
            }

            return itemImage;
        }
        
    }
}