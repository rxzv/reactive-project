using UnityEngine;

namespace Assets.SimpleReactiveExample.Scripts
{
    public class HealthExample : MonoBehaviour
    {
        [SerializeField] private SliderView _healthView;
        private Health _health;

        private void Awake()
        {
            _health = new Health(100, 100);

            _healthView.Initialize(_health.Current, _health.Max);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _health.Reduce(10);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _health.Add(10);
        }
    }
}