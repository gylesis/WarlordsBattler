using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Player;

namespace Warlords.UI.PopUp
{
    public class AppearanceItemsDictionary
    {
        private Dictionary<string, AppearanceItemView> _appearanceItems = new Dictionary<string, AppearanceItemView>();

        private AppearanceItemData[] _headItems;
        private AppearanceItemData[] _bodyItems;
        private AppearanceItemData[] _skinItems;
    
        public async Task<AppearanceItemView> Get(AppearanceItemType itemType, int index)
        {
            AppearanceItemData[] itemDatas = null;

            switch (itemType)
            {
                case AppearanceItemType.Head:
                    itemDatas = _headItems;
                    break;
                case AppearanceItemType.Body:
                    itemDatas = _bodyItems;
                    break;
                case AppearanceItemType.Skin:
                    itemDatas = _skinItems;
                    break;
            }

            AppearanceItemData appearanceItemData = itemDatas[0];
            string path = appearanceItemData.Path;

            var appearanceItemView = Resources.Load<AppearanceItemView>(path);

            await Task.Delay(1000);

            return appearanceItemView;
        }
    }
}