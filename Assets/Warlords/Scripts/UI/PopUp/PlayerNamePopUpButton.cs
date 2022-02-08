using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.UI.PopUp
{
    public class PlayerNamePopUpButton : ReactiveButton<byte, StringReactiveProperty>
    {
        [SerializeField] private InputField _inputField;

        private StringReactiveProperty ReactiveProperty
        {
            get
            {
                var stringReactiveProperty = new StringReactiveProperty();

                stringReactiveProperty.Value = _inputField.Value;
                return stringReactiveProperty;
            }
        }

        protected override StringReactiveProperty Value => ReactiveProperty;
        protected override byte Sender => 0;
    }
}