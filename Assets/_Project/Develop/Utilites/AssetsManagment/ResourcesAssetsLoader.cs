using UnityEngine;

namespace _Project.Develop.Utilites.AssetsManagment
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcesPath) where T : Object 
            => Resources.Load<T>(resourcesPath);
    }
}
