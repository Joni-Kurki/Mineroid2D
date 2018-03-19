using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteSwapperScript : MonoBehaviour {

    public Sprite [] dirtSpriteAtlas;
    public Sprite [] coldSpriteAtlas;

    public Sprite[] atlasToUse;

    SpriteRenderer render;

	// Use this for initialization
	void Awake () {
        render = GetComponent<SpriteRenderer>();

        atlasToUse = coldSpriteAtlas;

        render.sprite = atlasToUse[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAtlasToUse() {

    }

    public void SetSprite(int index) {
        render.sprite = atlasToUse[index];
    }
}
