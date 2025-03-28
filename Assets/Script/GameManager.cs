using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    Running, 
    Pause, 
    End
}

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager _instance;
    public Text scoreText;
    public GameState gameState;
    public int highestScore;

    void Awake() {
        _instance = this;
        gameState = GameState.Running;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.Text = "Score: " + score;
        if (gameState == GameState.End) {
            GameOver.
        }
    }
}
