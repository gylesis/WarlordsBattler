using System;
using System.Collections.Generic;
using UniRx;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Faction
{
    public class FactionButtonsHandler : IDisposable
    {
        private List<FactionView> _factionViews = new List<FactionView>();
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        
        public FactionButtonsHandler(PlayerInfoPreSaver playerInfoPreSaver)
        {
            _playerInfoPreSaver = playerInfoPreSaver;

            _playerInfoPreSaver.PlayerInfoSaved.Subscribe(OnPlayerInfoSaved).AddTo(_compositeDisposable);
            _playerInfoPreSaver.PlayerInfoDiscarded.Subscribe(OnPlayerInfoDiscarded).AddTo(_compositeDisposable);
        }

        private void OnPlayerInfoDiscarded(PlayerInfo playerInfo)
        {
            ChangeView(playerInfo.Faction);
        }
        
        private void OnPlayerInfoSaved(PlayerInfo playerInfo)
        {
            ChangeView(playerInfo.Faction);
        }

        public void Register(List<FactionView> factionView)
        {
            _factionViews = new List<FactionView>(factionView);
            
            foreach (FactionView view in factionView)
            {
                HandleClick(view);
            }

            ChangeView(_playerInfoPreSaver.PlayerInfo.Faction);
        }

        private void HandleClick(FactionView button)
        {
            button.FactionButton.Clicked.TakeUntilDestroy(button).Subscribe((Click));
        }

        private void Click(ButtonContext<FactionView, WarlordFaction> context)
        {
            WarlordFaction playerInfoFaction = context.Value;   
            
            ChangeView(playerInfoFaction);

            _playerInfoPreSaver.Overwrite(playerInfo =>
            {
                playerInfo.Faction = playerInfoFaction;
            });
        }

        private void ChangeView(WarlordFaction targetFaction)
        {
            foreach (FactionView factionView in _factionViews)
            {
                if (factionView.WarlordFaction.Name == targetFaction.Name)
                {
                    factionView.SelectionView.Show();
                }
                else
                {
                    factionView.SelectionView.Hide();
                }
            }
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
    
}