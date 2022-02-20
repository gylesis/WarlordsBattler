using UniRx;
using Warlords.Utils;

namespace Warlords.Player.Spells
{
    public class SelectableSpellButtonsHandler
    {

        public void Register(SelectableSpellButton spellButton)
        {
            spellButton.Clicked.TakeUntilDestroy(spellButton).Subscribe((HandleClick));
        }

        private void HandleClick(ButtonContext<SpellData> context)
        {
        }
    }
}