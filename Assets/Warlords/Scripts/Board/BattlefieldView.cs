using TMPro;
using UnityEngine;
using Zenject;

namespace Warlords.Board
{
    public class BattlefieldView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private TMP_Text _idText;
        [SerializeField] private TMP_Text _costView;
        public bool IsColored { get; private set; }
        private Color _initColor;

        [Inject]
        private void Init(BattlefieldData battlefieldData)
        {
            _initColor = _renderer.material.color;

            SetId(battlefieldData.Index);
        }

        public void UpdateCost(float HCost, float GCost)
        {
            _costView.text = $"H:{HCost} G:{GCost}";
        }
        
        public void ColorMaterial(Color color)
        {
            _renderer.material.color = color;
            IsColored = true;
        }

        public void ColorDefault()
        {
            ColorMaterial(_initColor);
            IsColored = false;
        }

        private void SetId(int id)
        {
            _idText.text = id.ToString();
        }
        
    }
}