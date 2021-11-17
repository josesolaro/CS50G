using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int InitialYPosition;
    public KeyCode UpKey;
    public KeyCode DownKey;
    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, InitialYPosition);
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(UpKey))
        {
            var y = Mathf.Min(transform.position.y + GameMaster.PaddleSpeed * Time.deltaTime, GameMaster.MAXY);
            transform.position = new Vector3(transform.position.x, y);
        }
        else if (Input.GetKey(DownKey))
        {
            var y = Mathf.Max(transform.position.y - GameMaster.PaddleSpeed * Time.deltaTime, GameMaster.MINY);
            transform.position = new Vector3(transform.position.x, y);
        }
    }
}
