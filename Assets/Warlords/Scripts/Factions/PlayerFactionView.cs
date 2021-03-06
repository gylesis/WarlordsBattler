using Warlords.Player;

namespace Warlords.Factions
{
    public class PlayerFactionView : PlayerInfoView
    {
        public override void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _infoView.text = playerInfo.Faction.Name;
            _infoView.color = playerInfo.Faction.Color;
        }

        public override void PlayerInfoDiscarded(PlayerInfo playerInfo)
        {
            _infoView.text = playerInfo.Faction.Name;
            _infoView.color = playerInfo.Faction.Color;
        }
    }
}