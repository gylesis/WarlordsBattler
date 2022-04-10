using UniRx;
using UnityEngine;
using Warlords.Utils;

namespace Warlords.Battle
{
    public class AcceptButtonsPopUp : MonoBehaviour
    {
        [SerializeField] private BoolReactiveButton _acceptButton;
        [SerializeField] private BoolReactiveButton _declineButton;
        
        public Subject<bool> DecisionMake { get; } = new Subject<bool>();

        private void OnEnable()
        {
            _acceptButton.Clicked.TakeUntilDestroy(this).Subscribe(OnDecisionMake);
            _declineButton.Clicked.TakeUntilDestroy(this).Subscribe(OnDecisionMake);
        }

        private void OnDecisionMake(EventContext<bool> context)
        {
            DecisionMake.OnNext(context.Value);
            gameObject.SetActive(false); // need to move to pool TODO
        }
    }

    public class ProjectPopUpsFactory
    {
        // TODO
    }
    
}