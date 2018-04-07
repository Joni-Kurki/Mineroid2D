using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData {

    List<MapChunk> _mapChunks = new List<MapChunk>();
    public int _numberOfMapChunks;

    public MapData(int numberOfMapChunks, bool random = false) {
        _numberOfMapChunks = numberOfMapChunks;

        if(random)
            RandomizeMapChunks();
    }

    void RandomizeMapChunks() {
        for (var i = 0; i < _numberOfMapChunks; i++)
            AddRandomMapChunk();
    }

    public void SetMapChunk(int index, MapChunk mapChunk) {
        _mapChunks[index] = mapChunk;
    }

    public void AddMapChunk(MapChunk mapChunk) {
        _mapChunks.Add(mapChunk);
    }

    void AddRandomMapChunk(int tier = 0) {
        var tierToAdd = 1;
        
        if (tier == 0) {
            tierToAdd = Random.Range(Constants.IntMapTiers.MIN_TIER, Constants.IntMapTiers.MAX_TIER);
        }

        _mapChunks.Add(new MapChunk(0, 0, tier, true));
    }

    public MapChunk GetMapChunk(int index) {
        return _mapChunks[index];
    }

    public List<MapChunk> GetMapChunkList() {
        return _mapChunks;
    }
}

public class MapChunk {

    public int _x;
    public int _y;
    public int _tier;
    public Enums.MapChunkBiodome _mapBiodome;
    public Enums.MapChunkWealth _mapWealth;
    public Enums.MapSize _mapSize;
    public Enums.MapOrientation _mapOrientation;

    public MapChunk(int x, int y, int tier, 
        Enums.MapSize mapSize = Enums.MapSize.SMALL, 
        Enums.MapOrientation mapOrientation = Enums.MapOrientation.Vertical,
        Enums.MapChunkBiodome biodome = Enums.MapChunkBiodome.random, 
        Enums.MapChunkWealth mapWealth = Enums.MapChunkWealth.poorAsFuck) {
        _x = x;
        _y = y;
        _tier = tier;
        if (biodome == Enums.MapChunkBiodome.random) {
            int r = Random.Range(0, 4);
            Debug.Log("Roll " + r);

            _mapBiodome = (Enums.MapChunkBiodome)r;
        } else
            _mapBiodome = biodome; 
        _mapWealth = mapWealth;

        _mapSize = mapSize;
        _mapOrientation = mapOrientation;

        Debug.Log("Created (" + _x + " | " + _y + ") T:" + _tier + " with biodome: " + _mapBiodome + " wealth: " + _mapWealth);
    }

    public MapChunk(int x, int y, int tier,
        bool randomSize = true,
        Enums.MapChunkBiodome biodome = Enums.MapChunkBiodome.random,
        Enums.MapChunkWealth mapWealth = Enums.MapChunkWealth.poorAsFuck) {
        _x = x;
        _y = y;
        _tier = tier;
        if (biodome == Enums.MapChunkBiodome.random) {
            int r = Random.Range(0, 4);
            Debug.Log("Roll " + r);

            _mapBiodome = (Enums.MapChunkBiodome)r;
        } else
            _mapBiodome = biodome;
        _mapWealth = mapWealth;

        _mapSize = (Enums.MapSize)getRandomSize();
        _mapOrientation = (Enums.MapOrientation)getRandomMapOrientation();

        Debug.Log("Created (" + _x + " | " + _y + ") T:" + _tier + " with biodome: " + _mapBiodome + " wealth: " + _mapWealth);
    }

    int getRandomSize() {
        return Random.Range(0, Constants.MapPropertiesCount.NUMBER_OF_MAPSIZES);
    }

    int getRandomMapOrientation() {
        return Random.Range(0, Constants.MapPropertiesCount.NUMBER_OF_ORIENTATIONS);
    }
}
