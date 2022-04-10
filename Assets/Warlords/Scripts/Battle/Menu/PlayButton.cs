using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class PlayButton : ReactiveButton<bool>
    {
        [Header("1 - <br> ACCEPT </br> , 0 - DECLINE")]
        [SerializeField] private bool _value;

        protected override bool Value => _value;
    }
}