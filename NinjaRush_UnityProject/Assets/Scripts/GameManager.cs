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
    public PlayerScript playerScript;
    public UIScript uIScript;

    private bool isLaunch = false;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        switch (gameState)
        {
            case GameState.MENU:
                spawnScript.gameObject.SetActive(false);
                isLaunch = false;
                playerScript.playerStates = PlayerScript.PlayerStates.TURN_TO_MENU;
                break;

            case GameState.INGAME:
                spawnScript.gameObject.SetActive(true);
                
                if(!isLaunch)
                {
                    playerScript.playerStates = PlayerScript.PlayerStates.RUN;
                    isLaunch = true;
                }

                PlayerGettingHit();

                if (playerScript.GetIsDead())
                {
                    SetGameState(GameManager.GameState.ENDGAME);
                    Time.timeScale = 0;
                    uIScript.SetEndGameUI();
                }

                if(Input.GetMouseButton(0) )//|| Input.GetTouch(0).tapCount == 1)
                {
                    playerScript.ClickOnScreen();
                }

                SynchUiPoints();
                break;

            case GameState.INPAUSE:
                spawnScript.gameObject.SetActive(false);
                break;

            case GameState.ENDGAME:
                playerScript.ResetHP();
                uIScript.InGame.ResetHP();
                spawnScript.gameObject.SetActive(false);
                playerScript.ResetScore();
                isLaunch = false;
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

   public void SynchUiPoints()
    {
        uIScript.InGame.SetScore(playerScript.GetScore());
    }

    public void PlayerGettingHit()
    {
        if(endLineScript.GetIsColliding() && endLineScript.GetNbEnemiesCol() == 1)
        {
            endLineScript.SetNbEnemiesCol(0);
            playerScript.LoseHP();
            uIScript.InGame.LoseHP();
        }
    }
   
}
