using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimScript : MonoBehaviour {

    public float _distanceToPlayer;
    const float MAX_DISTANCE = 1;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _distanceToPlayer = Vector2.Distance(transform.position, gameObject.transform.parent.position);

        //gameObject.transform.Translate(Vector3.right);

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        // Estetään karkaaminen
        if (_distanceToPlayer >= MAX_DISTANCE) {
            _distanceToPlayer = 1;
            
            //gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
