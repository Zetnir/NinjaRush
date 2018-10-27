using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

    public GameManager gameManager;
    public UIScript uIScript;

    public Button Video;
    public Button Rejouer;
    public Button Menu;
    public Slider Temps;
    public Button Ressuciter;
    public Text Score;
    public Text NewHighScore;

    private string currentScene = "Scene_Ludo";
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ResetEndGame()
    {

    }
    public void ShowScore(int score,int dataScore)
    {
        Score.text = score.ToString() + "m";
        if (score > dataScore)
            ShowNewHighScore();
    }

    void ShowNewHighScore()
    {
        NewHighScore.gameObject.SetActive(true);
    }

    //A changer ne pas reload la scene
    public void GoToMenu()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void ReLaunchGame()
    {
        gameManager.spawnScript.DestroyAll();
        gameManager.spawnScript.ResetSpeed();
        gameManager.spawnScript.SetIsColliding(false);
        gameManager.endLineScript.SetIsColliding(false);

        gameManager.SetGameState(GameManager.GameState.INGAME);

        Time.timeScale = 1;
        uIScript.SetInGameUI();
    }
}
