using Warlords.UI.Menu;
using Warlords.UI.PopUp;

namespace Warlords.Battle
{
    public class RedirectionService
    {
        private readonly PopUpsService _popUpsService;
        private readonly MenuTagsContainer _menuTagsContainer;

        public RedirectionService(PopUpsService popUpsService, MenuTagsContainer menuTagsContainer)
        {
            _menuTagsContainer = menuTagsContainer;
            _popUpsService = popUpsService;
        }

        public void ShowMainMenu()
        {
            var context = new RedirectionPopUpContext();
            context.Description = "Return to Main Menu";
            context.MenuTag = _menuTagsContainer.MainMenuTag;
            
            _popUpsService.ShowRedirectionPopUp(context);
        }
        
    }
}