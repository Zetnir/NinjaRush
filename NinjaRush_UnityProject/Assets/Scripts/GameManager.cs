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

    public List<GameObject> EnemiesPrefab;
    public List<GameObject> Enemies;

    public Vector3[] enemiesPos = new Vector3[4];

    private int nbEnemy = 0;

    private int previousRandPos = -1;

    // Use this for initialization
    void Start () {
        for(uint i =0; i < enemiesPos.Length; i++)
        {
            enemiesPos[i] = new Vector3(i - 1f, -3.42f, 13.75f);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SetGameState(GameState newState)
    {
        gameState = newState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void SpawnEnemy()
    {
        int newRandPos;
        do
        {
            newRandPos = (int)Random.Range(0, 4);
        } while (newRandPos == previousRandPos);
        int newRandEnemy = (int)Random.Range(0, EnemiesPrefab.Count);

        Enemies.Add(Instantiate(EnemiesPrefab[newRandEnemy], enemiesPos[newRandPos], Quaternion.Euler(new Vector3(0, 0, 0))));
        previousRandPos = newRandPos;
    }

}
