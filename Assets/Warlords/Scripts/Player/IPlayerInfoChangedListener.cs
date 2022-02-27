namespace Warlords.Player
{
    public interface IPlayerInfoChangedListener
    {
       abstract void PlayerInfoChanged(PlayerInfo playerInfo);
       abstract void PlayerInfoDiscarded(PlayerInfo playerInfo);
    }
}