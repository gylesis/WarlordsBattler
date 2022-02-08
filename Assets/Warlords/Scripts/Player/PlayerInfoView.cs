using TMPro;
using UnityEngine;
using Zenject;

namespace Warlords.Player
{
    public class PlayerInfoView : MonoBehaviour, IPlayerInfoChangedListener
    {
        [SerializeField] private TMP_Text _fractionName;

        [Inject]
        private void Init(PlayerInfoChangeRegister register)
        {
//            if (attr != null && typeof(IPlayerInfoChangedListener).IsAssignableFrom(typeof(PlayerInfoView)))

            register.Register(this);
        }

        public void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _fractionName.text = playerInfo._faction.Name;
            _fractionName.color = playerInfo._faction.Color;
        }
    }

    public class WarlordFractionView : MonoBehaviour { }
}