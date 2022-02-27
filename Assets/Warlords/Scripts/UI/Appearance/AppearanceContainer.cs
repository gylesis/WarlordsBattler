using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class AppearanceContainer : MonoBehaviour
    {
        public AppearanceItemType AppearanceType;

        [SerializeField] private TMP_Text _count;   
          
        [SerializeField] private AppearanceItemView[] _appearanceItemViews;  
       
        private AppearanceItemsDictionary _itemsDictionary;

        private int _index = 1;
        
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
                _index--;
            }
            else
            {
                _index++;
            }

            var maxIndex = _appearanceItemViews.Length;
            _index = Mathf.Clamp(_index, 1, maxIndex);

            _count.text = $"{_index} of {maxIndex}";
            
            AppearanceItemView appearanceItemView = _appearanceItemViews[_index - 1];

            ChangeItem(appearanceItemView);

            await Task.Delay(100);

            //  await _itemsDictionary.Get(AppearanceType, _index);
        }

        private void ChangeItem(AppearanceItemView targetItemView)
        {
            foreach (AppearanceItemView appearanceItemView in _appearanceItemViews)
            {
                if (appearanceItemView != targetItemView)
                {
                    appearanceItemView.gameObject.SetActive(false);
                }
            }
            targetItemView.gameObject.SetActive(true);
        }
        
    }


    public class AppearanceSaver
    {

        
        public void Save()
        {
            
        }
        
    }
    
}