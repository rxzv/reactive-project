using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleReactiveExample.Scripts
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IReadOnlyVariable<float> _current;
        private IReadOnlyVariable<float> _max;

        public void Initialize(IReadOnlyVariable<float> current, IReadOnlyVariable<float> max)
        {
            _current = current;
            _max = max;

            _current.Changed += OnCurrentChanged;

            UpdateValue(_current.Value, _max.Value);
        }


        private void OnDestroy()
        {
            _current.Changed -= OnCurrentChanged;
        }

        private void OnCurrentChanged(float arg1, float newValue) => UpdateValue(newValue, _max.Value);

        private void UpdateValue(float currentValue, float maxValue) => _slider.value = currentValue / maxValue;
    }
}