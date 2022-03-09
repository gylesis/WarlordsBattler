using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Warlords.UI.Units
{
    public class UnitViewsService : MonoBehaviour
    {
        [SerializeField] private HoverableElement[] _unitsViews;
        [SerializeField] private SplashScreen _splashScreen;
        
        private float _timeToSplash = 0.5f;
        private HoverableElement _currentHoveredObject;
        private DateTime _hoveredDate;
        private IDisposable _disposable;

        private Stack<HoverableElement> _hoverableElements = new Stack<HoverableElement>();
        
        private void Awake()
        {
            foreach (HoverableElement hoverableElement in _unitsViews)
            {
                hoverableElement.PointerEntered.TakeUntilDestroy(this).Subscribe((PointEntered));
                hoverableElement.PointerExit.TakeUntilDestroy(this).Subscribe((PointerExit));
            }
        }

        private void PointerExit(UIElementContextData<HoverableElement> data)
        {
            HoverableElement hoveredObject = data.Sender;
            
            if (ReferenceEquals(hoveredObject, _currentHoveredObject))
            {
                _disposable?.Dispose();
                _currentHoveredObject = null;
                _splashScreen.gameObject.SetActive(false);
            }
            
        }

        private void PointEntered(UIElementContextData<HoverableElement> data)
        {
            HoverableElement enteredObject = data.Sender;

            _currentHoveredObject = enteredObject;

            DateTime dataTime = data.Time;
            _hoveredDate = dataTime;

            _disposable?.Dispose();
            _disposable = Observable.EveryUpdate().TakeUntilDestroy(this).Subscribe((l =>
            {
                TimeSpan hoveredTime = DateTime.Now - _hoveredDate;

                if (hoveredTime.TotalSeconds > _timeToSplash)
                {
                    _splashScreen.SetPos(data.PointerEventData.position);
                    _splashScreen.gameObject.SetActive(true);

                    _disposable.Dispose();
                }
            }));
        }
    }
}