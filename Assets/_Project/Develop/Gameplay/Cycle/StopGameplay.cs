using System.Collections;


namespace _Project.Develop
{
    public class StopGameplay
    {
        private IInputService _inputService;
        private ICoroutinesPreformer _coroutinesPreformer;
        private SceneSwitcherService _sceneSwitcherService;
        private GameplaySceneArgs _gameplaySceneArgs;

        public StopGameplay(
            IInputService inputService, 
            ICoroutinesPreformer coroutinesPreformer, 
            SceneSwitcherService sceneSwitcherService, 
            GameplaySceneArgs gameplaySceneArgs)
        {
            _inputService = inputService;
            _coroutinesPreformer = coroutinesPreformer;
            _sceneSwitcherService = sceneSwitcherService;
            _gameplaySceneArgs = gameplaySceneArgs;
        }

        public void Start(bool isWin) => _coroutinesPreformer.StarPerform(WaitingInput(isWin));

        private IEnumerator WaitingInput(bool isWin)
        {
            while (true)
            {
                if (_inputService.Confirm())
                {
                    if (isWin)
                    {
                        _coroutinesPreformer.StarPerform(
                            _sceneSwitcherService.ProcessSwitchTo(
                                Scenes.MainMenu));

                        yield break;
                    }
                    else
                    {
                        _coroutinesPreformer.StarPerform(
                            _sceneSwitcherService.ProcessSwitchTo(
                                Scenes.Gameplay,
                                _gameplaySceneArgs));

                        yield break;
                    }
                }

                yield return null;
            }
            
        }
    }
}