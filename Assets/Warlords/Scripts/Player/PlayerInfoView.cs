using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Warlords.Infrastracture;
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
        private void Init(PlayerInfoChangeRegister register)
        {
            register.Register(this);
        }

        public abstract void PlayerInfoChanged(PlayerInfo playerInfo);
        public abstract void PlayerInfoDiscarded(PlayerInfo playerInfo);
    }
}