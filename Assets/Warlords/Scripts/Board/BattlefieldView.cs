using System;
using UnityEngine;

namespace Warlords.Board
{
    public class BattlefieldView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        private Color _initColor;

        private void Awake()
        {
            _initColor = _renderer.material.color;
        }

        public void ColorMaterial(Color color)
        {
            _renderer.material.color = color;
        }

        public void ColorDefault()
        {
            ColorMaterial(_initColor);
        }
        
    }
}