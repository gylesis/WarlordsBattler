using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Warlords.Player;

namespace Warlords.UI.Appearance
{
    public class AppearanceItemsDictionary
    {
        private Dictionary<AppearanceItemData, AppearanceItemView> _appearanceItems = new Dictionary<AppearanceItemData, AppearanceItemView>();

        private readonly AppearanceItemData[] _headItems;
        private readonly AppearanceItemData[] _bodyItems;
        private readonly AppearanceItemData[] _skinItems;

        public AppearanceItemsDictionary(AppearanceItemsDatas appearanceItemsDatas)
        {
            _headItems = appearanceItemsDatas.HeadItems;
            _bodyItems = appearanceItemsDatas.BodyItems;
            _skinItems = appearanceItemsDatas.SkinItems;
        }
        
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