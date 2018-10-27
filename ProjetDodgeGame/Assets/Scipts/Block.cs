using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    protected static float speed = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Player.instance.isPlaying)
            Movement();
	}

    public void Movement()
    {
        transform.Translate(new Vector3(0, 0, -Time.deltaTime * speed));
    }
}
