using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    RaycastHit hit;
    public Camera cam;
    bool isDead = false;
    public float jumpHeight = 3.0f;
    public bool isJumping = false;
    public bool isGrounded = false;

    public bool isPlaying = false;
    public static Player instance;
	// Use this for initialization
	void Start () {
        if (!instance)
            instance = this;
        isPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        if(isJumping)
        {
            Jump();
        }
    }

    // The charater movement follow the finger/mouse of the player on click
    public void Movement()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //for the test, use Input.GetTouch(0).position
        if (Physics.Raycast(ray,out hit,100f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            if(hit.transform.tag != "Limit")
                transform.position =new Vector3(hit.point.x,transform.position.y,transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            isDead = true;
        }
        else if(other.gameObject.tag == "Jumper")
        {
            isJumping = true;
        }
    }

    private void Jump()
    {
        if()
    }
}
