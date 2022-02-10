using System;
using UniRx;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Warlords.UI.PopUp
{
    public class CurtainService : MonoBehaviour
    {
        [SerializeField] private GameObject _curtainObj;
        [SerializeField] private Image _progressImage;
        
        private IDisposable _curtainDisposable;

        private void Awake()
        {
            DontDestroyOnLoad(transform.parent);
        }

        public void Show()
        {
            _progressImage.fillAmount = 1;
            _progressImage.enabled = true;
            _curtainObj.SetActive(true);
        }

        public void ShowWithProgress(IObservable<AsyncOperation> asyncObservable)
        {
            _curtainDisposable?.Dispose();
            
            _progressImage.enabled = true;
            _curtainObj.SetActive(true);
            
            _curtainDisposable = asyncObservable.Subscribe(value =>
            {
                _progressImage.fillAmount = value.progress;
                Debug.Log(value.progress);
            });
        }
        
        public void Hide()
        {
            _curtainDisposable?.Dispose();
            
            _progressImage.enabled = false;
            _curtainObj.SetActive(false);
        }
        
    }
}