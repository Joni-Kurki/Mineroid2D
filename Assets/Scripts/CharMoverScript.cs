using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMoverScript : MonoBehaviour {

    public float speed;
    Rigidbody2D rb;
    SpriteRenderer renderer;

    public bool isMining;
    public bool isGrounded;

    List<GameObject> lootalbeList;
    public int lootListL;

    public float charJumpStrength;
    public float charMoveSpeed;

    enum MoveDirection {
        right = 1,
        left = 2,
    }

    MoveDirection dir;
    bool flipSprite;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();

        lootalbeList = new List<GameObject>();

        rb = GetComponent<Rigidbody2D>();
        isMining = false;

        dir = MoveDirection.right;
        flipSprite = false;

        // Player & Loot layers
        Physics2D.IgnoreLayerCollision(9, 10);
    }
	
	// Update is called once per frame
	void Update () {
        if(flipSprite) {
            renderer.flipX = !renderer.flipX;
            flipSprite = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (dir == MoveDirection.right) {
                dir = MoveDirection.left;
                flipSprite = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            if (isGrounded) {
                isGrounded = !isGrounded;
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            if (dir == MoveDirection.left) {
                dir = MoveDirection.right;
                flipSprite = true;
            }
        }
        
        //if (Input.GetKeyDown(KeyCode.S)) {
        if (Input.GetMouseButtonDown(0)) { 
            //transform.position += (Vector3.down * speed);
            isMining = true;
        }
        //if (Input.GetKeyUp(KeyCode.S)) {
        if (Input.GetMouseButtonUp(0)) {
            //transform.position += (Vector3.down * speed);
            isMining = false;
        }
        // Loot pickup
        if (Input.GetKeyDown(KeyCode.E)) {
            LootPoolerScript lps = GameObject.FindGameObjectWithTag("LootPooler").GetComponent<LootPoolerScript>();
            lps.FindLootsThatPlayerCanPickup(transform.position, 1);
            lootalbeList = new List<GameObject>();

            var ret = lps.FindLootsThatPlayerCanPickup(transform.position, 1);

            foreach(GameObject go in ret) {
                LootPickupScript pickup = go.GetComponent<LootPickupScript>();
                pickup.OnPickup();
            }

        }
    }

    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.W) /*&& isGrounded*/ && rb.velocity.magnitude < 10) {
            rb.velocity += Vector2.up * charJumpStrength;
        }
        if (Input.GetKey(KeyCode.A)) {
            if (rb.velocity.magnitude < 10)
                rb.velocity += Vector2.left * charMoveSpeed;
        }
        if (Input.GetKey(KeyCode.D)) {
            if(rb.velocity.magnitude < 10)
                rb.velocity += Vector2.right * charMoveSpeed;
        }
        if (rb.velocity.magnitude < .01) {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Mineable") {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Mineable") {
            isGrounded = false;
        }
    }
}
