using UnityEngine;

namespace _Project.Develop
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcesPath) where T : Object 
            => Resources.Load<T>(resourcesPath);
    }
}
