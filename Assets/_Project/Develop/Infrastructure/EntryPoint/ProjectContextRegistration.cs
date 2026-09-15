using System;
using System.Collections.Generic;
using UnityEngine;
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
            container.RegisterAsSingle(CreateWalletService);
            container.RegisterAsSingle<ISaveLoadService>(CreateSaveLoadService);
        }

        private static SaveLoadService CreateSaveLoadService(DIContainer c)
        {
            IDataSerializer serializer = new JsonSerializer();
            IDataKeysStorage keysStorage = new MapDataKeysStorage();

            string saveFilePath = Application.persistentDataPath;
            IDataRepository repository = new LocalFileDataRepository(saveFilePath, "json");

            return new SaveLoadService(serializer, keysStorage, repository);
        }

        private static WalletService CreateWalletService(DIContainer c)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes))) 
                currencies[currencyType] = new ReactiveVariable<int>();
            
            return new WalletService(currencies);
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
        
        private static StandardLoadingScreen CreateStandartLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            StandardLoadingScreen standardLoadingScreen =
                resourcesAssetsLoader.Load<StandardLoadingScreen>("Utilites/LoadScreen");
            
            return Object.Instantiate(standardLoadingScreen);
        }
    }
}