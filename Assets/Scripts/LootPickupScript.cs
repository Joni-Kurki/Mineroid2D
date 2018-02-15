using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickupScript : MonoBehaviour {

    bool isPickedUp;

	// Use this for initialization
	void Start () {
        isPickedUp = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPickedUp) {
            Debug.Log("Picked up " + gameObject.name);
            gameObject.SetActive(false);
        }
	}

    public void OnPickup() {
        isPickedUp = true;
    }

    public void ResetPickup() {
        isPickedUp = false;
    }
}
