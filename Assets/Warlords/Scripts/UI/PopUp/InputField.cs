using TMPro;
using UnityEngine;

namespace Warlords.UI.PopUp
{
    public class InputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputFieldText;
        public string Value => _inputFieldText.text;
    }
}