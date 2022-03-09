using System.Collections.Generic;

namespace Warlords.Factions
{
    public abstract class ButtonsHandler<TButtonType>
    {
        protected List<TButtonType> _buttons = new List<TButtonType>();
        
        public void Register(TButtonType button)
        {
            _buttons.Add(button);
            HandleClick(button);
        }

        protected abstract void HandleClick(TButtonType button);

    }
}