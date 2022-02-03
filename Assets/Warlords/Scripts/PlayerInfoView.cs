using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Warlords
{
    public class PlayerInfoView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fractionName;

        [Inject]
        private void Init(PlayerInfoSetter infoSetter)
        {
            infoSetter.PlayerInfoChanged
                .TakeUntilDestroy(this)
                .Subscribe(PlayerInfoChanged);
        }

        private void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            _fractionName.text = playerInfo.Fraction.Name;
            _fractionName.color = playerInfo.Fraction.Color;
        }
        
    }
}