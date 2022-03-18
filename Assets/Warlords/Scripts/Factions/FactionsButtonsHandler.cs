using System;
using System.Collections.Generic;
using UniRx;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.Factions
{
    public class FactionsButtonsHandler : IDisposable
    {
        private List<FactionView> _factionViews = new List<FactionView>();
        
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly PlayerAttributesViewService _playerAttributesViewService;
        private readonly PlayerAttributesProvider _playerAttributesProvider;

        public FactionsButtonsHandler(PlayerInfoPreSaver playerInfoPreSaver, PlayerAttributesViewService playerAttributesViewService, PlayerAttributesProvider playerAttributesProvider)
        {
            _playerAttributesProvider = playerAttributesProvider;
            _playerAttributesViewService = playerAttributesViewService;
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
            Faction faction = playerInfo.Faction;

            if(faction.Name == String.Empty) return;
            
            ChangeView(faction);
            _playerAttributesViewService.UpdateAttributesView(faction);
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

        private void Click(EventContext<FactionView, Faction> context)
        {
            Faction faction = context.Value;   
            
            ChangeView(faction);

            _playerInfoPreSaver.Overwrite(playerInfo =>
            {
                playerInfo.Faction = faction;
                playerInfo.AttributesData.Attributes = _playerAttributesProvider.GetAttributesByFaction(faction);
                playerInfo.AttributesData.LeftUpgrades = 5;
            });
        }

        private void ChangeView(Faction targetFaction)
        {
            foreach (FactionView factionView in _factionViews)
            {
                if (factionView.Faction.Color == targetFaction.Color)
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