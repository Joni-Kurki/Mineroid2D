using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMineScript : MonoBehaviour {

    CharMoverScript cms;
    public GameObject colObject;

    public float miningPower;

	// Use this for initialization
	void Start () {
        cms = transform.parent.GetComponent<CharMoverScript>();
        // IgnoredTile
        Physics2D.IgnoreLayerCollision(8, 8);
        // IgnoredTile & Player
        Physics2D.IgnoreLayerCollision(8, 9);
    }
	
	// Update is called once per frame
	void Update () {
        // Check if mineable
        if (cms.isMining && colObject != null) {

            TileControllerScript tcs = colObject.GetComponent<TileControllerScript>();
            tcs.TakeDamage(miningPower);
        }
    }

    public void SetColObject(GameObject go) {
        colObject = go;
    }

    void OnCollisionStay2D(Collision2D col) {
        if (col.collider.GetType() == typeof(BoxCollider2D)) {
            //if (col.gameObject.tag == "Mineable") {
            colObject = col.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D col) {
        if (col.collider.GetType() == typeof(BoxCollider2D)) {
            //if (col.gameObject.tag == "Mineable") {
            colObject = null;
        }
    }
}
