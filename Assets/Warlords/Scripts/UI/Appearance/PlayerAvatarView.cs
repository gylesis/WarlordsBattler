using UnityEngine;
using UnityEngine.UI;
using Warlords.Player;
using Zenject;

namespace Warlords.UI.Appearance
{
    public class PlayerAvatarView : MonoBehaviour, IPlayerInfoChangedListener
    {
        [SerializeField] private RawImage _avatarImage;
        
        private RenderCamera _renderCamera;

        [Inject]
        private void Init(PlayerInfoChangeRegister playerInfoChangeRegister, RenderCamera renderCamera)
        {
            _renderCamera = renderCamera;
            playerInfoChangeRegister.Register(this);
        }

        public void PlayerInfoChanged(PlayerInfo playerInfo)
        {
            RenderTexture renderTexture = _renderCamera.GetShot();
            _avatarImage.texture = renderTexture;
        }

        public void PlayerInfoDiscarded(PlayerInfo playerInfo)
        { 
            RenderTexture renderTexture = _renderCamera.GetShot();
            _avatarImage.texture = renderTexture;
        }
    }
}