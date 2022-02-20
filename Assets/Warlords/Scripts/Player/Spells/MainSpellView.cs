using TMPro;
using UnityEngine;

namespace Warlords.Player.Spells
{
    public class MainSpellView : MonoBehaviour
    {
        [SerializeField] private MainSpellButton _mainSpellButton;
        [SerializeField] private SpellType _spellType;
        [SerializeField] private TMP_Text _spellName;

        public MainSpellButton MainSpellButton => _mainSpellButton;

        public void Init(SpellData spellData)
        {
            _mainSpellButton.Init(_spellType);

            string index;

            if (spellData.Index == -1)
            {
                index = "Choose me!";
            }
            else
            {
                index = spellData.Index.ToString();
            }
            
            _spellName.text = $"{spellData.Type}: {index}";
        }

        private void OnValidate()
        {
            _spellName.text = $"{_spellType}: ";
        }
        
    }

   
    
}