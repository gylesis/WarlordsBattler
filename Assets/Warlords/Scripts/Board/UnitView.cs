using UnityEngine;

namespace Warlords.Board
{
    public class UnitView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
        
    }
}