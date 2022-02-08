using UnityEngine;

namespace Warlords.UI
{
    [CreateAssetMenu(menuName = "Menu/MenuTag", fileName = "MenuTag", order = 0)]
    public class MenuTag : ScriptableObject { }

    [CreateAssetMenu(menuName = "Menu/MenuTagsContainer", fileName = "MenuTagsContainer", order = 0)]
    public class MenuTagsContainer : ScriptableObject
    {
        public MenuTag[] MenuTags;
    }
    
}