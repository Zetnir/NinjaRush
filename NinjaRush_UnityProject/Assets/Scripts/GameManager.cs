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

    private GameState gameState;

    public SpawnScript spawnScript;
    public EndLineScript endLineScript;
    public PlayerScript playerScript;
    public UIScript uIScript;
    public CameraScript cameraScript;

    private bool gameLaunched = false;
    // Use this for initialization
    void Start() {
    }

    //Set the action for each state
    void ActionState(GameState state)
    {
        switch (state)
        {
            case GameState.MENU:
                spawnScript.gameObject.SetActive(false);
                gameLaunched = false;
                playerScript.playerStates = PlayerScript.PlayerStates.TURN_TO_MENU;
                cameraScript.SetMenuView();
                uIScript.SetMenuUI();
                break;

            case GameState.INGAME:
                spawnScript.gameObject.SetActive(true);

                //Put the player in the running state
                if (!gameLaunched)
                {
                    playerScript.playerStates = PlayerScript.PlayerStates.RUN;
                    playerScript.ResetScore();
                    gameLaunched = true;
                }

                //Set the camera for the inGameView
                cameraScript.SetInGameView();

                //Check if the player is getting hit during the game
                PlayerGettingHit();

                //Switch for the EndGame display when the player died
                if (playerScript.GetIsDead())
                {
                    SetGameState(GameManager.GameState.ENDGAME);
                    Time.timeScale = 0;
                }


                if (Input.GetMouseButton(0) /*|| Input.GetTouch(0).tapCount == 1*/)
                {
                    playerScript.ClickOnScreen();
                }

                SynchUiPoints();
                break;

            case GameState.INPAUSE:
                spawnScript.gameObject.SetActive(false);
                break;

            case GameState.ENDGAME:
                uIScript.SetEndGameUI();
                //Essaie d'Afficher newHighScore mais il faut reset le text quand ce n'est pas new highscore
                if(gameLaunched)
                    uIScript.EndGame.ShowScore(playerScript.GetScore(),playerScript.data.GetMaxScore());
                playerScript.ResetHP();
                uIScript.InGame.ResetHP();
                spawnScript.gameObject.SetActive(false);
                gameLaunched = false;
                //DefineMaxScore after gameLauched false to not change the showed score
                playerScript.data.DefineMaxScore(playerScript.GetScore());
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        ActionState(gameState);
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
