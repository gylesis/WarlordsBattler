using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Warlords.Factions;

namespace Warlords.Player.Attributes
{
    public class PlayerAttributesViewService
    {
        private PlayerAttributeView[] _attributeViews;
        private IDisposable _disposable;
        private readonly PlayerAttributesProvider _playerAttributesProvider;

        public PlayerAttributesViewService(PlayerAttributesProvider playerAttributesProvider)
        {
            _playerAttributesProvider = playerAttributesProvider;
        }

        public void RegisterViews(PlayerAttributeView[] attributeViews)
        {
            _attributeViews = attributeViews;
        }

        public void UpdateAttributesView(Faction targetFaction)
        {
            _disposable?.Dispose();

            Debug.Log("Update");
            
            GameObject attributeGameObj = _attributeViews[1].gameObject;
            
            _disposable = _attributeViews[0].OnEnableAsObservable().Take(1).TakeUntilDestroy(attributeGameObj).Subscribe((unit =>
            {
                var playerStartAttributes = _playerAttributesProvider.GetAttributesByFaction(targetFaction);

                for (var i = 0; i < _attributeViews.Length; i++)
                {
                    PlayerAttributeView playerAttributeView = _attributeViews[i];
                    PlayerAttribute playerStartAttribute = playerStartAttributes[i];

                    playerAttributeView.UpdateAttributeStats(playerStartAttribute);
                }
            }));
        }
    }
}