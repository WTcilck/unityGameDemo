using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        scoreText.text = "Score: " + score;
        if (gameState == GameState.End) {
            GameOver._instance.Show(score);
        }
    }

    // 更改游戏状态
    public void ChangeState() {
        if (_instance.gameState == GameState.Running) {
            Pause();
        } else if (_instance.gameState == GameState.Pause) {
            Continue();
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        _instance.gameState = GameState.Pause;
    }

    public void Continue() {
        Time.timeScale = 1;
        _instance.gameState = GameState.Running;
    }

    public void Restart() {
        Debug.Log("Restart");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit() {
        Application.Quit();
    }
}
