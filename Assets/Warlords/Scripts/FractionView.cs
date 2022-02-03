using TMPro;
using UnityEngine;

namespace Warlords
{
    [RequireComponent(typeof(FractionButton))]
    public class FractionView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel;
        [SerializeField] private FractionButton _fractionButton;

        public FractionButton FractionButton => _fractionButton;

        private void Reset()
        {
            _fractionButton = GetComponent<FractionButton>();
        }

        public void Init(FractionViewContext context)
        {
            _nameLabel.text = context.WarlordFraction.Name;
            _nameLabel.color = context.WarlordFraction.Color;
            
            _fractionButton.Init(context.WarlordFraction);
        }
    }
    
    
}