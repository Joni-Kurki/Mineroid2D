using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapChunkScript : MonoBehaviour {

    public int x;
    public int y;
    public int tier;
    public Enums.MapSize _mapSize;
    public Enums.MapOrientation _mapOrientation;
    public Enums.MapChunkWealth _mapWealth;
    public Enums.MapChunkBiodome _mapBiodome;
    SpriteRenderer renderer;
    public Material materialToUse;
    Color originalMaterial;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();		
	}

    public void SetMapChunk(MapChunk mapChunk) {
        x = mapChunk._x;
        y = mapChunk._y;
        tier = mapChunk._tier;
        _mapWealth = mapChunk._mapWealth;
        _mapBiodome = mapChunk._mapBiodome;
        _mapSize = mapChunk._mapSize;
        _mapOrientation = mapChunk._mapOrientation;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        originalMaterial = renderer.material.color;
        renderer.material.color = new Color(255, 0, 0);
    }

    void OnMouseExit() {
        renderer.material.color = originalMaterial;
    }

    void OnMouseDown() {
        Debug.Log("Clicked "+gameObject.name);
        Debug.Log("Maptier "+tier);

        SceneChangeHelper._mapSize = _mapSize;
        SceneChangeHelper._mapOrientation = _mapOrientation;
        SceneChangeHelper._mapBiodome = _mapBiodome;
        SceneChangeHelper._mapWealth = _mapWealth;

        SceneManager.LoadScene("2DLevelScene", LoadSceneMode.Single);
    }

}
