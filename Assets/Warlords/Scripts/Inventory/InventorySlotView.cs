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
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Image _additionalIcon;
        
        private ItemsInfoService _itemsInfoService;
        private InventoryDraggableUIElement _draggableUIElement;

        [Inject]
        private void Init(InventorySlotData slotData, ItemsInfoService itemsInfoService, InventoryDraggableUIElement draggableUIElement)
        {
            _draggableUIElement = draggableUIElement;
            _itemsInfoService = itemsInfoService;       
            
            _draggableUIElement = draggableUIElement;
            _draggableUIElement.PointerDown.TakeUntilDestroy(this).Subscribe((PointerDown));
            _draggableUIElement.PointerUp.TakeUntilDestroy(this).Subscribe((PointerUp));
            
            slotData.Count.Changed.TakeUntilDestroy(this).Subscribe(UpdateView);

            if (slotData.Item.Name != String.Empty)
            {
                Sprite itemImage = _itemsInfoService.GetItemImage(slotData.Item);
                _itemIcon.sprite = itemImage;
                _additionalIcon.sprite = itemImage;
                _additionalIcon.enabled = false;
            }

            UpdateView(slotData.Count.Value);
        }
        
        public void UpdateView(int value)
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
        
        private void PointerUp(UIElementContextData<InventorySlot> context)
        {
            _additionalIcon.enabled = false;
        }

        private void PointerDown(UIElementContextData<InventorySlot> context)
        {
            _additionalIcon.enabled = true;
        }
        
        
    }
}