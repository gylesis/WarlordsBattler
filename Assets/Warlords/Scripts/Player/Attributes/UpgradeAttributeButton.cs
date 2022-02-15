using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    public abstract class UpgradeAttributeButton : ReactiveButton<PlayerAttribute, bool>
    {
        private PlayerAttribute _attribute;

        protected override PlayerAttribute Sender => _attribute;

        public PlayerAttribute Attribute => _attribute;

        public void Init(PlayerAttribute attribute)
        {
            _attribute = attribute;
        }
    }
}