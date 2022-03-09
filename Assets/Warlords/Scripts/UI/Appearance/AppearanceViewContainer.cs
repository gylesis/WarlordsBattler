using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Warlords.UI.Appearance
{
    public class AppearanceViewContainer : MonoBehaviour
    {
        [SerializeField] private AppearanceItemType _appearanceItemType;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private AppearanceItemView[] _appearanceItemViews;
        public AppearanceItemType AppearanceType => _appearanceItemType;
       
       // private AppearanceItemsDictionary _itemsDictionary;

        public int Index { get; set; }
        
        private int _currentItemIndex = 1;

        public void Init(int itemIndex)
        {
            _currentItemIndex = itemIndex;

            _currentItemIndex--;
            
            int index = 1;
            
            foreach (AppearanceItemView appearanceItemView in _appearanceItemViews)
            {
                appearanceItemView.Index = index++;
            }
        }

        public async UniTask UpdateView(bool isLeftSide)
        {
            if (isLeftSide)
            {
                _currentItemIndex--;
            }
            else
            {
                _currentItemIndex++;
            }

            var maxIndex = _appearanceItemViews.Length;
            _currentItemIndex = Mathf.Clamp(_currentItemIndex, 1, maxIndex);

            Index = _currentItemIndex;
            
            _count.text = $"{_currentItemIndex} of {maxIndex}";
            
            var appearanceItemView = _appearanceItemViews[_currentItemIndex - 1];

            ChangeItem(appearanceItemView);

            await UniTask.CompletedTask;
        }

        private void ChangeItem(AppearanceItemView targetItemView)
        {
            foreach (AppearanceItemView appearanceItemView in _appearanceItemViews)
            {
                if (appearanceItemView == targetItemView)
                {
                    targetItemView.gameObject.SetActive(true);
                }
                else
                {
                    appearanceItemView.gameObject.SetActive(false);
                }
            }
        }
        
    }

}