using System.Linq;
using UnityEngine;

namespace Warlords.UI
{
    [CreateAssetMenu(menuName = "Menu/MenuTagsContainer", fileName = "MenuTagsContainer", order = 0)]
    public class MenuTagsContainer : ScriptableObject
    {
        public MenuTag FactionTag;
        public MenuTag MainMenuTag;
        public MenuTag WarlordTag;
        public MenuTag BoardTag;
        
        
        /*[SerializeField] private MenuTag[] MenuTags;

        private MenuTag GetTag(string tagName) =>
            MenuTags.First(tag =>
            {
                MenuTag returnedValue;
                
                if (tag.name.Contains(tagName))
                {
                    returnedValue = tag;
                }

                returnedValue = MenuTags[0];

                return returnedValue;

            });

        public MenuTag GetBoarMenuTag() =>
            GetTag("BoardMenu");

        public MenuTag GetWarlordMenuTag() =>
            GetTag("WarlordMenu");

        public MenuTag GetFactionMenuTag() =>
            GetTag("FactionMenu");*/
    }
}