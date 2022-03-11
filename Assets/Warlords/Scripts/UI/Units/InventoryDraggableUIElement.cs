using UnityEngine;
using UnityEngine.UI;
using Warlords.Inventory;

namespace Warlords.UI.Units
{
    public class InventoryDraggableUIElement : UIElement<InventorySlot>
    {
        [SerializeField] private Image _raycastImage;
        [SerializeField] private InventorySlot _slot;

        protected override InventorySlot Sender => _slot;

        public void Init(InventorySlot slot)
        {
            _slot = slot;
        }
        
        public void Disable()
        {
            _raycastImage.raycastTarget = false;
        }

        public void Enable()
        {
            _raycastImage.raycastTarget = true;
        }
    }
}