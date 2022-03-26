﻿using System;
using System.Globalization;
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
        [SerializeField] private CanvasGroup _canvasGroup;

        private IDisposable _timer;

        private void Awake()
        {
            _canvasGroup.alpha = 0;
            _title.enabled = false;
        }

        public void Show()
        {
            _timer?.Dispose();
            _image.enabled = true;

            _canvasGroup.DOFade(1, 1);

            _counter.enabled = true;

            int time = 1;

            _timer = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .TakeUntilDestroy(this)
                .Subscribe((l =>
                {
                    time++;
                    _counter.text = time.ToString("00:00");
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
            _canvasGroup.DOFade(0, 1).OnComplete((() =>
            {
                _image.enabled = false;
                _title.enabled = false;
            }));
        }
    }
}