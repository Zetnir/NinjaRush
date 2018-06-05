using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour {

    public GameManager gameManager;
    public UIScript uIScript;

    private string currentScene = "Scene_Ludo";
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

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
