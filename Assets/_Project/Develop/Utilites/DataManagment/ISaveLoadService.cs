using System;
using System.Collections;

namespace _Project.Develop
{
    public interface ISaveLoadService
    {
        IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData;
        IEnumerator Save<TData>(TData data) where TData : ISaveData;
        IEnumerator Remove<TData>() where TData : ISaveData;
        IEnumerator Exist<TData>(Action<bool> onExistResult) where TData : ISaveData;
    }
}