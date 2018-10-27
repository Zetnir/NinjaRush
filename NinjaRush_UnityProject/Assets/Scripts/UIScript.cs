using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public MenuScript Menu;
    public EndGameScript EndGame;
    public InGameScript InGame;
    public PlayerInfoScript PlayerInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInGameUI()
    {
        Menu.gameObject.SetActive(false);
        PlayerInfo.gameObject.SetActive(false);
        InGame.gameObject.SetActive(true);
        EndGame.gameObject.SetActive(false);
    }

    public void SetEndGameUI()
    {
        Menu.gameObject.SetActive(false);
        PlayerInfo.gameObject.SetActive(true);
        InGame.gameObject.SetActive(false);
        EndGame.gameObject.SetActive(true);

    }

    public void SetMenuUI()
    {
        Menu.gameObject.SetActive(true);
        PlayerInfo.gameObject.SetActive(true);
        InGame.gameObject.SetActive(false);
        EndGame.gameObject.SetActive(false);

    }

}
