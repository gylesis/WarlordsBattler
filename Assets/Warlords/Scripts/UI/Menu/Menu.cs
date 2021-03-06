using UnityEngine;

namespace Warlords.UI.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private MenuTag _tag;

        public MenuTag Tag => _tag;

        private void OnValidate()
        {
            if(_tag == null) return;
            
            name = $"{_tag.name}";
        }
    }
}