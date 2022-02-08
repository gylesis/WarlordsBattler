namespace Warlords.Player
{
    public class PlayerFactionView : PlayerInfoView
    {
        public override void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _infoView.text = playerInfo.Faction.Name;
            _infoView.color = playerInfo.Faction.Color;
        }
    }
}