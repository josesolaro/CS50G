using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float RespawnLenght;
    public float ParallaxEffect;

    void FixedUpdate()
    {
        var xPosition = (transform.position.x - ParallaxEffect * Time.deltaTime) % RespawnLenght;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
