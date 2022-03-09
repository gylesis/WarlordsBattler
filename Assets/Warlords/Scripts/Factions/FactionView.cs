using TMPro;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Factions
{
    [RequireComponent(typeof(FactionButton))]
    public class FactionView : MonoBehaviour, ISelectionView
    {
        [SerializeField] private TMP_Text _nameLabel;
        [SerializeField] private FactionButton _factionButton;
        [SerializeField] private ImageSelectionView _imageSelectionView;
        
        private Faction _faction;
        public UISelectionView SelectionView => _imageSelectionView;
        public FactionButton FactionButton => _factionButton;
        public Faction Faction => _faction;
        
        private void Reset()
        {
            _factionButton = GetComponent<FactionButton>();
        }

        public void Init(FractionViewContext context)
        {
            _faction = context.Faction;

            _nameLabel.text = context.Faction.Name;
            _nameLabel.color = context.Faction.Color;

            _factionButton.Init(this, context.Faction);
        }
    }
}