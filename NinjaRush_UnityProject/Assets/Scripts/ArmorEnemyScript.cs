using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorEnemyScript : EnemyScript {

    private Vector3 deadPos = new Vector3(0, 0, -0.335f);
    private int points = 3;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override int OnFight()
    {
        float movementSpeed = GetActualSpeed() * Time.deltaTime;
        transform.GetChild(0).Translate(-new Vector3(0, 0, movementSpeed));
        if(transform.GetChild(0).localPosition.z <= deadPos.z)
        {
            SetIsDead(true);
            return points;
        }
        return 0;
    }

    public override int GetPoints()
    {
        return points;
    }

    public override void SetPoints(int points)
    {
        this.points = points;
    }
}
