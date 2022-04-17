namespace Warlords.Battle.Field
{
    public class ActionButtonsView
    {
        private readonly ActionButton[] _actionButtons;

        public ActionButtonsView(ActionButtonsContainer buttonsContainer)
        {
            _actionButtons = buttonsContainer.ActionButtons;
        }

        public void Show(ActionButton actionButton)
        {
            actionButton.ActionButtonView.Show();

            foreach (ActionButton button in _actionButtons)
            {
                if (button != actionButton)
                    button.ActionButtonView.Hide();
            }
        }

        public void HideAll()
        {
            foreach (ActionButton button in _actionButtons)
                button.ActionButtonView.Hide();
        }
    }
}