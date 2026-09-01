using System.Collections;
using UnityEngine;

namespace _Project.Develop
{
    public interface ICoroutinesPreformer
    {
        Coroutine StarPerform(IEnumerator coroutine);
        void StopPerform(IEnumerator coroutine);
    }
}