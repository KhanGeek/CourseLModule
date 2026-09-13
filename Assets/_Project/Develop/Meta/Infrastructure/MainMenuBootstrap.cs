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
            
            _gameModeSwitcher = _container.Resolve<GameModeSwitcher>();

            yield return null;
        }

        public override void Run()
        {
            _gameModeSwitcher.Run();

            _container.Resolve<GameModeSwitchChecker>();
        }
        
        private void Update()
        {
            if (_updateServise != null)
                _updateServise.Update(Time.deltaTime);
        }
    }
}