using System;
using UniRx;
using UnityEngine;

namespace Warlords.Utils
{
    [Serializable]
    public class IntStat
    {
        [SerializeField] private int _value;

        public int Value // replace with IntReactiveProperty
        {
            get => _value;
            
            set
            {
                if(value == _value) return;

                _value = value;
                Changed.OnNext(_value);
            }
        }

        public Subject<int> Changed { get; } = new Subject<int>();
    }
}