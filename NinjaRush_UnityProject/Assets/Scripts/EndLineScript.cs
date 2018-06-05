using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLineScript : MonoBehaviour {

    public bool isColliding;

    public GameObject actualHit;
    public int nbEnemiesCol = 0;
    //public GameManager gameManager;
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
        if (collider.tag == "Enemy")
        {
            if(actualHit != collider.gameObject)
            {
                nbEnemiesCol++;
                actualHit = collider.gameObject;
            }
            SetIsColliding(true);
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Enemy")
            SetIsColliding(true);
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            SetIsColliding(false);
        }
    }

    public int GetNbEnemiesCol()
    {
        return nbEnemiesCol;
    }

    public void SetNbEnemiesCol(int val)
    {
        nbEnemiesCol = val;
    }

}
