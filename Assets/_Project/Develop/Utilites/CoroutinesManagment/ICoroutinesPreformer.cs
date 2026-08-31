using System.Collections;
using UnityEngine;

public interface ICoroutinesPreformer
{
    Coroutine StarPerform(IEnumerator coroutine);
    void StopPerform(IEnumerator coroutine);
}