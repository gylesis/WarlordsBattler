using System.Linq;
using Warlords.Player.Attributes;
using Warlords.Utils;

namespace Warlords.UI.Appearance
{
    public class AppearanceController
    {
        private readonly AppearanceViewContainer _headViewContainer;
        private readonly AppearanceViewContainer _bodyViewContainer;
        private readonly AppearanceViewContainer _skinViewContainer;
        
        private readonly CurtainService _curtainService;
        private readonly PlayerInfoPreSaver _playerInfoPreSaver;

        public AppearanceController(AppearanceViewContainer[] appearanceContainers, CurtainService curtainService, PlayerInfoPreSaver playerInfoPreSaver)
        {
            _playerInfoPreSaver = playerInfoPreSaver;
            _curtainService = curtainService;

            _headViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Head);
            _bodyViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Body);
            //_skinViewContainer = appearanceContainers.First(x => x.AppearanceType == AppearanceItemType.Skin);

            var headIndex = _playerInfoPreSaver.PlayerInfo.Appearance.Head.Index;
            var bodyIndex = _playerInfoPreSaver.PlayerInfo.Appearance.Body.Index;
            
            _headViewContainer.Init(headIndex);
            _bodyViewContainer.Init(bodyIndex);

            SwitchToNext(AppearanceItemType.Head, false);
            SwitchToNext(AppearanceItemType.Body, false);
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

            await appearanceViewContainer.UpdateView(isLeftSide);

            Save();
            
            _curtainService.Hide();
        }

        private void Save()
        {
            var headIndex = _headViewContainer.Index;
            var bodyIndex = _bodyViewContainer.Index;

            _playerInfoPreSaver.Overwrite((data =>
            {
                data.Appearance.Head.Index = headIndex;
                data.Appearance.Body.Index = bodyIndex;
            }));
            
        }
        
    }
}