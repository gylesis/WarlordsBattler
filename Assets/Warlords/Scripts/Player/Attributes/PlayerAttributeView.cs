using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private TMP_Text _name;
        
        public PlusUpgradeAttributeButton PlusButton;
        public MinusUpgradeAttributeButton MinusButton;
        
        public void Init(PlayerAttribute attribute)
        {
            _name.text = attribute.Name;
            
            PlusButton.Init(attribute);
            MinusButton.Init(attribute);
            
            attribute.Stat.Changed
                .TakeUntilDestroy(this)
                .Subscribe(UpdateView);

            UpdateView(attribute.Stat.Value);
        }

        private void UpdateView(int value)
        {
            _count.DOFade(0.3f,0.2f).OnComplete((() =>  _count.DOFade(1,0.2f)));
            _count.text = $": {value}";
        }
        
    }
}