using UnityEngine;

namespace Warlords.UI.Menu
{
    [CreateAssetMenu(menuName = "Menu/MenuTag", fileName = "MenuTag", order = 0)]
    public class MenuTag : ScriptableObject
    {
        public bool Additive;
    }
}