using System;
using System.Collections.Generic;

namespace reactiveProperty
{
    public class ReactiveProperty<T>
    {
        public event Action<T,T> OnChanged;
        private T _value;
        private EqualityComparer<T> equalityComparer;
        public T Value
        {
            get { return _value; }
            set
            {
                var old = _value;
                _value = value;
                if(!equalityComparer.Equals(old, _value))
                    OnChanged?.Invoke(old, value);
            }
        }

        public ReactiveProperty() : this((T)default,EqualityComparer<T>.Default)
        {

        }

        public ReactiveProperty(T value) : this(value,EqualityComparer<T>.Default)
        {

        }

        public ReactiveProperty(T value, EqualityComparer<T> equalityComparer)
        {
            _value = value;
            this.equalityComparer = equalityComparer;
        }
    }
}

