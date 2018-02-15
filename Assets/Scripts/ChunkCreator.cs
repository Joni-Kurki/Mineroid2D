using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCreator : MonoBehaviour {

    TileData chunkData;
    public int x;
    public int y;
    public int w;
    public int h;
    public GameObject tilePrefabAir;
    public GameObject tilePrefabGround;
    public GameObject tilePrefabRock;
    int tiles;

    // Use this for initialization
    void Start () {
        chunkData = new TileData(x, y, w, h);

        this.gameObject.name = "Chunk_" + x + "_" + y;

        InstantiateChunk();
    }

    void InstantiateChunk() {
        for (var yPos = 0; yPos < h; yPos++) {
            for (var xPos = 0; xPos < w; xPos++) {
                if (chunkData.getTileAt(xPos, yPos).getTile() == TileType.TileTypes.ground) {
                    var go = Instantiate(tilePrefabGround, new Vector2(x + xPos, y + yPos), tilePrefabGround.transform.rotation, transform);
                    TileControllerScript tcs = go.GetComponent<TileControllerScript>();
                    tcs.tile = new TileType(true, yPos, h);
                    tcs.tile._tileHP = 2;
                    tcs.initTile();
                    //Debug.Log(tcs.tile.getTileHp());
                }else if(chunkData.getTileAt(xPos, yPos).getTile() == TileType.TileTypes.obstacle) {
                    var go = Instantiate(tilePrefabRock, new Vector2(x + xPos, y + yPos), tilePrefabRock.transform.rotation, transform);
                    TileControllerScript tcs = go.GetComponent<TileControllerScript>();
                    tcs.tile = new TileType(true, yPos, h);
                    tcs.tile._tileHP = 10000000000;
                    tcs.initTile();
                } 
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
