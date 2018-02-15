using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedTileScript : MonoBehaviour {

    Rigidbody2D rb;
    float randomForceMult;
    public float DestroyDelay;

    void Awake() {
        Destroy(gameObject, DestroyDelay);
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        randomForceMult = Random.Range(4, 10);
        rb.velocity = Random.onUnitSphere * randomForceMult;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate() {
        //rb.AddForce(Vector2.one * randomForceMult);
    }
}
