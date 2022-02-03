using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace Warlords
{
    public class FractionsView : MonoBehaviour , IGeneratable
    {
        private FilteredFractions _fractions;
        private FractionsViewFactory _fractionsFactory;
        private FractionView _fractionViewPrefab;
        private PlayerInfoSetter _playerInfoSetter;

        [Inject]
        private void Init(FilteredFractions fractions, FractionsViewFactory fractionsFactory, FractionView fractionViewPrefab, PlayerInfoSetter playerInfoSetter)
        {
            _playerInfoSetter = playerInfoSetter;
            _fractionViewPrefab = fractionViewPrefab;
            _fractionsFactory = fractionsFactory;
            _fractions = fractions;
        }

        public async Task Generate()
        {
            var fractions = _fractions.WarlordFractions;

            foreach (WarlordFraction warlordFraction in fractions)
            {
                var context = new FractionViewContext();

                context.WarlordFraction = new WarlordFraction();
                
                context.WarlordFraction.Color = warlordFraction.Color;
                context.WarlordFraction.Name = warlordFraction.Name;
                context.Prefab = _fractionViewPrefab;
                context.Parent = transform;

                FractionView fractionView = _fractionsFactory.Create(context);

                fractionView.FractionButton.Clicked.
                    TakeUntilDestroy(fractionView)
                    .Subscribe(OnFractionChanged);
            }

            await Task.Delay(100);
        }

        private void OnFractionChanged(WarlordFraction fraction)
        {
            _playerInfoSetter.SetFraction(fraction);
        }
        
    }
}