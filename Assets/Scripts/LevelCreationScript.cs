﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreationScript : MonoBehaviour {

    CreateLevel _levelCreator;
    public GameObject groundDirtPrefab;
    public GameObject groundRockrefab;
    public GameObject chunkContainerPrefab;

    // MapSize editoriin
    public Enums.MapSize mapSize;
    // MapOrientation editoriin
    public Enums.MapOrientation mapOrientation;

    // Use this for initialization
    void Start () {
        InitLevel();
    }


    public void InitLevel() {
        Debug.Log("Loaded level with " + SceneChangeHelper._mapSize + " and " + SceneChangeHelper._mapOrientation);

        _levelCreator = new CreateLevel(0, 0, SceneChangeHelper._mapSize , SceneChangeHelper._mapOrientation);

        var pXInit = 0;
        var pYInit = 10;

        var go = GameObject.FindGameObjectWithTag("Player");

        go.transform.Translate(GetPlayerSpawnX(SceneChangeHelper._mapSize, SceneChangeHelper._mapOrientation));

        Debug.Log(go.name + "( "+go.transform.position+" )");

        UnpackAndInstantiateChunks();
    }

    Vector3 GetPlayerSpawnX(Enums.MapSize mSize, Enums.MapOrientation mOr) {
        switch (mSize) {
            case Enums.MapSize.EXTRA_SMALL:
                if(mOr == Enums.MapOrientation.Horizontal)
                    return new Vector2((Constants.Chunk.CHUNK_X * Constants.IntMapSize.EXTRA_SMALL) / 2 , 
                        Constants.Chunk.CHUNK_Y + 1 );
                else
                    return new Vector2((Constants.Chunk.CHUNK_X * 1) / 2, 
                        Constants.Chunk.CHUNK_Y * Constants.IntMapSize.EXTRA_SMALL + 1);
            case Enums.MapSize.SMALL:
                if (mOr == Enums.MapOrientation.Horizontal)
                    return new Vector2((Constants.Chunk.CHUNK_X * (Constants.IntMapSize.SMALL / 2)) / 2 , 
                        (Constants.Chunk.CHUNK_Y * 2) + 1 );
                else
                    return new Vector2((Constants.Chunk.CHUNK_X * 2) / 2, 
                        Constants.Chunk.CHUNK_Y * (Constants.IntMapSize.SMALL / 2) + 1);
            case Enums.MapSize.MEDIUM:
                if (mOr == Enums.MapOrientation.Horizontal)
                    return new Vector2((Constants.Chunk.CHUNK_X * (Constants.IntMapSize.MEDIUM / 2)) / 2,
                        (Constants.Chunk.CHUNK_Y * 2) + 1);
                else
                    return new Vector2((Constants.Chunk.CHUNK_X * 2) / 2,
                        Constants.Chunk.CHUNK_Y * (Constants.IntMapSize.MEDIUM / 2) + 1);
            default:
                return new Vector2(0, 0);
        }
    }

    void UnpackAndInstantiateChunks() {
        // CHUNK
        for(var i = 0; i < _levelCreator._chunks.Length; i++) {
            var chunk = _levelCreator._chunks[i];
            var cGo = Instantiate(chunkContainerPrefab, new Vector2(chunk._x, chunk._y), Quaternion.identity);
            
            //  TILE
            for (var y = 0; y < Constants.Chunk.CHUNK_Y; y++) {
                for(var x = 0; x < Constants.Chunk.CHUNK_Y; x++) {
                    var tile = chunk._tiles[x, y];
                    // Jos tarkasteltavan tilen on groundDirt tyyppiä
                    if (tile._tileType == Enums.GroundTileType.groundDirt) {
                        var go = Instantiate(groundDirtPrefab, 
                            new Vector2(chunk._x + chunk._tiles[x,y]._x, chunk._y + chunk._tiles[x, y]._y), 
                            groundDirtPrefab.transform.rotation, 
                            cGo.transform);

                        // asetetaan luodulle tilelle hp
                        TileControllerScript tcs = go.GetComponent<TileControllerScript>();
                        tcs.currentHp = tile._hp;

                        // asetetaan tilelle sprite
                        TileSpriteSwapperScript tsss = go.GetComponent<TileSpriteSwapperScript>();
                        tsss.SetAtlasToUse(SceneChangeHelper._mapBiodome);
                        // TODO: tänne sitten muutkin tileset määrittelyt
                        tsss.SetSprite(GetRandomTileVariationForGroundDirt());

                        // Jos päälimmäinen kerros
                        if (y == Constants.Chunk.CHUNK_Y-1) {
                            var maxChunkY = _levelCreator._chunks.Max(c => c._y);
                            if(chunk._y == maxChunkY)
                                tsss.SetSprite(Constants.TileConstants.TileDirtAtlas.DIRT_TOP_MOSS_VAR_0);
                        }
                    }
                }
            }
        }
    }

    // Palauttaa random variaation "dirt":lle, riippuen monta erillaista tileä voidaan käyttää
    int GetRandomTileVariationForGroundDirt() {
        // 0 - ((3 * 10)-1) = 29
        float ran = Random.Range(0, Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10);

        // 0 - < 18             [0 - 60]%
        if (ran >= 0 && ran < (Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10 ) /10 * 6)
            return Constants.TileConstants.TileDirtAtlas.NORMAL_VAR_INDEX[0];
        // >= 18 - < 25,5       [60 - 85]%
        else if (ran >= (Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10 ) / 10 * 6 && 
                 ran <  (Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10) / 10 * 8.5f)
            return Constants.TileConstants.TileDirtAtlas.NORMAL_VAR_INDEX[1];
        // >= 25,5 - 30         [85 - 100]%
        else if (ran >= (Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10) / 10 * 8.5f &&
                 ran <  (Constants.TileConstants.TileDirtAtlas.NUMBER_OF_NORMAL_VARS * 10) )
            return Constants.TileConstants.TileDirtAtlas.NORMAL_VAR_INDEX[2];
        else
            return Constants.TileConstants.TileDirtAtlas.NORMAL_VAR_INDEX[0];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
