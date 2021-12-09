using System;
using UnityEngine;

public class BirdPlayState : PlayState, IState
{
    public void OnEnter(MonoBehaviour context)
    {
    }

    public void OnExit()
    {
    }

    public void OnTick(MonoBehaviour context)
    {
        var bird = (Bird)context;
        if (Input.GetKey((bird).JumpKey))
        {
            bird.gameObject.GetComponent<Rigidbody2D>().gravityScale = bird.AntiGravity;
            if (Input.GetKeyDown(bird.JumpKey))
            {
                bird.GetComponent<AudioSource>().PlayOneShot(bird.JumpSound);
            }
        }
        else
        {
            bird.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }
}
