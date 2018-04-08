using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {

    public GameObject cam;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = new Vector3(
            gameObject.transform.position.x + offset.x, 
            gameObject.transform.position.y + offset.y, 
            gameObject.transform.position.z + offset.z);

        //bg.transform.position = new Vector3(
        //    gameObject.transform.position.x + offset.x,
        //    gameObject.transform.position.y + offset.y,
        //    gameObject.transform.position.z + offset.z);

    }
}
