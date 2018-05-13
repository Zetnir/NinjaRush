using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    public void Movement()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(new Vector3(0, 0, movementSpeed));
    }
}
