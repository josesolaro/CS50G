using UnityEngine;


public class StateMachine : MonoBehaviour
{
    public static IState currentGameMastertState;
    public static IState currentBirdState;
    public static IState currentPipestState;
    public void ChangeState(State newState)
    {
        if (currentGameMastertState != null)
        {
            currentGameMastertState.OnExit();
        }
        if (currentBirdState != null)
        {
            currentBirdState.OnExit();
        }
        if (currentPipestState != null)
        {
            currentPipestState.OnExit();
        }
        if (newState is PlayState)
        {
            currentGameMastertState = new GameManagerPlayState();
            currentBirdState = new BirdPlayState();
            currentPipestState = new PipesPlayState();
        }
        if (newState is StopState)
        {
            currentGameMastertState = new GameManagerStopState();
            currentBirdState = new BirdStopState();
            currentPipestState = new PipesStopState();
        }
        currentGameMastertState.OnEnter(null);
        currentBirdState.OnEnter(GameObject.Find("Bird").GetComponent<Bird>());
        foreach (var context in GameObject.FindGameObjectsWithTag("Pipes"))
        {
            currentPipestState.OnEnter(context.GetComponent<Pipes>());
        }
    }

}
