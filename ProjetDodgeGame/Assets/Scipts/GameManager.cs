using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> objectSpawned;
    public Transform spawnTransform;

    const float WALL_DISTANCE = 3.8f;
    const float JUMPER_DISTANCE = 6;
    const float DESTROY_DISTANCE = 40;

    public Object[] WallsPrefab;
    public Object[] JumpersPrefab;

    private int previousPos = -1;

    public static GameManager instance;

    public enum Spawn
    {
        WALL,
        JUMPER
    }

	// Use this for initialization
	void Start () {
        WallsPrefab = Resources.LoadAll("Prefabs/Walls");
        JumpersPrefab = Resources.LoadAll("Prefabs/Jumpers");
        if (!instance)
            instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        SpawnBlock(Spawn.JUMPER);
        DestroyAtDistance();
	}

    //Creer le bloc depuis un prefab en fonction du type
    public void SpawnBlock(Spawn type)
    {
        switch(type)
        {
            case Spawn.WALL:
                SpawnFromDistance(WALL_DISTANCE, WallsPrefab);
                break;
            case Spawn.JUMPER:
                SpawnFromDistance(JUMPER_DISTANCE, JumpersPrefab);
                break;
        }
    }

    //Check si la distance du dernier objet créé respecte la distance désirée puis creer un objet aléatoire depuis la liste de prefabs
    private void SpawnFromDistance(float distance, Object[] prefabList)
    {
        int pos = Random.Range(0, prefabList.Length);
        if(pos != previousPos)
        {
            if (objectSpawned.Count != 0)
            {
                if (spawnTransform.position.z - objectSpawned[objectSpawned.Count - 1].transform.position.z > distance)
                {
                    objectSpawned.Add(Instantiate(prefabList[pos] as GameObject, spawnTransform.position, Quaternion.identity));
                    previousPos = pos;
                }
            }
            else
            {
                objectSpawned.Add(Instantiate(prefabList[pos] as GameObject, spawnTransform.position, Quaternion.identity));
            }
        }
    }

    private void DestroyAtDistance()
    {
        if (spawnTransform.position.z - objectSpawned[0].transform.position.z > DESTROY_DISTANCE)
        {
            Destroy(objectSpawned[0]);
            objectSpawned.Remove(objectSpawned[0]);
        }
    }
}
