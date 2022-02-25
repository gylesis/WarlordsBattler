using System;
using System.Linq;
using UniRx;
using UnityEngine;
using Warlords.Player.Attributes;

namespace Warlords.Player.Spells
{
    public class MainSpellsViewService : IDisposable
    {
        private readonly MainSpellView[] _mainSpellViews;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        private MainSpellsViewService(MainSpellsViewContainer mainSpellsViewContainer, SpellsChangingDispatcher spellsChangingDispatcher)
        { 
            spellsChangingDispatcher.PlayerSpellInfoChanged.Subscribe(PlayerSpellInfoChanged).AddTo(_disposable);
            spellsChangingDispatcher.PlayerSpellInfoDiscarded.Subscribe(OnPlayerInfoDiscarded).AddTo(_disposable);
            
            _mainSpellViews = mainSpellsViewContainer.MainSpellViews;
        }

        private void OnPlayerInfoDiscarded(PlayerSpellInfo playerSpellInfo)
        {
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _mainSpellViews.Length; i++)
            {
                MainSpellView mainSpellView = _mainSpellViews[i];
                SpellType spellType = mainSpellView.SpellType;

                if(spellType == SpellType.None) continue;
                                    
                SpellData spellData = spellDatas.First(data => data.Type == spellType);

                mainSpellView.UpdateView(spellData);
            }
        }

        private void PlayerSpellInfoChanged(PlayerSpellInfo playerSpellInfo)
        {
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _mainSpellViews.Length; i++)
            {
                MainSpellView mainSpellView = _mainSpellViews[i];
                SpellType spellType = mainSpellView.SpellType;

                if(spellType == SpellType.None) continue;
                                    
                SpellData spellData = spellDatas.First(data => data.Type == spellType);

                mainSpellView.UpdateView(spellData);
            }
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}