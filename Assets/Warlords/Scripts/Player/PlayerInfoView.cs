using TMPro;
using UnityEngine;
using Zenject;

namespace Warlords.Player
{
    public abstract class PlayerInfoView : MonoBehaviour, IPlayerInfoChangedListener
    {
        [SerializeField] protected TMP_Text _infoView;

        private void OnValidate()
        {
            _infoView = GetComponentInChildren<TMP_Text>();
        }

        [Inject]
        protected virtual void Init(PlayerInfoChangeRegister register)
        {
            register.Register(this);
        }

        public abstract void PlayerInfoChanged(PlayerInfo playerInfo);
        public abstract void PlayerInfoDiscarded(PlayerInfo playerInfo);
    }
}