using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class FirstActionsChecker
    {
        private readonly PopUpsService _popUpsService;
        private ISaveLoadDataService _loadDataService;

        public FirstActionsChecker(ISaveLoadDataService loadDataService, PopUpsService popUpsService)
        {
            _loadDataService = loadDataService;
            _popUpsService = popUpsService;
        }

        public void CheckIfNameTyped()
        {
            FirstActionsData firstActionsData = _loadDataService.Data.FirstActionsData; 
            
            if(firstActionsData.IsNameTyped) return;

            _popUpsService.SpawnPlayerNamePopUp(() =>
            {
                _loadDataService.Overwrite(data =>
                {
                    data.FirstActionsData.IsNameTyped = true;
                });
            });
        }
        
    }
}