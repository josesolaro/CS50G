using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static int MAXY = 60;
    public static int MINY = -60;
    public static int PaddleSpeed = 200;
    private static int LEFT = -125;
    private static int RIGHT = 125;
    private int player1Score = 0;
    private int player2Score = 0;
    public static GameState State { get; set; }
    private GameObject ball;
    private Text Player1Score;
    private Text Player2Score;
    private Text Title;
    // Start is called before the first frame update
    void Start()
    {
        State = GameState.start;

        ball = GameObject.FindGameObjectWithTag("Ball");
        Player1Score = GameObject.Find("Player1Score").GetComponent<Text>();
        Player2Score = GameObject.Find("Player2Score").GetComponent<Text>();
        Title = GameObject.Find("Title").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        Player1Score.text = player1Score.ToString();
        Player2Score.text = player2Score.ToString();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (State)
            {
                case GameState.start:
                    Title.text = "Hello! Serve";
                    State = GameState.serve;
                    break;
                case GameState.serve:
                    Title.text = "Hello! Play";
                    State = GameState.play;
                    break;
            }
        }

        if (State == GameState.play)
        {
            var score = false;
            if (ball.transform.position.x <= LEFT)
            {
                player2Score++;
                score = true;
            }
            else if (ball.transform.position.x >= RIGHT)
            {
                player1Score++;
                score = true;
            }

            if (score)
            {
                GetComponent<AudioSource>().Play();
                if (player1Score == 5 || player2Score == 5)
                {
                    State = GameState.done;
                    var winner = player1Score == 5 ? "1" : "2";
                    Title.text = $"Player {winner} win!";
                }
                else
                {
                    State = GameState.serve;
                    Title.text = "Hello! Serve";
                }
            }
        }

    }


    public enum GameState
    {
        start = 0,
        play,
        serve,
        done
    }
}
