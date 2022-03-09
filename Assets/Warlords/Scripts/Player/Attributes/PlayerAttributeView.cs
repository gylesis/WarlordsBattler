using System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private PlusUpgradeAttributeButton _plusButton;
        [SerializeField] private MinusUpgradeAttributeButton _minusButton;

        public PlusUpgradeAttributeButton PlusButton => _plusButton;
        public MinusUpgradeAttributeButton MinusButton => _minusButton;

        private IDisposable _disposable;
        private PlayerAttribute _attribute;

        public void Init(PlayerAttribute attribute)
        {
            _attribute = attribute;
            _disposable?.Dispose();
            
            _name.text = $"{attribute.Name} :";
            
            PlusButton.Init(attribute);
            MinusButton.Init(attribute);

            _disposable = attribute.Stat.Changed
                .TakeUntilDestroy(this)
                .Subscribe(UpdateView);

            UpdateView(attribute.Stat.Value);
        }

        public void UpdateAttributeStats(PlayerAttribute playerAttribute)
        {
            _attribute.Stat.Value = playerAttribute.Stat.Value;
        }
        
        private void UpdateView(int value)
        {
            _count.DOFade(0.3f,0.2f).OnComplete((() =>  _count.DOFade(1,0.2f)));
            _count.text = $"{value}";
        }
    }
}