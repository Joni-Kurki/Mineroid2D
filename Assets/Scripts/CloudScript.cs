using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    GameObject player;
    public float speed;
    SpriteRenderer render;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        render = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = new Vector3(0, 0, 0);

        Vector2 scrollOffset = new Vector2(Time.time * speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = scrollOffset;

        //transform.position = player.transform.position + offset; 
	}
}
