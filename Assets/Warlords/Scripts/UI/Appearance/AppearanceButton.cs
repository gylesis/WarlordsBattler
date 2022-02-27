using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.Appearance
{
    public class AppearanceButton : ReactiveButton<AppearanceItemType, bool>
    {
        [SerializeField] private AppearanceItemType _appearanceItemType;
        [SerializeField] private bool _isLeftSide;

        protected override bool Value => _isLeftSide;

        protected override AppearanceItemType Sender => _appearanceItemType;
    }
}