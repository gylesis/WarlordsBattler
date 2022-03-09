using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Player;
using Warlords.Player.Attributes;
using Zenject;

namespace Warlords.UI.Appearance
{
    public class AppearancePopUp : MonoBehaviour
    {
        private ISaveLoadDataService _saveLoadDataService;

        [Inject]
        private void Init(PlayerInfoPreSaver playerInfoPreSaver, RenderCamera renderCamera, ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            playerInfoPreSaver.PlayerInfoSaved.Subscribe(PlayerInfoSaved);
            renderCamera.SetPopUpRenderTexture();
        }

        public void PlayerInfoSaved(PlayerInfo playerInfo)
        {
            _saveLoadDataService.Overwrite(data => data.FirstActionsData.IsAvatarChosen = true);
            gameObject.SetActive(false);
        }

    }
}