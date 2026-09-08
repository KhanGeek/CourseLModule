namespace _Project.Develop
{
    public class GameplayContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateUpdateServise);
        }

        public static UpdateServise CreateUpdateServise(DIContainer c) => new();
    }
}