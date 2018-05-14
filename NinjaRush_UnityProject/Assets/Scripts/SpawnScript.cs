using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    private bool isColliding;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public bool GetIsColliding()
    {
        return isColliding;
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

}
