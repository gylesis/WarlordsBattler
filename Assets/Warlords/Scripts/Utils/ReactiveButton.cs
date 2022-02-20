using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Warlords.Utils
{
    [RequireComponent(typeof(Button))]
    public abstract class ReactiveButton<TSender, TValue> : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected abstract TValue Value { get; }
        protected abstract TSender Sender { get; }

        private void Reset() =>
            _button = GetComponent<Button>();

        public Subject<ButtonContext<TSender, TValue>> Clicked =
            new Subject<ButtonContext<TSender, TValue>>();

        private IDisposable _disposable;

        private void Awake()
        {
            _disposable = _button.onClick
                .AsObservable()
                .TakeUntilDestroy(this)
                .Subscribe((_ =>
                {
                    var buttonContext = new ButtonContext<TSender, TValue>();

                    buttonContext.Sender = Sender;
                    buttonContext.Value = Value;

                    Clicked.OnNext(buttonContext);
                }));
        }
    }


    [RequireComponent(typeof(Button))]
    public abstract class ReactiveButton<TValue> : MonoBehaviour
    {
        [SerializeField] private Button _button;

        protected abstract TValue Value { get; }

        private void Reset() =>
            _button = GetComponent<Button>();

        public Subject<ButtonContext<TValue>> Clicked =
            new Subject<ButtonContext<TValue>>();

        private IDisposable _disposable;

        private void Awake()
        {
            _disposable = _button.onClick
                .AsObservable()
                .TakeUntilDestroy(this)
                .Subscribe((_ =>
                {
                    var buttonContext = new ButtonContext<TValue>();
                    
                    buttonContext.Value = Value;

                    Clicked.OnNext(buttonContext);
                }));
        }
    }

    public struct ButtonContext<T1, T2>
    {
        public T1 Sender;
        public T2 Value;

        public ButtonContext(T1 sender, T2 value)
        {
            Sender = sender;
            Value = value;
        }
    }

    public struct ButtonContext< T1>
    {
        public T1 Value;

        public ButtonContext(T1 value)
        {
            Value = value;
        }
    }
    
}