using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLineScript : MonoBehaviour {

    public bool isColliding;

    public GameManager gameManager;
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
    public void SetIsColliding(bool val)
    {
        isColliding = val;
    }
    void OnTriggerEnter(Collider collider)
    {
        isColliding = true;
    }
    void OnTriggerStay(Collider collider)
    {
        isColliding = true;
    }
    void OnTriggerExit(Collider collider)
    {
        isColliding = false;
    }

}
