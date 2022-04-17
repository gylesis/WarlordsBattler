namespace Warlords.Battle.Field
{
    public class ActionDispatchService
    {
        private readonly IActionListener[] _actionListeners;

        public ActionDispatchService(IActionListener[] actionListeners)
        {
            _actionListeners = actionListeners;
        }

        public void Dispatch(ActContext context)
        {
            foreach (IActionListener listener in _actionListeners) 
                listener.ActHappened(context);
        }
        
    }
}