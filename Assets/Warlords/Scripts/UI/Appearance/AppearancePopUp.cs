using System;
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
        private RenderCamera _renderCamera;

        private bool _ableToSave;
        
        [Inject]
        private void Init(PlayerInfoPreSaver playerInfoPreSaver, RenderCamera renderCamera, ISaveLoadDataService saveLoadDataService)
        {
            _saveLoadDataService = saveLoadDataService;
            _renderCamera = renderCamera;
            
            playerInfoPreSaver.PlayerInfoSaved.Subscribe(PlayerInfoSaved);
            _renderCamera.SetPopUpRenderTexture();
        }

        public void PlayerInfoSaved(PlayerInfo playerInfo)
        {
            if(_ableToSave == false) return;
            
            _saveLoadDataService.Overwrite(data => data.FirstActionsData.IsAvatarChosen = true);
            gameObject.SetActive(false);
        }

        public void Show()
        {
            _renderCamera.SetPopUpRenderTexture();
            _ableToSave = true;
        }
       
    }
}