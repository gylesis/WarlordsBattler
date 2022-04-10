using System.Diagnostics;
using System.Globalization;
using System.Timers;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Warlords.Utils;
using Zenject;

namespace Warlords.Battle
{
    public class BattleAreaCurtain : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private CanvasGroup _canvasGroup;

        private IntStopwatch _stopwatch;

        [Inject]
        private void Init(IntStopwatch intStopwatch)
        {
            _canvasGroup.alpha = 0;
            _title.enabled = false;
            _stopwatch = intStopwatch;
        }
        
        public void Show()
        {
            _stopwatch.Stop();
            _image.enabled = true;

            _canvasGroup.DOFade(1, 1);

            _counter.enabled = true;
            
            _stopwatch.Start();
            
            _stopwatch.Tick.TakeUntilDestroy(this).Subscribe((span =>
            {
                _counter.text = span.Seconds.ToString("00:00");
            }));
        }

        public void UpdateTitle(string title)
        {
            _title.enabled = true;
            _title.text = title;
        }

        public void StopStopwatch()
        {
            _stopwatch.Stop();
        }

        public void Hide()
        {
            StopStopwatch();
            
            _canvasGroup.DOFade(0, 1).OnComplete((() =>
            {
                _image.enabled = false;
                _title.enabled = false;
            }));
        }
    }
}