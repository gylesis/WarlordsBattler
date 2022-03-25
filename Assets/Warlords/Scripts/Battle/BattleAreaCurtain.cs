using System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords.Battle
{
    public class BattleAreaCurtain : MonoBehaviour 
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private TMP_Text _title;   
        
        private IDisposable _timer;

        private void Awake()
        {
            Hide();
        }

        public void Show()
        {   
            _timer?.Dispose();  
            _image.enabled = true;

            _image.DOFade(1, 1); 
            
            _counter.enabled = true;
            
            int time = 0;

            _timer = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .TakeUntilDestroy(this)
                .Subscribe((l =>
            {
                time++;
                _counter.text = time.ToString("SS:MM");
            }));
        }

        public void UpdateTitle(string title)
        {
            _title.enabled = true;
            _title.text = title;
        }
        
        public void Hide()
        {
            _timer?.Dispose();
            _image.DOFade(0, 1).OnComplete((() =>
            {
                _image.enabled = false;
                _title.enabled = false;
            })); 
          
        }
    }
}