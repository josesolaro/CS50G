using UnityEngine;

public class Pipes : StateMachine
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, Random.Range(-4.6f, 0.14f), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        currentPipestState.OnTick(this);
    }
}
