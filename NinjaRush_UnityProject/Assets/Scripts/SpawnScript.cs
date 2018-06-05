using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public bool isColliding;

    public List<GameObject> EnemiesPrefab;
    public List<GameObject> Enemies;

    private Vector3[] basicEnemPos = new Vector3[4];
    private Vector3[] armorEnemyPos = new Vector3[4];

    private int previousRandPos_ = -1;
    private float speed_ = 5f;
    public int nbEnemies_ = 0;
    public float speedMultiplier_ = 1;

    public int nbEnemiesSpawn_ = 0;

    // Use this for initialization
    void Start() {
        for (uint i = 0; i < basicEnemPos.Length; i++)
        {
            basicEnemPos[i] = new Vector3(i - 1f, -3.42f, 13.75f);
            armorEnemyPos[i] = new Vector3(i - 1f, -3.42f, 11.75f);

        }
    }

    // Update is called once per frame
    void Update() {
        if (!GetIsColliding() && nbEnemiesSpawn_ < 1)
        {
            SpawnEnemy();
        }
        DestroyDeadEnemies();
    }

    public bool GetIsColliding()
    {
        return isColliding;
    }
    public void SetIsColliding(bool val)
    {
        isColliding = val;
    }
    void OnTriggerEnter(Collider other)
    {
        SetIsColliding(true);
    }

    void OnTriggerStay(Collider other)
    {
        SetIsColliding(true);
    }

    void OnTriggerExit(Collider other)
    {
        SetIsColliding(false);
        SetNbEnemiesSpawn(0);
    }

    public void DestroyDeadEnemies()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].GetComponent<EnemyScript>().GetIsDead())
            {
                Destroy(Enemies[i]);
                Enemies.Remove(Enemies[i]);
            }
        }
    }

    public void SpawnEnemy()
    {
        int newRandPos;
        do
        {
            newRandPos = (int)Random.Range(0, 4);
        } while (newRandPos == previousRandPos_);
        int newRandEnemy = (int)Random.Range(0, EnemiesPrefab.Count);

        Enemies.Add(Instantiate(EnemiesPrefab[newRandEnemy], armorEnemyPos[newRandPos], Quaternion.Euler(new Vector3(0, 0, 0))));

        if (Enemies[Enemies.Count - 1].GetComponent<ArmorEnemyScript>())
        {
            Enemies[Enemies.Count - 1].transform.position = armorEnemyPos[newRandPos];
        }
        else
        {
            Enemies[Enemies.Count - 1].transform.position = basicEnemPos[newRandPos];
        }
        Enemies[Enemies.Count - 1].GetComponent<EnemyScript>().SetActualSpeed(speed_ * speedMultiplier_);
        SpeedAugmentation();
        previousRandPos_ = newRandPos;
        nbEnemiesSpawn_++;
    }

    public void DestroyAll()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            Destroy(Enemies[i]);
        }
        Enemies.Clear();
        SetNbEnemiesSpawn(0);

    }

    public void SpeedAugmentation()
    {
        if(nbEnemies_==10)
        {
            speedMultiplier_ += 0.1f;
            nbEnemies_ = 0;
        }
        nbEnemies_++;
    }

    public void SetNbEnemiesSpawn(int val)
    {
        nbEnemiesSpawn_ = val;
    }

    public int GetNbEnemiesSpawn()
    {
        return nbEnemiesSpawn_;
    }
    public void ResetSpeed()
    {
        speedMultiplier_ = 1f;
    }

}
