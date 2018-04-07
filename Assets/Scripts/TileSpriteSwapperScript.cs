using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpriteSwapperScript : MonoBehaviour {

    /**
     * In this class we only set correct atlas and the correct sprite we want to use.
     */

    public Sprite [] dirtSpriteAtlas;
    public Sprite [] coldSpriteAtlas;
    public Sprite [] fossilSpriteAtlas;
    public Sprite [] alienSpriteAtlas;
    public Sprite [] miscAtlas;

    public Sprite [] _atlasToUse;

    SpriteRenderer render;

	// Use this for initialization
	void Awake () {
        render = GetComponent<SpriteRenderer>();
        // Let's se some sprites initially, so we dont crash.
        _atlasToUse = dirtSpriteAtlas;
        render.sprite = _atlasToUse[0];
	}

    // Asetetaan sprite atlas, riippuen millainen kenttä halutaan luoda
    public void SetAtlasToUse(Enums.MapChunkBiodome biodome) {
        switch (biodome) {
            case Enums.MapChunkBiodome.cold:
                _atlasToUse = coldSpriteAtlas;
                break;
            case Enums.MapChunkBiodome.warm:
                _atlasToUse = dirtSpriteAtlas;
                break;
            case Enums.MapChunkBiodome.fossil:
                _atlasToUse = fossilSpriteAtlas;
                break;
            case Enums.MapChunkBiodome.alien:
                _atlasToUse = alienSpriteAtlas;
                break;
        }
    }

    // Asettaa käytettävän sprite atlaksesta 
    public void SetSprite(int index) {
        render.sprite = _atlasToUse[index];
    }

    // Asetetaan Misc atlas käyttöön, ei mene biodomen mukaan.
    public void SetSpriteToBoundry() {
        _atlasToUse = miscAtlas; 
    }

    // Update is called once per frame
    void Update() {

    }
}
