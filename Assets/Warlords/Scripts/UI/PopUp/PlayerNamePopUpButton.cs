using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.PopUp
{
    public class PlayerNamePopUpButton : ReactiveButton<byte, string>
    {
        [SerializeField] private InputField _inputField;

        protected override string Value => _inputField.Value;
        protected override byte Sender => 0;
    }
}