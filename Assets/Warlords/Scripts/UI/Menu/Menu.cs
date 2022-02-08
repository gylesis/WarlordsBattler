using UnityEngine;

namespace Warlords.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private MenuTag _tag;

        public MenuTag Tag => _tag;

        private void OnValidate()
        {
            name = $"{_tag.name} Menu";
        }
    }
}