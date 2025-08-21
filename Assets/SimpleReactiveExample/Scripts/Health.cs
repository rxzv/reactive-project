using System;
using UnityEngine;

namespace Assets.SimpleReactiveExample.Scripts
{
    public class Health
    {
        private ReactiveVariable<float> _max;
        private ReactiveVariable<float> _current;

        public Health(float current, float max)
        {
            _current = new ReactiveVariable<float>(current);
            _max = new ReactiveVariable<float>(max);
        }

        public IReadOnlyVariable<float> Max => _max;
        public IReadOnlyVariable<float> Current => _current;

        public void Reduce(float value)
        {
            if (value < 0)
            {
                Debug.LogError(nameof(value));
                return;
            }

            _current.Value = Mathf.Clamp(Current.Value - value, 0, Max.Value);
        }

        public void Add(float value)
        {
            if (value < 0)
            {
                Debug.LogError(nameof(value));
                return;
            }

            _current.Value = Mathf.Clamp(Current.Value + value, 0, Max.Value);
        }
    }
}