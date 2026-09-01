using System;

namespace _Project.Develop
{
    public class Registration
    {
        private Func<DIContainer, object> _creator;
        private object _cachedInstance;

        public Registration(Func<DIContainer, object> creator) => _creator = creator;

        public object CreateInstanceFrom(DIContainer container)
        {
            if(_cachedInstance!=null)
                return  _cachedInstance;

            if (_creator == null)
                throw new InvalidOperationException("Отсутствует делегат creator");

            _cachedInstance = _creator?.Invoke(container);
            
            return _cachedInstance;
        }
    }
}