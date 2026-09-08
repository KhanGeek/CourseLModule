using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private UpdateServise _updateServise;
        
        private GameModeSwitcher _gameModeSwitcher;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            MainMenuContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            _updateServise = _container.Resolve<UpdateServise>();
            
            _gameModeSwitcher = new GameModeSwitcher(
                _container.Resolve<IInputService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ConfigsProviderService>(),
                _container.Resolve<ICoroutinesPreformer>());
            
            _updateServise.Add(_gameModeSwitcher);

            yield return null;
        }

        public override void Run()
        {
            _gameModeSwitcher.Run();
        }
        
        private void Update()
        {
            if (_updateServise != null)
                _updateServise.Update(Time.deltaTime);
        }
    }
}