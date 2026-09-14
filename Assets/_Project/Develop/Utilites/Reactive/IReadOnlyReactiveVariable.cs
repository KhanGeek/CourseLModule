using System;

namespace _Project.Develop
{
    public interface IReadOnlyReactiveVariable<T>
    {
        T Value { get; }
        IDisposable Subscribe(Action<T, T> action);
    }
}