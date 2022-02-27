using System.Linq;
using Warlords.Utils;

namespace Warlords.UI.Appearance
{
    public class AppearanceController
    {
       // private readonly Dictionary<AppearanceContainer, int> _appearanceContainer = new Dictionary<AppearanceContainer, int>();

        private readonly AppearanceViewContainer _headViewContainer;
        private readonly AppearanceViewContainer _bodyViewContainer;
        private readonly AppearanceViewContainer _skinViewContainer;
        
        private readonly CurtainService _curtainService;

        public AppearanceController(AppearanceViewContainer[] appearanceContainers, CurtainService curtainService)
        {
            _curtainService = curtainService;

            _headViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Head);
            _bodyViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Body);
            _skinViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Skin);

            SwitchToNext(AppearanceItemType.Body, true);
            SwitchToNext(AppearanceItemType.Head, true);
        }

        public async void SwitchToNext(AppearanceItemType itemType, bool isLeftSide)
        {
            _curtainService.Show();

            AppearanceViewContainer appearanceViewContainer = _bodyViewContainer;

            switch (itemType)
            {
                case AppearanceItemType.Head:
                    appearanceViewContainer = _headViewContainer;
                    break;
                case AppearanceItemType.Body:
                    appearanceViewContainer = _bodyViewContainer;
                    break;
                case AppearanceItemType.Skin:
                    appearanceViewContainer = _skinViewContainer;
                    break;
            }

           // _appearanceContainer[appearanceContainer]--;

            await appearanceViewContainer.UpdateView(isLeftSide);

            _curtainService.Hide();
        }

        public void Save()
        {
        }
        
    }
}