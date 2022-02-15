using System;
using UniRx;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Warlords.Utils
{
    public class CurtainService : MonoBehaviour
    {
        [SerializeField] private GameObject _curtainObj;
        [SerializeField] private Image _progressImage;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Show()
        {
            _progressImage.fillAmount = 1;
            _progressImage.enabled = true;
            _curtainObj.SetActive(true);
        }

        public void ShowWithProgress(FloatReactiveProperty sceneLoadReactiveProperty)
        {
            _progressImage.fillAmount = 0;
            _progressImage.enabled = true;
            _curtainObj.SetActive(true);
            
            sceneLoadReactiveProperty.Subscribe(value =>
            {
                _progressImage.fillAmount = value;
            });
        }
        
        public void Hide()
        {
            _progressImage.enabled = false;
            _curtainObj.SetActive(false);
        }
        
    }
}