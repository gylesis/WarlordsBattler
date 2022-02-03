using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords
{
    [RequireComponent(typeof(Button))]
    public abstract class ReactiveButton<T> : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected abstract T Value { get; }
        
        private void Reset() => 
            _button = GetComponent<Button>();

        public Subject<T> Clicked = new Subject<T>();

        private void Awake()
        {
            _button.onClick
                .AsObservable()
                .TakeUntilDestroy(this)
                .Subscribe((_ => Clicked.OnNext(Value)));
        }
    }
}