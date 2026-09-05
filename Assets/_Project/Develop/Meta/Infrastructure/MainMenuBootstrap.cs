using System.Collections;

namespace _Project.Develop
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            MainMenuContextRegistration.Process(container);
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