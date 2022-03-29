using UnityEngine;

namespace Warlords.Board
{
    public class BoardInputService : MonoBehaviour
    {
        [SerializeField] private LayerMask _battlefieldsLayer;

        private void Update()
        {
            var mouseButtonUp = Input.GetMouseButton(0);
            
            if (mouseButtonUp == false) return;

            Vector3 mousePosition = Input.mousePosition;

            Camera camera = Camera.main;

            Ray screenToViewportPoint = camera.ScreenPointToRay(mousePosition);

            var raycast = Physics.Raycast(screenToViewportPoint, out var hit, _battlefieldsLayer);

            Debug.DrawRay(screenToViewportPoint.origin,camera.transform.forward * 100);
             
            if (raycast)
            {
                var component = hit.collider.gameObject.GetComponent<Renderer>();
                
                var tryGetComponent = hit.collider.gameObject.TryGetComponent(out BattlefieldView battlefieldView);

                if (tryGetComponent)
                {
                    component.material.color = Color.red;

                    Debug.Log($"Hit cell {battlefieldView.name}");
                }
                else
                {
                    Debug.Log($"Hit something that isn't cell {hit.collider.name}");
                }
            }
            
        }
    }
}