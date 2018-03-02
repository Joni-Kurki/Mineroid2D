using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapCreatorScript : MonoBehaviour {

    public GameObject MapPiecePrefab;
    MapData _map;
    bool mapInited = false;
    public int numberOfMapChunks;

	// Use this for initialization
	void Start () {
        _map = new MapData(numberOfMapChunks);

        UnpackAndInstantiateMapChunks();
	}

    void UnpackAndInstantiateMapChunks() {
        var y = 0;
        var x = 0;
        for (int i = 0; i < numberOfMapChunks; i++) {
            if (x % 3 == 0 && i > 0) {
                x = 0;
                y++;
            }

            MapChunk mChunk = new MapChunk(x, y, 0, Enums.MapSize.MEDIUM);

            var go = Instantiate(MapPiecePrefab, new Vector2(x * 2, y * 2), MapPiecePrefab.transform.rotation, transform);
            go.name = "MapChunk_" + x + "_" + y;
            MapChunkScript mcs = go.GetComponent<MapChunkScript>();

            
            _map.AddMapChunk(mChunk);
            mcs.SetMapChunk(_map.GetMapChunk(i));

            x++;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
