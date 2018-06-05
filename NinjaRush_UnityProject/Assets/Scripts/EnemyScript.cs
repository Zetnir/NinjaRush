using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    /////!\Il Faut creer un héritage pour tous les type et              /!\\\\\\\
    /////!\utiliser le polymorphisme pour les utiliser OnFight()        /!\\\\\\\
    /////!\à partir d'un pointeur dans spawnscript de type EnemyScript  /!\\\\\\\


    private float actualSpeed_;
    private bool isDead_ = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Movement();
    }

    public void Movement()
    {
        float movementSpeed = actualSpeed_ * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, movementSpeed));
    }

    public void SetActualSpeed(float speed)
    {
        actualSpeed_ = speed; ;
    }

    public float GetActualSpeed()
    {
        return actualSpeed_;
    }

    public bool GetIsDead()
    {
        return isDead_;
    }

    public void SetIsDead(bool val)
    {
        isDead_ = val;
    }

    public virtual int OnFight()
    {
        return 0;
    }

    public virtual int GetPoints()
    {
        return 0;
    }

    public virtual void SetPoints(int points)
    {

    }

}
