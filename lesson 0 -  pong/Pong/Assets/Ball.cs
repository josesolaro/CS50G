using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float ballDX;
    private float ballDY;
    private AudioClip wallHitSound;
    private AudioClip paddleHitSound;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        wallHitSound = Resources.Load("wall_hit") as AudioClip;
        paddleHitSound = Resources.Load("paddle_hit") as AudioClip;
        Reset();
    }
    public void Reset()
    {
        ballDX = (Random.Range(0, 3) % 2) == 1 ? 100 : -100;
        ballDY = Random.Range(-50, 50);
        transform.position = new Vector3(0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        switch (GameMaster.State)
        {
            case GameMaster.GameState.serve:
            case GameMaster.GameState.done:
                if (transform.position.magnitude != 0)
                {
                    Reset();
                }
                break;
            case GameMaster.GameState.play:
                var dy = transform.position.y + ballDY * Time.deltaTime;
                if (dy > GameMaster.MAXY + 4 || dy < GameMaster.MINY - 4)
                {
                    audio.PlayOneShot(wallHitSound, 1);
                    ballDY = -ballDY;
                }
                transform.position = new Vector3(transform.position.x + ballDX * Time.deltaTime, dy);
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(paddleHitSound, 1);
        ballDX = -ballDX;
        ballDY *= 1.2f;
    }
}
