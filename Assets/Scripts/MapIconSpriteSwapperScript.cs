using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIconSpriteSwapperScript : MonoBehaviour {

    public Sprite [] spriteAtlas;
    public GameObject mapIconPrefab;
    public Enums.MapSize _mapSize;
    bool _initDone = true;
    bool _instantiated = false;

	// Use this for initialization
	void Start () {
        
	}

    public void InitIcon(Enums.MapSize mapSize){
        _mapSize = mapSize;
        _initDone = true;
    }

    void InstantateIcon() {

        var go = Instantiate(mapIconPrefab, transform);
        go.name = "MapIcon_Scroll";

        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        sr.sprite = spriteAtlas[Constants.MapIconAtlasConstants.SCROLL_INDEX];

        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                go = Instantiate(mapIconPrefab, transform);
                go.name = "MapIcon_X";
                sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = spriteAtlas[Constants.MapIconAtlasConstants.X_INDEX];

                go = Instantiate(mapIconPrefab, transform);
                go.name = "MapIcon_S";
                sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = spriteAtlas[Constants.MapIconAtlasConstants.S_INDEX];
                _instantiated = true;
                break;
            case Enums.MapSize.SMALL:
                go = Instantiate(mapIconPrefab, transform);
                go.name = "MapIcon_S";
                sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = spriteAtlas[Constants.MapIconAtlasConstants.S_INDEX];
                _instantiated = true;
                break;
            case Enums.MapSize.MEDIUM:
                go = Instantiate(mapIconPrefab, transform);
                go.name = "MapIcon_M";
                sr = go.GetComponent<SpriteRenderer>();
                sr.sprite = spriteAtlas[Constants.MapIconAtlasConstants.M_INDEX];
                _instantiated = true;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (_initDone && !_instantiated) {
            InstantateIcon();
        }
	}
}
