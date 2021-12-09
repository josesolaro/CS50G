using System;
using UnityEngine;

public class GameManagerPlayState : PlayState, IState
{
    public void OnEnter(MonoBehaviour context)
    {
    }

    public void OnExit()
    {
    }

    public void OnTick(MonoBehaviour context)
    {
        var gm = (GameManager)context;
        if ((Time.realtimeSinceStartup - gm.LastSpawnTime) > gm.SpawnTime)
        {
            gm.LastSpawnTime = Time.realtimeSinceStartup;
            GameObject.Instantiate(gm.OriginalPipe);
        }
    }

}
