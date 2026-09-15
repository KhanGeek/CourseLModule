using System;
using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public class PlayerPrefsDataRepository : IDataRepository
    {
        public IEnumerator Read(string key, Action<string> onRead)
        {
            string text = PlayerPrefs.GetString(key);

            onRead?.Invoke(text);

            yield break;
        }

        public IEnumerator Write(string key, string serializedData)
        {
            PlayerPrefs.SetString(key, serializedData);

            yield break;
        }

        public IEnumerator Remove(string key)
        {
            PlayerPrefs.DeleteKey(key);

            yield break;
        }

        public IEnumerator Exists(string key, Action<bool> onExistResult)
        {
            bool exist = PlayerPrefs.HasKey(key);

            onExistResult?.Invoke(exist);

            yield break;
        }
    }
}