using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : EnemyScript {

    private int points = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    public override int OnFight()
    {
        SetIsDead(true);
        return points;
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
