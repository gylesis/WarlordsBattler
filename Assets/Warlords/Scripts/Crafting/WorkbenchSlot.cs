using UnityEngine;
using Warlords.Inventory;

namespace Warlords.Crafting
{
    public class WorkbenchSlot : MonoBehaviour
    {
        [SerializeField] private WorkbenchSlotView _workbenchSlotView;

        private Item _item;

        public Item Item => _item;
       
        public void SetItem(Item item)
        {
            _item = item;

            _workbenchSlotView.UpdateView(item);
        }
       
    }
}