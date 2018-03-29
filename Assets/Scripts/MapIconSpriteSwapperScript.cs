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

    void InitIcon(Enums.MapSize mapSize){
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
                var goxs1 = Instantiate(mapIconPrefab, transform);
                goxs1.name = "MapIcon_X";
                SpriteRenderer srxs1 = goxs1.GetComponent<SpriteRenderer>();
                srxs1.sprite = spriteAtlas[Constants.MapIconAtlasConstants.X_INDEX];

                var goxs = Instantiate(mapIconPrefab, transform);
                goxs.name = "MapIcon_S";
                srxs1 = goxs.GetComponent<SpriteRenderer>();
                srxs1.sprite = spriteAtlas[Constants.MapIconAtlasConstants.S_INDEX];
                _instantiated = true;
                break;
            case Enums.MapSize.SMALL:
                var gos = Instantiate(mapIconPrefab, transform);
                gos.name = "MapIcon_S";
                SpriteRenderer srs = gos.GetComponent<SpriteRenderer>();
                srs.sprite = spriteAtlas[Constants.MapIconAtlasConstants.S_INDEX];
                _instantiated = true;
                break;
            case Enums.MapSize.MEDIUM:
                var gom = Instantiate(mapIconPrefab, transform);
                gom.name = "MapIcon_M";
                SpriteRenderer srm = gom.GetComponent<SpriteRenderer>();
                srm.sprite = spriteAtlas[Constants.MapIconAtlasConstants.S_INDEX];
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
