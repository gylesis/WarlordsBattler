using System;
using UnityEngine;

namespace Warlords.Player.Spells
{
    public class SelectableSpellsViewContainer : MonoBehaviour
    {
        public SpellType SpellType;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnValidate()
        {
            name = $"{SpellType}";
        }
    }
}