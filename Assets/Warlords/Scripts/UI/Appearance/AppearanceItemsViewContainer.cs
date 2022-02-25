using System.Linq;
using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class AppearanceItemsViewContainer : MonoBehaviour
    {
        public AppearanceItemView[] BodyItems;
        public AppearanceItemView[] HeadItems;

        [ContextMenu(nameof(FillItems))]
        private void FillItems()
        {
            var appearanceItemViews = GetComponentsInChildren<AppearanceItemView>(true);

            BodyItems = appearanceItemViews.Where(x => x.AppearanceType == AppearanceItemType.Body).ToArray();    
            
            HeadItems = appearanceItemViews.Where(x => x.AppearanceType == AppearanceItemType.Head).ToArray(); 
        }
       
        
    }
}