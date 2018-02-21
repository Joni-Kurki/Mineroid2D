using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChunkScript : MonoBehaviour {

    public int x;
    public int y;
    public int tier;
    public Enums.MapChunkWealth mapWealth;
    public Enums.MapChunkBiodome mapBiodome;
    SpriteRenderer renderer;
    public Material materialToUse;
    Material originalMaterial;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
		
	}

    public void SetMapChunk(MapChunk mapChunk) {
        x = mapChunk._x;
        y = mapChunk._y;
        tier = mapChunk._tier;
        mapWealth = mapChunk._mapWealth;
        mapBiodome = mapChunk._mapBiodome;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        originalMaterial = renderer.material;
        renderer.material.color = new Color(255, 0, 0);
    }

    void OnMouseExit() {
        renderer.material = originalMaterial;
    }

}
