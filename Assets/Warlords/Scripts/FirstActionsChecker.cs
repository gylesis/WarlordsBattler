using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using Warlords.Infrastructure;
using Warlords.Player.Attributes;
using Warlords.UI.Menu;
using Warlords.UI.PopUp;

namespace Warlords
{
    public class FirstActionsChecker
    {
        private readonly PopUpsService _popUpsService;
        private readonly ISaveLoadDataService _saveLoadDataService;

        private bool _factionTyped;
        private readonly MenuTagsContainer _menuTagsContainers;

        public FirstActionsChecker(ISaveLoadDataService saveLoadDataService, PopUpsService popUpsService,
            PlayerInfoPreSaver preSaver, MenuTagsContainer menuTagsContainers)
        {
            _menuTagsContainers = menuTagsContainers;
            
            preSaver.PlayerInfoSaved.Subscribe((info =>
            {
                if (info.Faction.Name != String.Empty) _factionTyped = true;
            }));

            _saveLoadDataService = saveLoadDataService;
            _popUpsService = popUpsService;
        }

        public async void CheckWarlordMenuFirstEnter() // fucking crutch. need to do it good. need to do it like commands.
        {
            if (_factionTyped == false) 
            {
                await IsFactionSelected();
            }
            else if (_saveLoadDataService.Data.FirstActionsData.IsNameTyped == false)
            {
                await IsNameTyped();
                
                IsAvatarChosen();
            }
            else if (_saveLoadDataService.Data.FirstActionsData.IsAvatarChosen == false)
            {
                IsAvatarChosen();
            }
        }

        private async UniTask IsNameTyped()
        {
            FirstActionsData firstActionsData = _saveLoadDataService.Data.FirstActionsData;

            if (firstActionsData.IsNameTyped)
            {
                await UniTask.CompletedTask;
                return;
            }

            bool temp = false;

            _popUpsService.SpawnPlayerNamePopUp(() =>
            {
                _saveLoadDataService.Overwrite(data =>
                {
                    data.FirstActionsData.IsNameTyped = true;
                });

                temp = true;
            });

            await UniTask.WaitUntil((() => temp));
        }

        private void IsAvatarChosen()
        {
            var isAvatarChosen = _saveLoadDataService.Data.FirstActionsData.IsAvatarChosen;

            if (isAvatarChosen == false)
            {
                _popUpsService.ShowAppearancePopUp();
            }
        }

        private async UniTask IsFactionSelected()
        {
            var factionName = _saveLoadDataService.Data.PlayerInfo.Faction.Name;

            if (factionName == String.Empty)
            {
                var redirectionPopUpContext = new RedirectionPopUpContext();

                redirectionPopUpContext.Description = "Firstly you must choose faction!";
                redirectionPopUpContext.MenuTag = _menuTagsContainers.FactionTag;

                await _popUpsService.ShowRedirectionPopUp(redirectionPopUpContext);
            }
            
            await UniTask.CompletedTask;
        }
    }
}