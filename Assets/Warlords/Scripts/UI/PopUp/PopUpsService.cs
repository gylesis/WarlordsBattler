using System;
using UniRx;
using UnityEngine;
using Warlords.Infrastracture;
using Warlords.Utils;
using Zenject;

namespace Warlords.UI.PopUp
{
    public class PopUpsService : MonoBehaviour
    {
        [SerializeField] private Transform _popUpsParent;
        
        private UIFactory _factory;
        private CurtainService _curtainService;
        private PlayerNameSetter _nameSetter;

        private string _playerPopUpPrefabPath = "UI/ChangeNamePopUp";

        [Inject]
        private void Init(UIFactory factory, CurtainService curtainService, PlayerNameSetter nameSetter)
        {
            _nameSetter = nameSetter;
            _curtainService = curtainService;
            _factory = factory;
        }

        public async void SpawnPlayerNamePopUp(Action successNameChanging)
        {
            _curtainService.Show();
            var task = _factory.Create(_playerPopUpPrefabPath, _popUpsParent);
            await task;

            PlayerNamePopUp playerNamePopUp = task.Result;
            
            playerNamePopUp.PlayerNamePopUpButton.Clicked.Subscribe(SetName);
            
            void SetName(ReactiveButtonSender<byte, StringReactiveProperty> sender)
            {
                Debug.Log(sender.Value);
                _nameSetter.Set(sender.Value.Value);
                successNameChanging?.Invoke();
                Destroy(playerNamePopUp.gameObject);
            }

            _curtainService.Hide();
        }
        
    }
}