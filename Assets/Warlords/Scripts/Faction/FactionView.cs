using TMPro;
using UnityEngine;

namespace Warlords.Faction
{
    [RequireComponent(typeof(FactionButton))]
    public class FactionView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameLabel;
        [SerializeField] private FactionButton _factionButton;

        public FactionButton FactionButton => _factionButton;

        private void Reset()
        {
            _factionButton = GetComponent<FactionButton>();
        }

        public void Init(FractionViewContext context)
        {
            _nameLabel.text = context.warlordFaction.Name;
            _nameLabel.color = context.warlordFaction.Color;

            _factionButton.Init(this, context.warlordFaction);
        }
    }
}