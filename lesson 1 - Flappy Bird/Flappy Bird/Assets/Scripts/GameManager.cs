using UnityEngine;

public class GameManager : StateMachine
{
    public GameObject OriginalPipe;
    public float SpawnTime;
    public float LastSpawnTime { get; set; } = 0;
    private void Start()
    {
        ChangeState(new StopState());
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (currentGameMastertState is GameManagerPlayState)
            {
                ChangeState(new GameManagerStopState());
            }
            else
            {
                ChangeState(new GameManagerPlayState());
            }
        }
        currentGameMastertState.OnTick(this);
    }
}