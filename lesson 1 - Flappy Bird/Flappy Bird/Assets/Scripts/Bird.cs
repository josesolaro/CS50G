using UnityEngine;

public class Bird : StateMachine
{
    public KeyCode JumpKey;
    public float AntiGravity;
    public AudioClip JumpSound { get; set; }
    public AudioClip HurtSound { get; set; }
    private void Start()
    {
        JumpSound = Resources.Load("jump") as AudioClip;
        HurtSound = Resources.Load("hurt") as AudioClip;
    }
    // Update is called once per frame
    void Update()
    {
        currentBirdState.OnTick(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(HurtSound);
        ChangeState(new GameManagerStopState());
    }
}
