using System;
using UniRx;
using UnityEngine;
using Warlords.Board;
using Warlords.Utils;

namespace Warlords.Battle.Field
{
    public class ActionButtonsHandler : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private readonly BattlefieldInputAllowService _inputAllowService;

        public ActionButtonsHandler(ActionButtonsContainer buttonsContainer, BattlefieldInputAllowService inputAllowService)
        {
            _inputAllowService = inputAllowService;
            
            foreach (ActionButton button in buttonsContainer.ActionButtons)
                button.Clicked.Subscribe(OnActionButtonClicked).AddTo(_compositeDisposable);
        }

        private void OnActionButtonClicked(EventContext<ActionButton, ActionPanelButtonContext> context)
        {
            ActionType type = context.Value.ActionType;

            Debug.Log("action button clicked");
            
            switch (type)
            {
                case ActionType.CraftPotion1:
                    break;
                case ActionType.CraftPotion2:
                    break;
                case ActionType.CraftPotion3:
                    break;
                case ActionType.Attack:
                    break;
                case ActionType.HealthPoints:
                    break;
                case ActionType.Elixir:
                    break;
                case ActionType.DefensiveStance:
                    break;
                case ActionType.Move:
                    _inputAllowService.Allow();
                    break;
                case ActionType.Spell1:
                    break;
                case ActionType.Spell2:
                    break;
                case ActionType.Spell3:
                    break;
                case ActionType.Ultimate:
                    break;
                case ActionType.Counter:
                    break;
                case ActionType.Reaction:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}