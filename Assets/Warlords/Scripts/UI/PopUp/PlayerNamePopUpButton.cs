using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.PopUp
{
    public class PlayerNamePopUpButton : ReactiveButton<string>
    {
        [SerializeField] private InputField _inputField;

        protected override string Value => _inputField.Value;
    }
}