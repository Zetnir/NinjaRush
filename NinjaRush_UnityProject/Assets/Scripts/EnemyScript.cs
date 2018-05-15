using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    /////!\Il Faut creer un héritage pour tous les type et              /!\\\\\\\
    /////!\utiliser le polymorphisme pour les utiliser OnFight()        /!\\\\\\\
    /////!\à partir d'un pointeur dans spawnscript de type EnemyScript  /!\\\\\\\

    public enum EnemyType
    {
        BASIC,
        ARMOR,
        HELMET
    }

    public EnemyType enemyType;

    private float speed = 5f;
    // Use this for initialization
    void Start() {
        switch(gameObject.name)
        {
            case "Basic_Enemy(Clone)":
                enemyType = EnemyType.BASIC;
                break;
            case "Armor_Enemy(Clone)":
                enemyType = EnemyType.ARMOR;
                break;
            case "Helmet_Enemy(Clone)":
                enemyType = EnemyType.HELMET;
                break;

        }
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    public void Movement()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, movementSpeed));
    }

    public void OnFight()
    {
        switch(enemyType)
        {
            case EnemyType.BASIC:
                Destroy(gameObject);
                break;
            case EnemyType.ARMOR:
                Destroy(gameObject);
                break;
            case EnemyType.HELMET:
                Destroy(gameObject);
                break;
        }
    }
}
