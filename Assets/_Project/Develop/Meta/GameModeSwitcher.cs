using System;
using UnityEngine;

namespace _Project.Develop
{
    public class GameModeSwitcher : IUpdatable
    {
        private IInputService _inputService;
        private SceneSwitcherService _sceneSwitcherService;
        private ConfigsProviderService _configsProviderService;
        private ICoroutinesPreformer _coroutinesPerformer;

        private bool _isRuning;

        public GameModeSwitcher(IInputService inputService,
            SceneSwitcherService sceneSwitcherService,
            ConfigsProviderService configsProviderService, 
            ICoroutinesPreformer coroutinesPerformer)
        {
            _inputService = inputService;
            _sceneSwitcherService = sceneSwitcherService;
            _configsProviderService = configsProviderService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Run()
        {
            Debug.Log("Выберете тип последовательности для повторения: 1 - числа, 2 - буквы!");
            _isRuning = true;
        }

        public void Update(float deltaTime)
        {
            if (_isRuning == false)
                return;

            if (_inputService.TryGetStream(out string input))
            {
                switch (input)
                {
                    case "1":
                        _coroutinesPerformer.StarPerform(
                            _sceneSwitcherService.ProcessSwitchTo(
                                Scenes.Gameplay,
                            new GameplaySceneArgs(_configsProviderService.GetConfig<GamePlayConfig>().DigitsChars)));
                        break;

                    case "2":
                        _coroutinesPerformer.StarPerform(
                            _sceneSwitcherService.ProcessSwitchTo(
                                Scenes.Gameplay,
                            new GameplaySceneArgs(_configsProviderService.GetConfig<GamePlayConfig>().LettersChars)));
                        break;

                    default:
                        Debug.Log("Некорректный ввод!");
                        break;
                }
            }
        }
    }
}