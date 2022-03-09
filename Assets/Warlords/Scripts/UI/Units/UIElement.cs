using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Warlords.UI.Units
{
    public abstract class UIElement<TSender> : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected abstract TSender Sender { get; }  
        public Subject<UIElementContextData<TSender>> PointerEntered { get; } = new Subject<UIElementContextData<TSender>>();
        public Subject<UIElementContextData<TSender>> PointerExit { get; } = new Subject<UIElementContextData<TSender>>();
        
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
    }

    public struct UIElementContextData<TSender>
    {
        public TSender Sender;
        public PointerEventData PointerEventData;
        public DateTime Time;
    }
    
}