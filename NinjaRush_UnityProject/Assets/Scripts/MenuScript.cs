using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Button Boutique;
    public Button Inventaire;
    public Button Objectifs;
    public Button Jouer;

    public GameManager gameManager;
    public UIScript UI;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LaunchGame()
    {
        gameManager.SetGameState(GameManager.GameState.INGAME);
        UI.SetInGameUI();
    }
}
