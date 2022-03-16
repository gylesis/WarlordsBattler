using System.Linq;
using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class ItemsInfoService
    {
        private readonly ItemsInfoContainer _itemsInfoContainer;

        public ItemsInfoService(ItemsInfoContainer itemsInfoContainer)
        {
            _itemsInfoContainer = itemsInfoContainer;
        }

        public Sprite GetItemImage(Item item)
        {
            ItemInfo itemInfo = _itemsInfoContainer.Items.FirstOrDefault(info => info.Item.Name == item.Name);

            Sprite itemImage;
            
            if (itemInfo == null)
            {
                itemImage = _itemsInfoContainer.DefaultSprite;
            }
            else
            {
                itemImage = itemInfo.Image;
            }

            return itemImage;
        }
        
    }
}