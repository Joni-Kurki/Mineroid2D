using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_GemScript : MonoBehaviour {

    public Sprite[] gemPrefabs;
    SpriteRenderer render;

    // Use this for initialization
    private void Awake() {
        render = GetComponent<SpriteRenderer>();
        render.sprite = gemPrefabs[0];
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSprite(int gemIndex) {
        render.sprite = gemPrefabs[gemIndex];
    }
}
