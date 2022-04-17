namespace Warlords.Battle.Field
{
    public class ActionDispatcherLinker
    {
        public ActionDispatcherLinker(ActionDispatchService actionDispatchService, IActionDispatcher[] actionDispatchers)
        {
            foreach (IActionDispatcher dispatcher in actionDispatchers)
                dispatcher.DispatchService = actionDispatchService;
        }
    }
}