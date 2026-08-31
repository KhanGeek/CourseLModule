using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Utilites.AssetsManagment;
using UnityEngine;

public class ResourcesConfigsLoader:IConfigsLoader
{
    private readonly ResourcesAssetsLoader _resources;

    private readonly Dictionary<Type, string> _configsResourcesPaths = new()
    {

    };

    public ResourcesConfigsLoader(ResourcesAssetsLoader resources)
    {
        _resources = resources;
    }

    public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
    {
        Dictionary<Type, object> loadedConfigs = new();

        foreach (KeyValuePair<Type, string> configsResourcesPath in _configsResourcesPaths)
        {
            ScriptableObject config =_resources.Load<ScriptableObject>(configsResourcesPath.Value);
            loadedConfigs.Add(configsResourcesPath.Key, config);
            yield return null;
        }
        
        onConfigsLoaded?.Invoke(loadedConfigs);
    }
}
