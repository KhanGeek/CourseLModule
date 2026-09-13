using System;
using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public class GameplayBootstrap:SceneBootstrap
    {
        private DIContainer _container;
        private GameplaySceneArgs _gameplaySceneArgs;
        private UpdateServise _updateServise;

        private GameCycle _gameCycle;

        public override void ProcessRegistration(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplaySceneArgs gameplaySceneArgs)
                throw new ArgumentException("Это не GameplaySceneArgs");

            _gameplaySceneArgs = gameplaySceneArgs;

            GameplayContextRegistration.Process(container, _gameplaySceneArgs);
        }

        public override IEnumerator Initialize()
        {
            _updateServise = _container.Resolve<UpdateServise>();

            _gameCycle = _container.Resolve<GameCycle>();

            _gameCycle.Prepare();
            
            yield return null;
        }

        public override void Run()
        {
            _gameCycle.Start();
        }

        private void Update()
        {
            if (_updateServise != null)
                _updateServise.Update(Time.deltaTime);
        }
    }
}