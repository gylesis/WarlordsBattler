using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Player;

namespace Warlords.UI.Appearance
{
    public class AppearanceItemsDictionary : IAsyncLoad
    {
        private Dictionary<AppearanceItemData, AppearanceItemView> _appearanceItems =
            new Dictionary<AppearanceItemData, AppearanceItemView>();

        private readonly AppearanceItemData[] _headItems;
        private readonly AppearanceItemData[] _bodyItems;
        private readonly AppearanceItemData[] _skinItems;

        public AppearanceItemsDictionary(AppearanceItemsDatas appearanceItemsDatas,
            AsyncLoadingsRegister asyncLoadingsRegister)
        {
            asyncLoadingsRegister.Register(this);

            _headItems = appearanceItemsDatas.HeadItems;
            _bodyItems = appearanceItemsDatas.BodyItems;
            _skinItems = appearanceItemsDatas.SkinItems;
        }

        public async UniTask AsyncLoad()
        {
            /*await LoadAssets(_headItems);
            await LoadAssets(_bodyItems);*/
        }

        async UniTask LoadAssets(AppearanceItemData[] itemDatas)
        {
            foreach (AppearanceItemData appearanceItemData in itemDatas)
            {
                var loadPath = appearanceItemData.Path;

                ResourceRequest resourceRequest = Resources.LoadAsync<AppearanceItemView>(loadPath);

                await resourceRequest;

                var appearanceItemView = resourceRequest.asset as AppearanceItemView;

                _appearanceItems.Add(appearanceItemData, appearanceItemView);
            }
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

            ResourceRequest resourceRequest = Resources.LoadAsync<AppearanceItemView>(path);
            await resourceRequest;

            var appearanceItemView = resourceRequest.asset as AppearanceItemView;

            return appearanceItemView;
        }
    }
}