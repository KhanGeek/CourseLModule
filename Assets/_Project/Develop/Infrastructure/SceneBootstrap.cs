using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null);
        
        public abstract IEnumerator Initialize();

        public abstract void Run();
    }
}