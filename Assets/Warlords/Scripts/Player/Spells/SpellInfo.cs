using System;
using UnityEngine;

namespace Warlords.Player.Spells
{
    [Serializable]
    public class SpellInfo
    {
        [HideInInspector] public string Name;
        public SpellType Type;
    }
}