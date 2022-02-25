using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.PopUp
{
    public class AppearanceController
    {
       // private readonly Dictionary<AppearanceContainer, int> _appearanceContainer = new Dictionary<AppearanceContainer, int>();

        private readonly AppearanceContainer _headContainer;
        private readonly AppearanceContainer _bodyContainer;
        private readonly AppearanceContainer _skinContainer;
        
        private readonly CurtainService _curtainService;

        public AppearanceController(AppearanceContainer[] appearanceContainers, CurtainService curtainService)
        {
            _curtainService = curtainService;

            _headContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Head);
            _bodyContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Body);
            _skinContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Skin);

            SwitchToNext(AppearanceItemType.Body, true);
            SwitchToNext(AppearanceItemType.Head, true);
        }

        public async void SwitchToNext(AppearanceItemType itemType, bool isLeftSide)
        {
            _curtainService.Show();

            AppearanceContainer appearanceContainer = _bodyContainer;

            switch (itemType)
            {
                case AppearanceItemType.Head:
                    appearanceContainer = _headContainer;
                    break;
                case AppearanceItemType.Body:
                    appearanceContainer = _bodyContainer;
                    break;
                case AppearanceItemType.Skin:
                    appearanceContainer = _skinContainer;
                    break;
            }

           // _appearanceContainer[appearanceContainer]--;

            await appearanceContainer.UpdateView(isLeftSide);

            _curtainService.Hide();
        }
    }
}