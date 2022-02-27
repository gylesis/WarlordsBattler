﻿using System;
using UniRx;
using UnityEngine;
using Warlords.Infrastracture.Factory;
using Warlords.Player;
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
            
            PlayerNamePopUp playerNamePopUp = await _factory.CreatePlayerNamePopUp(AssetsPath.PlayerPopUpPrefabPath, _popUpsParent);
            
            playerNamePopUp.PlayerNamePopUpButton.Clicked
                .TakeUntilDestroy(playerNamePopUp)
                .Subscribe(SetName);
            
            void SetName(ButtonContext<string> sender)
            {
                _nameSetter.Set(sender.Value);
                successNameChanging?.Invoke();
                Destroy(playerNamePopUp.gameObject);
            }

            _curtainService.Hide();
        }
        
    }
}