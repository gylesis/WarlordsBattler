using TMPro;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle.Field
{
    public class ActionButton : ReactiveButton<ActionButton, ActionPanelButtonContext>
    {
        [SerializeField] private ActionPanelButtonContext _context;
        [SerializeField] private ActionButtonView _actionButtonView;
        
        public ActionButtonView ActionButtonView => _actionButtonView;
        protected override ActionPanelButtonContext Value => _context;
        protected override ActionButton Sender => this;

        private void OnEnable()
        {
            if (GetComponentInChildren<TMP_Text>().text == "nnnn")
                Rename();
        }

        [ContextMenu(nameof(Rename))]
        private void Rename()
        {
            GetComponentInChildren<TMP_Text>().text = _context.ActionType.ToString();
        }
    }
}