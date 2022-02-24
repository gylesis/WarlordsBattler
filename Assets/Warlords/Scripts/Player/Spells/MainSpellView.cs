using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords.Player.Spells
{
    public class MainSpellView : MonoBehaviour
    {
        [SerializeField] private MainSpellButton _mainSpellButton;
        [SerializeField] private SpellType _spellType;
        [SerializeField] private TMP_Text _spellName;
        [SerializeField] private TMP_Text _spellDescription;
        [SerializeField] private Image _outline;    
        
        public MainSpellButton MainSpellButton => _mainSpellButton;
        public SpellType SpellType => _spellType;

        public void Init(SpellData spellData)
        {
            _mainSpellButton.Init(_spellType);
            
            UpdateView(spellData);
        }

        private void OnValidate()
        {
            _spellName.text = $"{_spellType}: ";
        }

        public void UpdateView(SpellData spellData)
        {
            string index;

            if (spellData.Index == -1)
            {
                index = "Not choosen";
            }
            else
            {
                index = spellData.Index.ToString();
            }

            _spellName.text = $"{spellData.Type}:";

            _spellDescription.text = $"{index}";
        }

        public void ShowSelection()
        {
            _outline.enabled = true;
        }
        public void HideSelection()
        {
            _outline.enabled = false;
        }
    }
    
}