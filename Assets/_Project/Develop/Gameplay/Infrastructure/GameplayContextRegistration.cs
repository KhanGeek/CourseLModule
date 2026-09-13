namespace _Project.Develop
{
    public class GameplayContextRegistration
    {
        private static GameplaySceneArgs _gameplaySceneArgs;
        
        public static void Process(DIContainer container, GameplaySceneArgs gameplaySceneArgs)
        {
            _gameplaySceneArgs = gameplaySceneArgs;
            
            container.RegisterAsSingle(CreateUpdateServise);
            container.RegisterAsSingle(CreateGameCycle);
            container.RegisterAsSingle(CreateStopGameplay);
        }

        private static UpdateServise CreateUpdateServise(DIContainer c) => new();

        private static GameCycle CreateGameCycle(DIContainer c)
        {
            GameCycle gameCycle = new GameCycle(
                _gameplaySceneArgs.Sequence, 
                c.Resolve<IInputService>(),
                c.Resolve<StopGameplay>());
            
            c.Resolve<UpdateServise>().Add(gameCycle);
            
            return gameCycle;
        }
        
        private static StopGameplay CreateStopGameplay(DIContainer c)
        {
            StopGameplay stopGameplay = new StopGameplay(
                c.Resolve<IInputService>(),
                c.Resolve<ICoroutinesPreformer>(),
                c.Resolve<SceneSwitcherService>(),
                _gameplaySceneArgs);
            
            return stopGameplay;
        }
    }
}