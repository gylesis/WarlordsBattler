using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Infrastructure.Factory;
using Warlords.Player;
using Warlords.Player.Attributes;
using Warlords.UI.Appearance;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.PopUp
{
    public class PopUpsService : MonoBehaviour
    {
        [SerializeField] private AppearancePopUp _appearancePopUp;  // To replace by spawning
        
        private PopUpsFactory _factory;
        private CurtainService _curtainService;
        private PlayerNameSetter _nameSetter;

        [Inject]
        private void Init(PopUpsFactory factory, CurtainService curtainService, PlayerNameSetter nameSetter, PlayerInfoPreSaver playerInfoPreSaver)
        {
            _nameSetter = nameSetter;
            _curtainService = curtainService;
            _factory = factory;     
        }

        public async void SpawnPlayerNamePopUp(Action successNameChanging)
        {
            _curtainService.Show();
            
            PlayerNamePopUp playerNamePopUp = await _factory.CreatePlayerNamePopUp();
            
            playerNamePopUp.PlayerNamePopUpButton.Clicked
                .TakeUntilDestroy(playerNamePopUp)
                .Subscribe(SetName);

            void SetName(EventContext<string> sender)
            {
                _nameSetter.Set(sender.Value);
                successNameChanging?.Invoke();
                Destroy(playerNamePopUp.gameObject);
            }
            
            _curtainService.Hide();
        }

        public void ShowAppearancePopUp()
        {
            _appearancePopUp.gameObject.SetActive(true);
        }

        public async UniTask ShowRedirectionPopUp(RedirectionPopUpContext context)
        {
            var redirectionPopUp = await _factory.CreateRedirectionPopUp();
            
            redirectionPopUp.SetDirectionToOpenMenu(context);
            redirectionPopUp.OnSucceedRedirect.Take(1).Subscribe((popUp => Destroy(popUp.gameObject))); // need to add to pool
        }
    }
    
}