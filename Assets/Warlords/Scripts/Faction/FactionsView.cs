using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastracture;
using Warlords.Player;
using Warlords.Utils;
using Zenject;

namespace Warlords.Faction
{
    public class FactionsView : MonoBehaviour, IGeneratable
    {
        private FilteredFactions _factions;
        private FactionsViewFactory _factionsFactory;
        private FactionView _factionViewPrefab;
        private PlayerInfoSetter _playerInfoSetter;

        [Inject]
        private void Init(FilteredFactions factions, FactionsViewFactory factionsFactory,
            FactionView factionViewPrefab, PlayerInfoSetter playerInfoSetter)
        {
            _playerInfoSetter = playerInfoSetter;
            _factionViewPrefab = factionViewPrefab;
            _factionsFactory = factionsFactory;
            _factions = factions;
        }

        public async Task Generate()
        {
            var fractions = _factions.WarlordFractions;

            foreach (WarlordFaction warlordFraction in fractions)
            {
                var context = new FractionViewContext();

                context.warlordFaction = new WarlordFaction();

                context.warlordFaction.Color = warlordFraction.Color;
                context.warlordFaction.Name = warlordFraction.Name;
                context.Prefab = _factionViewPrefab;
                context.Parent = transform;

                FactionView factionView = _factionsFactory.Create(context);

                factionView.FactionButton.Clicked
                    .TakeUntilDestroy(factionView)
                    .Subscribe(OnFactionChanged);
            }

            await Task.Delay(100);
        }

        private void OnFactionChanged(ReactiveButtonSender<FactionView, WarlordFaction> sender)
        {
            _playerInfoSetter.SetFaction(sender.Value);
        }
    }
}