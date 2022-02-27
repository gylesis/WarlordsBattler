using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Warlords.Player;

namespace Warlords.UI.Appearance
{
    public class AppearanceViewContainer : MonoBehaviour
    {
        [SerializeField] private AppearanceItemType _appearanceItemType;
        [SerializeField] private TMP_Text _count;
        [SerializeField] private AppearanceItemView[] _appearanceItemViews;
        public AppearanceItemType AppearanceType => _appearanceItemType;
       
        private AppearanceItemsDictionary _itemsDictionary;
        
        private int _currentItemIndex = 1;
        
        /*
        public void Init(AppearanceItemsDictionary itemsDictionary)
        {
            _itemsDictionary = itemsDictionary;
        }
        */

        public async Task UpdateView(bool isLeftSide)
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

            _count.text = $"{_currentItemIndex} of {maxIndex}";
            
            AppearanceItemView appearanceItemView = _appearanceItemViews[_currentItemIndex - 1];

            ChangeItem(appearanceItemView);

            await Task.Delay(100);

            //  await _itemsDictionary.Get(AppearanceType, _index);
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

    public class AppearanceSaver
    {

        
        public void Save()
        {
            
        }
        
    }
    
}