using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    private bool isColliding;

    public List<GameObject> EnemiesPrefab;
    public List<GameObject> Enemies;

    private Vector3[] enemiesPos = new Vector3[4];
    private Vector3[] enemiesLongPos = new Vector3[4];

    private int previousRandPos = -1;

    // Use this for initialization
    void Start () {
        for (uint i = 0; i < enemiesPos.Length; i++)
        {
            enemiesPos[i] = new Vector3(i - 1f, -3.42f, 13.75f);
            enemiesLongPos[i] = new Vector3(i - 1f, -3.42f, 11.75f);

        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public bool GetIsColliding()
    {
        return isColliding;
    }

    public void SpawnEnemy()
    {
        int newRandPos;
        do
        {
            newRandPos = (int)Random.Range(0, 4);
        } while (newRandPos == previousRandPos);
        int newRandEnemy = (int)Random.Range(0, EnemiesPrefab.Count);

        if(newRandEnemy == 3)
        {
            Enemies.Add(Instantiate(EnemiesPrefab[newRandEnemy], enemiesLongPos[newRandPos], Quaternion.Euler(new Vector3(0, 0, 0))));
        }
        else
        {
            Enemies.Add(Instantiate(EnemiesPrefab[newRandEnemy], enemiesPos[newRandPos], Quaternion.Euler(new Vector3(0, 0, 0))));
        }
        previousRandPos = newRandPos;
    }

    public void DestroyAll()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            Destroy(Enemies[i]);
        }
        Enemies.Clear();

    }

    public void SetIsColliding(bool val)
    {
        isColliding = val;
    }
    void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    void OnTriggerStay(Collider other)
    {
        isColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

    public void DestroyEnemy(GameObject enemy)
    {
        for(int i =0; i < Enemies.Count; i++)
        {
            enemy.GetComponent<EnemyScript>().OnFight();
            Enemies.Remove(enemy);
        }
    }
}
