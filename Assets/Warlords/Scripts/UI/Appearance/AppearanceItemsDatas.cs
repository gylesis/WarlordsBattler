using UnityEngine;
using Warlords.Player;

namespace Warlords.UI.Appearance
{
    [CreateAssetMenu(menuName = "StaticData/AppearanceItemsData", fileName = "AppearanceItemsDatas", order = 0)]
    public class AppearanceItemsDatas : ScriptableObject
    {
        public AppearanceItemData[] HeadItems;
        public AppearanceItemData[] BodyItems;
        public AppearanceItemData[] SkinItems;
    }
}