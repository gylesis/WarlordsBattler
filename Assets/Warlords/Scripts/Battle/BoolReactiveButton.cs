using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class BoolReactiveButton : ReactiveButton<bool>
    {
        [SerializeField] private bool _value;
        protected override bool Value => _value;
    }
}