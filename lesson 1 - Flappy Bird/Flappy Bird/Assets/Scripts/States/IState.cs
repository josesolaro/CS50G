using UnityEngine;

public interface IState
{
    void OnEnter(MonoBehaviour context);
    void OnExit();
    void OnTick(MonoBehaviour context);
}
