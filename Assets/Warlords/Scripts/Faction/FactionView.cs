using TMPro;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Faction
{
    [RequireComponent(typeof(FactionButton))]
    public class FactionView : MonoBehaviour, ISelectionView
    {
        [SerializeField] private TMP_Text _nameLabel;
        [SerializeField] private FactionButton _factionButton;
        [SerializeField] private ImageSelectionView _imageSelectionView;
        
        private WarlordFaction _warlordFaction;
        public UISelectionView SelectionView => _imageSelectionView;
        public FactionButton FactionButton => _factionButton;
        public WarlordFaction WarlordFaction => _warlordFaction;
        
        private void Reset()
        {
            _factionButton = GetComponent<FactionButton>();
        }

        public void Init(FractionViewContext context)
        {
            _warlordFaction = context.WarlordFaction;

            _nameLabel.text = context.WarlordFaction.Name;
            _nameLabel.color = context.WarlordFaction.Color;

            _factionButton.Init(this, context.WarlordFaction);
        }
    }
}