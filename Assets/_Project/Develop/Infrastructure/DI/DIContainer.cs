using System;
using System.Collections.Generic;

namespace _Project.Develop
{
    public class DIContainer
    {
        private Dictionary<Type, object> _container = new ();

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator) where T : object
        {
            Registration registration = new Registration(container);
        }
    }
}