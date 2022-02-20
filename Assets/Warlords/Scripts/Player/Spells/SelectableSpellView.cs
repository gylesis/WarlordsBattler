using TMPro;
using UnityEngine;

namespace Warlords.Player.Spells
{
    public class SelectableSpellView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _description;
        [SerializeField] private SelectableSpellButton _selectableSpellButton;

        public SelectableSpellButton SelectableSpellButton => _selectableSpellButton;

        public void Init(SpellData spellData)
        {
            _selectableSpellButton.Init(spellData);
            _description.text = $"{spellData.Type} {spellData.Index}";
        }
        
    }
}