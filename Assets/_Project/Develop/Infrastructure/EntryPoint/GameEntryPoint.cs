using System;
using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetupAppSetings();

            DIContainer projectContainer = new DIContainer();
            ProjectContextRegistration.Process(projectContainer);
            
            projectContainer.Resolve<ICoroutinesPreformer>().StarPerform(Initialize(projectContainer));
        }

        private void SetupAppSetings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            
            loadingScreen.Show();
            
            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            yield return new WaitForSeconds(1f);
            
            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}