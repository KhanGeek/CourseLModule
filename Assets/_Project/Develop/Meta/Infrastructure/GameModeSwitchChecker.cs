using System;

namespace _Project.Develop
{
    public class GameModeSwitchChecker:IUpdatable
    {
        private IInputService _inputService;
        private GameModeSwitcher _gameModeSwitcher;
        
        public GameModeSwitchChecker(IInputService inputService, GameModeSwitcher gameModeSwitcher)
        {
            _inputService = inputService;
            _gameModeSwitcher = gameModeSwitcher;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.TryGetSelectedGameMode(out GameMode gameMode))
            {
                switch (gameMode)
                {
                    case GameMode.Digits:
                        _gameModeSwitcher.TransitionToGameplayScene(GameMode.Digits);
                        break;

                    case GameMode.Letters:
                        _gameModeSwitcher.TransitionToGameplayScene(GameMode.Letters);
                        break;

                    default:
                        throw new ArgumentException("В перечислении отсутствует выбранный режим");
                }
            }
        }
    }
}