using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Warlords.UI.Units;

namespace Warlords.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private InventoryDraggableUIElement _draggableUIElement;
        [SerializeField] private Image _itemIcon;
        
        private InventorySlotData _inventorySlotData;

        public InventorySlotData SlotData => _inventorySlotData;
        public InventoryDraggableUIElement DraggableUIElement => _draggableUIElement;

        public void Init(InventorySlotData slotData)
        {
            _inventorySlotData = slotData;
            slotData.Count.Changed.TakeUntilDestroy(this).Subscribe((OnSlotCountChanged));

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