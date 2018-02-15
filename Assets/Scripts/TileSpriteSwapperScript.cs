using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteSwapperScript : MonoBehaviour {

    public Sprite [] dirtSpriteAtlas;
    SpriteRenderer render;

	// Use this for initialization
	void Awake () {
        render = GetComponent<SpriteRenderer>();
        render.sprite = dirtSpriteAtlas[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSprite(int index) {
        render.sprite = dirtSpriteAtlas[index];
    }
}
