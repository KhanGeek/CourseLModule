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
            
            GameplayContextRegistration.Process(container);
        }

        public override IEnumerator Initialize()
        {
            _updateServise = _container.Resolve<UpdateServise>();

            _gameCycle = new GameCycle(_gameplaySceneArgs.Chars, _container.Resolve<IInputService>());
            _updateServise.Add(_gameCycle);

            _gameCycle.StopGame += OnStopGame;
            _gameCycle.Prepare();
            
            yield return null;
        }

        private void OnDestroy()
        {
            _gameCycle.StopGame -= OnStopGame;
        }

        private void OnStopGame(bool isWin)
        {
            _container.Resolve<ICoroutinesPreformer>().StarPerform(WaitingInput(isWin));
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

        private IEnumerator WaitingInput(bool isWin)
        {
            IInputService inputService = _container.Resolve<IInputService>();
            ICoroutinesPreformer coroutinesPreformer = _container.Resolve<ICoroutinesPreformer>();
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();

            while (true)
            {
                if (inputService.TryGetStream(out string input))
                {
                    if (input == " ")
                    {
                        if (isWin)
                        {
                            coroutinesPreformer.StarPerform(
                                sceneSwitcherService.ProcessSwitchTo(
                                    Scenes.MainMenu));
                            
                            yield break;
                        }
                        else
                        {
                            coroutinesPreformer.StarPerform(
                                sceneSwitcherService.ProcessSwitchTo(
                                    Scenes.Gameplay,
                                    _gameplaySceneArgs));
                            
                            yield break;
                        }
                    }
                }
                yield return null;
            }
            
        }
    }
}