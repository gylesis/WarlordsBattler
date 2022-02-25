using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords.Player.Spells
{
    public class SelectableSpellView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _description;
        [SerializeField] private SelectableSpellButton _selectableSpellButton;
        [SerializeField] private Image _outlineImage;
        
        private SpellData _spellData;

        public SelectableSpellButton SelectableSpellButton => _selectableSpellButton;
        public SpellData SpellData => _spellData;
        
        public void Init(SpellData spellData)
        {
            _spellData = spellData;
            
            _selectableSpellButton.Init(spellData);
            _description.text = $"{spellData.Type} {spellData.Index}";
        }

        public void ShowOutline()
        {
            _outlineImage.enabled = true;
        }
        public void HideOutline()
        {
            _outlineImage.enabled = false;
        }
        
    }
}