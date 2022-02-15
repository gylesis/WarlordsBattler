using System;
using UniRx;

namespace Warlords.Utils
{
    [Serializable]
    public class IntStat
    {
        public int Value = 1;

        public Subject<int> Changed = new Subject<int>();
        
        public void Add(int value)
        {
            Value += value;
            Changed.OnNext(Value);
        }

        public void Set(int value)
        {
            Value = value;
            Changed.OnNext(Value);
        }
        
    }
}