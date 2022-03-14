using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Warlords.Crafting;
using Warlords.UI.Units;
using Zenject;

namespace Warlords.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private InventoryDraggableUIElement _draggableUIElement;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _additionalIcon; 
        
        private InventorySlotData _inventorySlotData;
        private ItemsInfoService _itemsInfoService;

        public InventorySlotData SlotData => _inventorySlotData;
        public InventoryDraggableUIElement DraggableUIElement => _draggableUIElement;

        [Inject]
        private void Init(ItemsInfoService itemsInfoService)
        {
            _itemsInfoService = itemsInfoService;
            _draggableUIElement.PointerDown.TakeUntilDestroy(this).Subscribe((PointerDown));
            _draggableUIElement.PointerUp.TakeUntilDestroy(this).Subscribe((PointerUp));
        }

        private void PointerUp(UIElementContextData<InventorySlot> context)
        {
            _additionalIcon.enabled = false;
        }

        private void PointerDown(UIElementContextData<InventorySlot> context)
        {
            _additionalIcon.enabled = true;
        }

        public void Init(InventorySlotData slotData)
        {
            _inventorySlotData = slotData;
            slotData.Count.Changed.TakeUntilDestroy(this).Subscribe((OnSlotCountChanged));

            if (slotData.Item.Name != String.Empty)
            {
                Sprite itemImage = _itemsInfoService.GetItemImage(slotData.Item);
                _itemIcon.sprite = itemImage;
                _additionalIcon.sprite = itemImage;
                _additionalIcon.enabled = false;
            }

            OnSlotCountChanged(slotData.Count.Value);
        }

        private void OnSlotCountChanged(int value)
        {
            if (value == 0)
            {
                _count.enabled = false;
                _draggableUIElement.Disable();
                _itemIcon.enabled = false;
                return;
            }

            _draggableUIElement.Enable();
            _count.enabled = true;
            _itemIcon.enabled = true;
            _count.text = value.ToString();
        }
    }
}