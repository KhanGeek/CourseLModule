using System.Collections;

namespace _Project.Develop
{
    public class GameplayBootstrap:SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            GameplayContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            
            yield break;
        }

        public override void Run()
        {
            
        }
    }
}