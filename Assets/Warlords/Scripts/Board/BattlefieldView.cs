using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private TMP_Text _idText;

        private Color _initColor;

        [Inject]
        private void Init(BattlefieldData battlefieldData)
        {
            _initColor = _renderer.material.color;

            SetId(battlefieldData.Index);
        }
      
        public void ColorMaterial(Color color)
        {
            _renderer.material.color = color;
        }

        public void ColorDefault()
        {
            ColorMaterial(_initColor);
        }

        private void SetId(int id)
        {
            _idText.text = id.ToString();
        }
        
    }
}