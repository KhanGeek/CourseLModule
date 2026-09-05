using System;
using Object = UnityEngine.Object;

namespace _Project.Develop
{
    public class ProjectContextRegistration
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle<ICoroutinesPreformer>(CreateCoroutinesPreformer);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle<ILoadingScreen>(CreateStandartLoadingScreen);
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
            => new SceneSwitcherService(
                c.Resolve<SceneLoaderService>(),
                c.Resolve<ILoadingScreen>(),
                c);

        private static SceneLoaderService CreateSceneLoaderService(DIContainer c) 
            => new SceneLoaderService();

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer c) 
            => new ResourcesAssetsLoader();

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesConfigsLoader resourcesConfigsLoader=
                new ResourcesConfigsLoader(c.Resolve<ResourcesAssetsLoader>());
            
            return new ConfigsProviderService(resourcesConfigsLoader);
        }

        private static CoroutinesPerformer CreateCoroutinesPreformer(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            CoroutinesPerformer coroutinesPerformer =
                resourcesAssetsLoader.Load<CoroutinesPerformer>("Utilites/CoroutinesPerformer");
            
            return Object.Instantiate(coroutinesPerformer);
        }
        
        private static StandartLoadingScreen CreateStandartLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            StandartLoadingScreen standartLoadingScreen =
                resourcesAssetsLoader.Load<StandartLoadingScreen>("Utilites/LoadScreen");
            
            return Object.Instantiate(standartLoadingScreen);
        }
    }
}