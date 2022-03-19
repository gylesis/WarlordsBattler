using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Warlords.UI.Units
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIElement<TSender> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler,
        IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        public RectTransform Rect => _rectTransform;
        protected abstract TSender Sender { get; }

        public Subject<UIElementContextData<TSender>> PointerEntered { get; } =
            new Subject<UIElementContextData<TSender>>();

        public Subject<UIElementContextData<TSender>> PointerExit { get; } =
            new Subject<UIElementContextData<TSender>>();

        public Subject<UIElementContextData<TSender>> PointerDrag { get; } =
            new Subject<UIElementContextData<TSender>>();

        public Subject<UIElementContextData<TSender>> PointerUp { get; } =
            new Subject<UIElementContextData<TSender>>();

        public Subject<UIElementContextData<TSender>> PointerDown { get; } =
            new Subject<UIElementContextData<TSender>>();

        public Subject<UIElementContextData<TSender>> PointerClick { get; } =
            new Subject<UIElementContextData<TSender>>();

        private void Reset()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }

        private void Awake()
        {
            if (_rectTransform == null)
                _rectTransform = GetComponent<RectTransform>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerEntered.OnNext(contextData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerExit.OnNext(contextData);
        }

        private UIElementContextData<TSender> GetContextData(PointerEventData eventData)
        {
            var contextData = new UIElementContextData<TSender>();
            contextData.Sender = Sender;
            contextData.Time = DateTime.Now;
            contextData.PointerEventData = eventData;

            return contextData;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerDrag.OnNext(contextData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerUp.OnNext(contextData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerDown.OnNext(contextData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var contextData = GetContextData(eventData);

            PointerClick.OnNext(contextData);
        }
    }

    public struct UIElementContextData<TSender>
    {
        public TSender Sender;
        public PointerEventData PointerEventData;
        public DateTime Time;
    }
}