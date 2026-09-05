using System;
using System.Collections.Generic;

namespace _Project.Develop
{
    public class DIContainer
    {
        private Dictionary<Type, Registration> _container = new ();

        private List<Type> _reqests = new();

        private DIContainer _parent;

        public DIContainer() : this(null)
        {}
        
        public DIContainer(DIContainer parent) => _parent = parent;

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator)
        {
            if(IsAlreadyRegister<T>())
                throw new InvalidOperationException($"Cannot register type {typeof(T)} more than once");
            
            Registration registration = new Registration(container=>creator.Invoke(container));
            _container.Add(typeof(T), registration);
        }

        public bool IsAlreadyRegister<T>()
        {
            if(_container.ContainsKey(typeof(T)))
                return true;
            
            if(_parent!=null)
                return _parent.IsAlreadyRegister<T>();
            
            return false;
        }

        public T Resolve<T>()
        {
            if (_reqests.Contains(typeof(T)))
                throw new InvalidOperationException($"Циклическая зависимость {typeof(T)}");
            
            _reqests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                    return (T)registration.CreateInstanceFrom(this);
                
                if(_parent!=null)
                    return _parent.Resolve<T>();
            }
            finally
            {
                _reqests.Remove(typeof(T));
            }

            throw new InvalidOperationException($"Cannot resolve type {typeof(T)} ");
        }
    }
}