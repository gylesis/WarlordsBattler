using System;
using UniRx;
using UnityEngine;
using Warlords.Player.Attributes;

namespace Warlords.Player.Spells
{
    public class MainSpellsViewService : IDisposable
    {
        private readonly MainSpellView[] _mainSpellViews;
        private readonly IDisposable _disposable;

        private MainSpellsViewService(MainSpellsViewContainer mainSpellsViewContainer, SpellsChangingDispatcher spellsChangingDispatcher)
        {
            _disposable = spellsChangingDispatcher.PlayerSpellInfoChanged.Subscribe((PlayerSpellInfoChanged));

            spellsChangingDispatcher.PlayerSpellInfoDiscarded.Subscribe((OnPlayerInfoDiscarded));
            
            _mainSpellViews = mainSpellsViewContainer.MainSpellViews;
        }

        private void OnPlayerInfoDiscarded(PlayerSpellInfo playerSpellInfo)
        {
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _mainSpellViews.Length; i++)
            {
                SpellData spellData = spellDatas[i];

                MainSpellView mainSpellView = _mainSpellViews[i];
                
                mainSpellView.UpdateView(spellData);
            }
        }

        private void PlayerSpellInfoChanged(PlayerSpellInfo playerSpellInfo)
        {
            Debug.Log("Update View");
            
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _mainSpellViews.Length; i++)
            {
                SpellData spellData = spellDatas[i];

                MainSpellView mainSpellView = _mainSpellViews[i];
                
                mainSpellView.UpdateView(spellData);
            }
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}