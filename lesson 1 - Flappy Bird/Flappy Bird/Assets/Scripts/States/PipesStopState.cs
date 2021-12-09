using System;
using UnityEngine;

public class PipesStopState : StopState, IState
{
    public void OnEnter(MonoBehaviour context)
    {
        GameObject.Destroy(context.gameObject, 0f);
    }

    public void OnExit()
    {
    }

    public void OnTick(MonoBehaviour context)
    {
    }
}
