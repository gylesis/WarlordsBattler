using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UniRx;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Player.Spells
{
    public class SelectableSpellsButtonsHandler : IDisposable
    {
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly List<SelectableSpellView> _spellViews = new List<SelectableSpellView>();
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SelectableSpellsButtonsHandler(PlayerInfoPreSaver playerInfoPreSaver,
            SpellsChangingDispatcher spellsChangingDispatcher)
        {
            spellsChangingDispatcher.PlayerSpellInfoChanged.Subscribe(PlayerSpellInfoChanged).AddTo(_disposable);
            spellsChangingDispatcher.PlayerSpellInfoDiscarded.Subscribe(OnPlayerInfoDiscarded).AddTo(_disposable);
            
            _playerInfoPreSaver = playerInfoPreSaver;
        }


        private void OnPlayerInfoDiscarded(PlayerSpellInfo playerSpellInfo)
        {
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _spellViews.Count; i++)
            {
                SelectableSpellView spellView = _spellViews[i];

                SpellData selectableSpellView = spellDatas.First(x => x.Type == spellView.SpellData.Type);

                if (spellView.SpellData.Index == selectableSpellView.Index)
                {
                    spellView.ShowOutline();
                }
                else
                {
                    spellView.HideOutline();
                }
            }
        }

        private void PlayerSpellInfoChanged(PlayerSpellInfo playerSpellInfo)
        {
            var spellDatas = playerSpellInfo.SpellDatas;

            for (var i = 0; i < _spellViews.Count; i++)
            {
                SelectableSpellView spellView = _spellViews[i];

                SpellData selectableSpellView = spellDatas.First(x => x.Type == spellView.SpellData.Type);

                if (spellView.SpellData.Index == selectableSpellView.Index)
                {
                    spellView.ShowOutline();
                }
                else
                {
                    spellView.HideOutline();
                }
            }
        }

        public void Register(SelectableSpellView spellView)
        {
            _spellViews.Add(spellView);

            SelectableSpellButton spellButton = spellView.SelectableSpellButton;
            spellButton.Clicked.TakeUntilDestroy(spellButton).Subscribe((HandleClick)).AddTo(_compositeDisposable);
        }

        private void HandleClick(EventContext<SpellData> context)
        {
            SpellData spellData = context.Value;
            SpellType spellType = spellData.Type;

            ShowSelectedSpellView(spellData);

            _playerInfoPreSaver.Overwrite(OverwritePlayerInfo);

            void OverwritePlayerInfo(PlayerInfo playerInfo)
            {
                var spellInfoSpellDatas = playerInfo.SpellInfo.SpellDatas;

                SpellData data = spellInfoSpellDatas.First(spell => spell.Type == spellType);

                var index = spellInfoSpellDatas.IndexOf(data);

                spellInfoSpellDatas[index] = spellData;
            }
        }

        private void ShowSelectedSpellView(SpellData spellData)
        {
            foreach (SelectableSpellView spellView in _spellViews)
            {
                if (spellView.SpellData.Type == spellData.Type)
                {
                    if (spellView.SpellData.Index == spellData.Index)
                    {
                        spellView.ShowOutline();
                    }
                    else
                    {
                        spellView.HideOutline();
                    }
                }
            }
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}