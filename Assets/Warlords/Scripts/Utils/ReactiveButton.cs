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

        public Subject<ReactiveButtonSender<TSender, TValue>> Clicked =
            new Subject<ReactiveButtonSender<TSender, TValue>>();

        private void Awake()
        {
            var reactiveButtonSender = new ReactiveButtonSender<TSender, TValue>(Sender, Value);

            _button.onClick
                .AsObservable()
                .TakeUntilDestroy(this)
                .Subscribe((_ => Clicked.OnNext(reactiveButtonSender)));
        }
    }

    public class ReactiveButtonSender<T1, T2>
    {
        public T1 Sender;
        public T2 Value;

        public ReactiveButtonSender(T1 sender, T2 value)
        {
            Sender = sender;
            Value = value;
        }
    }
}