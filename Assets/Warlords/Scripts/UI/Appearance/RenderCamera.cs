using UnityEngine;

namespace Warlords.UI.Appearance
{
    public class RenderCamera : MonoBehaviour
    {
        [SerializeField] private Camera _renderCamera;

        [SerializeField] private RenderTexture _popupRenderTexture;
        [SerializeField] private RenderTexture _shotRenderTexture;

        public void SetPopUpRenderTexture()
        {
            _renderCamera.targetTexture = _popupRenderTexture;
        }
        
        public RenderTexture GetShot()
        {
            _renderCamera.targetTexture = _shotRenderTexture;
            _renderCamera.Render();

            return _shotRenderTexture;
        }

        private void ClearMemory()
        {
            
        }

    }
}