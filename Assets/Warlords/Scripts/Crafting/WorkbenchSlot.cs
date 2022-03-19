using UnityEngine;
using Warlords.Inventory;
using Warlords.UI.Units;
using Warlords.Utils;

namespace Warlords.Crafting
{
    [RequireComponent(typeof(CustomTag))]
    public class WorkbenchSlot : MonoBehaviour
    {
        [SerializeField] private WorkbenchSlotView _workbenchSlotView;
        [SerializeField] private WorkbenchUIElement _uiElement;
        public WorkbenchUIElement UIElement => _uiElement;

        private Item _item;

        public Item Item => _item;

        private void Awake()
        {
            _uiElement.Init(this);
        }

        public void SetItem(Item item)
        {
            _item = item;

            _workbenchSlotView.UpdateView(item);
        }
       
    }
}