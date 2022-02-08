using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class FirstActionsChecker
    {
        private readonly FirstActionsData _data;
        private readonly PopUpsService _popUpsService;

        public FirstActionsChecker(FirstActionsData data, PopUpsService popUpsService)
        {
            _popUpsService = popUpsService;
            _data = data;

            Debug.Log(data.IsNameTyped);
        }

        public void CheckIfNameTyped()
        {
            if(_data.IsNameTyped) return;
            _popUpsService.SpawnPlayerNamePopUp((() => _data.IsNameTyped = true));
        }
        
    }
}