using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public class CoroutinesPerformer : MonoBehaviour, ICoroutinesPreformer
    {
        private void Awake() => DontDestroyOnLoad(this);

        public Coroutine StarPerform(IEnumerator coroutine)
            => StartCoroutine(coroutine);

        public void StopPerform(IEnumerator coroutine)
            => StopCoroutine(coroutine);
    }
}