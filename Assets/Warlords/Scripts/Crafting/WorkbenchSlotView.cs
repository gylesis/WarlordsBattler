using UnityEngine;
using UnityEngine.UI;
using Warlords.Inventory;
using Zenject;

namespace Warlords.Crafting
{
    public class WorkbenchSlotView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        private ItemsInfoService _infoService;

        [Inject]
        private void Init(ItemsInfoService infoService)
        {
            _infoService = infoService;
            
            UpdateView(null);
        }
        
        public void UpdateView(Item item)
        {
            if (item == null)
            {
                _image.enabled = false;
                return;
            }
            
            _image.enabled = true;
            _image.sprite = _infoService.GetItemImage(item);
        }
    }
}