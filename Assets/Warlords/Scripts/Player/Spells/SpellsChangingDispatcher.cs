using System;
using UniRx;
using Warlords.Player.Attributes;

namespace Warlords.Player.Spells
{
    public class SpellsChangingDispatcher : IDisposable, IPlayerInfoChangedListener
    {
        private readonly IDisposable _disposable;

        public Subject<PlayerSpellInfo> PlayerSpellInfoChanged { get; } = new Subject<PlayerSpellInfo>();
        public Subject<PlayerSpellInfo> PlayerSpellInfoDiscarded { get; } = new Subject<PlayerSpellInfo>();
        
        public SpellsChangingDispatcher(PlayerInfoChangeRegister playerInfoChangeRegister, PlayerInfoPreSaver preSaver)
        {
            _disposable = preSaver.PlayerInfoDiscarded.Subscribe((info => PlayerSpellInfoDiscarded.OnNext(info.SpellInfo)));
            playerInfoChangeRegister.Register(this);
        }

        public void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            PlayerSpellInfo changedPlayerSpellsInfo = playerInfo.SpellInfo;

            PlayerSpellInfoChanged.OnNext(changedPlayerSpellsInfo);
        }

        public void PlayerInfoDiscarded(PlayerInfo playerInfo)
        {
            PlayerSpellInfoDiscarded.OnNext(playerInfo.SpellInfo);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}