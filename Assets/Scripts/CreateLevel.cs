using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel {

    public Enums.MapSize _mapSize;
    public Enums.MapOrientation _mapOrientation;
    public int _mapTier;
    int _h;
    int _w;

    public Chunk [] _chunks;

	public CreateLevel(int h, int w, Enums.MapSize mapSize, Enums.MapOrientation mapOrientation) {
        //Debug.Log("CreateLevel constructor");
        _h = h;
        _w = w;
        _mapSize = mapSize;
        _mapOrientation = mapOrientation;
        _chunks = new Chunk[getNumberOfChunks()];

        InitChunks();
    }

    void InitChunks() {
        int noOfChunks = _chunks.Length;
        int y = 0;
        int x = 0;

        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        for (var i = 0; i < noOfChunks; i++) {
                            _chunks[i] = new Chunk(i * Constants.Chunk.CHUNK_OFFSET, 0);
                        }
                        break;
                    case Enums.MapOrientation.Vertical:
                        for (var i = 0; i < noOfChunks; i++) {
                            _chunks[i] = new Chunk(0, i * Constants.Chunk.CHUNK_OFFSET);
                        }
                        break;
                }
            break;
            case Enums.MapSize.SMALL:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        for (var i = 0; i < noOfChunks; i++) {
                            if (i % 3 == 0 && i != 0) {
                                y++;
                                x = 0;
                            }

                            _chunks[i] = new Chunk(x * Constants.Chunk.CHUNK_OFFSET, Constants.Chunk.CHUNK_OFFSET * y);

                            x++;
                        }
                        break;
                    case Enums.MapOrientation.Vertical:
                        for (var i = 0; i < noOfChunks; i++) {
                            if (i % 2 == 0 && i != 0) {
                                y++;
                                x = 0;
                            }

                            _chunks[i] = new Chunk(x * Constants.Chunk.CHUNK_OFFSET, Constants.Chunk.CHUNK_OFFSET * y);

                            x++;
                        }
                        break;
                }
                break;
            case Enums.MapSize.MEDIUM:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        for (var i = 0; i < noOfChunks; i++) {
                            if (i % 5 == 0 && i != 0) {
                                y++;
                                x = 0;
                            }

                            _chunks[i] = new Chunk(x * Constants.Chunk.CHUNK_OFFSET, Constants.Chunk.CHUNK_OFFSET * y);

                            x++;
                        }
                        break;
                    case Enums.MapOrientation.Vertical:
                        for (var i = 0; i < noOfChunks; i++) {
                            if (i % 2 == 0 && i != 0) {
                                y++;
                                x = 0;
                            }

                            _chunks[i] = new Chunk(x * Constants.Chunk.CHUNK_OFFSET, Constants.Chunk.CHUNK_OFFSET * y);

                            x++;
                        }
                        break;
                }
                break;
        }
    }

    int getNumberOfChunks() {
        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                return Constants.IntMapSize.EXTRA_SMALL;
            case Enums.MapSize.SMALL:
                return Constants.IntMapSize.SMALL;
            case Enums.MapSize.MEDIUM:
                return Constants.IntMapSize.MEDIUM;
        }
        return 0;
    }

}

public class Chunk {

    public int _x;
    public int _y;
    public Tile[,] _tiles;
    
    public Chunk(int x, int y) {
        //Debug.Log(">>Chunk constructor");
        _x = x;
        _y = y;
        _tiles = new Tile[Constants.Chunk.CHUNK_X, Constants.Chunk.CHUNK_Y];

        InitChunk();
    }

    void InitChunk() {
        for(var y = 9; y >= 0; y--) {
            for(var x = 0; x < 10; x++) {
                _tiles[x, y] = new Tile(x, y, Enums.GroundTileType.groundDirt);
            }
        }
    }

}

public class Tile {

    public int _x;
    public int _y;
    public float _hp;
    public Enums.GroundTileType _tileType;
    public int _depth;

    public Tile(int x, int y, Enums.GroundTileType type) {
        //Debug.Log(">> >>Tile constructor");
        _x = x;
        _y = y;
        _tileType = type;
        _hp = CalculateTileHp();
    }

    float CalculateTileHp() {
        var hp = 0f;
        switch (_tileType) {
            case Enums.GroundTileType.groundDirt:
                hp = _y + ( Constants.TileConstants.TILE_DIRT_BASE_HP * Constants.TileConstants.TILE_DIRT_MULTIPLIER);
                break;
            case Enums.GroundTileType.groundGrass:
                hp = _y + (Constants.TileConstants.TILE_GRASS_BASE_HP * Constants.TileConstants.TILE_GRASS_MULTIPLIER);
                break;
            case Enums.GroundTileType.groundRock:
                hp = 10000000000;
                break;
        }
        return hp;
    }

}

