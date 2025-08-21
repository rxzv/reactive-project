using System;

namespace Assets.SimpleReactiveExample.Scripts
{
    public interface IReadOnlyVariable<T>
    {
        event Action<T, T> Changed;

        T Value { get; }
    }
}