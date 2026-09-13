using System;
using UnityEngine;

namespace _Project.Develop
{
    public class GameModeSwitcher
    {
        private SceneSwitcherService _sceneSwitcherService;
        private ConfigsProviderService _configsProviderService;
        private ICoroutinesPreformer _coroutinesPerformer;

        public GameModeSwitcher(
            SceneSwitcherService sceneSwitcherService,
            ConfigsProviderService configsProviderService, 
            ICoroutinesPreformer coroutinesPerformer)
        {
            _sceneSwitcherService = sceneSwitcherService;
            _configsProviderService = configsProviderService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Run()
        {
            Debug.Log($"Выберете тип последовательности для повторения: {(int)GameMode.Digits} - числа, {(int)GameMode.Letters} - буквы!");
        }

        public void TransitionToGameplayScene(GameMode mode)
        {
            if (_configsProviderService.GetConfig<GamePlayConfig>().Sequences.TryGetValue(mode, out string sequence) ==
                false)
                throw new ArgumentException("В конфиге не задан данный режим игры");
            
            _coroutinesPerformer.StarPerform(
                _sceneSwitcherService.ProcessSwitchTo(
                    Scenes.Gameplay,
                    new GameplaySceneArgs(sequence)));
        }
    }
}