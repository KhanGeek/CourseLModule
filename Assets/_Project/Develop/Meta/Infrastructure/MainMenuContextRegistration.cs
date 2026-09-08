namespace _Project.Develop
{
    public class MainMenuContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateUpdateServise);
        }

        public static UpdateServise CreateUpdateServise(DIContainer c) => new();
    }
}