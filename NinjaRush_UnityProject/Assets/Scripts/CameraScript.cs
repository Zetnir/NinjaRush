using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Vector3 menuViewPos = new Vector3(0.1f, -2.45f, 47);
    private Quaternion menuViewRot = Quaternion.Euler(10, 180, 0);

    private Vector3 inGameViewPos = new Vector3(0.2f, 4f, 42f);
    private Quaternion inGameViewRot = Quaternion.Euler(70, 180, 0);

    private float speedMovement = 2f;
    private float speedRotation = 2f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    public void SetMenuView()
    {
        if(transform.position != menuViewPos && transform.rotation!= menuViewRot)
        {
            transform.position = Vector3.Lerp(transform.position, menuViewPos, speedMovement * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, menuViewRot, speedRotation * Time.deltaTime);
        }
    }

    public void SetInGameView()
    {
        if (transform.position != inGameViewPos && transform.rotation != inGameViewRot)
        {
            transform.position = Vector3.Lerp(transform.position, inGameViewPos, speedMovement * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, inGameViewRot, speedRotation * Time.deltaTime);
        }
    }
}
