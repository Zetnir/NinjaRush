using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState
    {
        MENU,
        INGAME,
        INPAUSE,
        ENDGAME
    }

    public GameState gameState;

    public SpawnScript spawnScript;
    public EndLineScript endLineScript;

    public UIScript uIScript;

    LayerMask enemyLayer;
    // Use this for initialization
    void Start() {
        enemyLayer = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update() {
        switch (gameState)
        {
            case GameState.MENU:
                break;
            case GameState.INGAME:

                if (!spawnScript.GetIsColliding())
                {
                    spawnScript.SpawnEnemy();
                }

                if (endLineScript.GetIsColliding())
                {
                    SetGameState(GameManager.GameState.ENDGAME);
                    PutInPause();
                    uIScript.SetEndGameUI();
                }

                if(Input.GetMouseButtonDown(0))
                {
                    ClickOnScreen();
                }
                break;
            case GameState.INPAUSE:
                break;
            case GameState.ENDGAME:
                break;
        }
    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void PutInPause()
    {
        Time.timeScale = 0;
    }

    public void ClickOnScreen()
    {
        RaycastHit hit;
        Ray ray = /*Camera.main.ScreenPointToRay(Input.GetTouch(0).position)*/Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f,enemyLayer.value))
        {
            if(hit.transform)
            {
                spawnScript.DestroyEnemy(hit.transform.gameObject);
                Debug.DrawLine(hit.transform.position, Input.mousePosition);
            }
        }
    }

   
}
