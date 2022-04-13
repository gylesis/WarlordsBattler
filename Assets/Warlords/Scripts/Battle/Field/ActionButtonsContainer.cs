using UnityEngine;

namespace Warlords.Battle.Field
{
    public class ActionButtonsContainer : MonoBehaviour
    {
        [SerializeField] private ActionButton[] _actionButtons;

        public ActionButton[] ActionButtons => _actionButtons;
    }
}