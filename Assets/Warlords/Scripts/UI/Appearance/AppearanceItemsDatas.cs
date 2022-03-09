using UnityEngine;
using Warlords.Player;

namespace Warlords.UI.Appearance
{
    [CreateAssetMenu(menuName = "StaticData/AppearanceItemsData", fileName = "AppearanceItemsDatas", order = 0)]
    public class AppearanceItemsDatas : ScriptableObject
    {
        [SerializeField] private string _path;
        
        public AppearanceItemData[] HeadItems;
        public AppearanceItemData[] BodyItems;
        public AppearanceItemData[] SkinItems;

        [ContextMenu(nameof(FillPaths))]
        public void FillPaths()
        {
            int indexPath = 0;
            foreach (AppearanceItemData appearanceItemData in HeadItems)
            {
                appearanceItemData.Path = $"{_path} {indexPath}";
                indexPath++;
            }
        }
        
    }
}