using UnityEngine;
using UnityEngine.UI;

namespace Warlords.Battle.Field
{
    public class ActionButtonView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private bool _coloring;

//        private Sequence _sequence = DOTween.Sequence();
        private Color _startColor;

        private void Awake()
        {
            _startColor = _image.color;
        }

        public void Show()
        {
            if (_coloring) return;

            _startColor = _image.color;

            _image.color = Color.cyan;
            _coloring = true;

            /*_sequence = DOTween.Sequence();

            var colorCyan = _image.DOColor(Color.cyan, 1);
            var colorDefault = _image.DOColor(defaultColor, 1);

            _sequence.Append(colorCyan);
            _sequence.Append(colorDefault);
            
            while (true)
            {
                await _sequence.Play().AsyncWaitForCompletion().AsUniTask();
            }*/
        }

        public void Hide()
        {
            // _sequence.Kill();
            _coloring = false;
            _image.color = _startColor;
        }
    }
}