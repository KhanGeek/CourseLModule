namespace _Project.Develop
{
    public class MainMenuContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateUpdateServise);
            container.RegisterAsSingle(CreateGameModeSwitcher);
            container.RegisterAsSingle(CreateGameModeSwitchChecker);
        }

        public static UpdateServise CreateUpdateServise(DIContainer c) => new();

        public static GameModeSwitcher CreateGameModeSwitcher(DIContainer c)
        {
            GameModeSwitcher gameModeSwitcher = new GameModeSwitcher(
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<ICoroutinesPreformer>());
            
            return gameModeSwitcher;
        }

        public static GameModeSwitchChecker CreateGameModeSwitchChecker(DIContainer c)
        {
            GameModeSwitchChecker gameModeSwitchChecker = new GameModeSwitchChecker(
                c.Resolve<IInputService>(),
                c.Resolve<GameModeSwitcher>());
            
            c.Resolve<UpdateServise>().Add(gameModeSwitchChecker);
            
            return gameModeSwitchChecker;
        }
    }
}