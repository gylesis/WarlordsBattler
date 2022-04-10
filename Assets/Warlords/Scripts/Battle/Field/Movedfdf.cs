using System;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle.Field
{
    public class Movedfdf
    {
        
    }

    public class ActionButton : ReactiveButton<ActionButton, ActionPanelButtonContext>
    {
        [SerializeField] private ActionPanelButtonContext _context;
        
        protected override ActionPanelButtonContext Value { get; }
        protected override ActionButton Sender => this;
    }

    [Serializable]
    public struct ActionPanelButtonContext
    {
        public ActionType ActionType;
    }
    
    
    public enum ActionType
    {
        CraftPotion1,
        CraftPotion2,
        CraftPotion3,
        Attack,
        HealthPoints,
        Elixir,
        DefensiveStance,
        Move,
        Spell1,
        Spell2,
        Spell3,
        Ultimate,
        Counter,
        Reaction
    }
    
    
}