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
    public Chunk [] _wallChunks;

	public CreateLevel(int h, int w, Enums.MapSize mapSize, Enums.MapOrientation mapOrientation) {
        _h = h;
        _w = w;
        _mapSize = mapSize;
        _mapOrientation = mapOrientation;
        _chunks = new Chunk[getNumberOfChunks()];
        _wallChunks = new Chunk[getNumberOfWallChunks()];
        InitChunks();
        CreateBoundaryWallChunks();
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

    // Create wallchunks
    void CreateBoundaryWallChunks() {
        int noOfChunks = _wallChunks.Length;
        int y = 0;
        int x = 0;
        Debug.Log("CreateBoundaryWallChunks: " + noOfChunks);

        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        for(var i=0; i < noOfChunks; i++) {
                            if (i < 3) {
                                // First bottom
                                _wallChunks[i] = new Chunk(i * Constants.Chunk.CHUNK_X, -2, true, true);
                            } else {
                                // Then sides
                                var xOffset1 = -1;
                                var xOffset2 = Constants.MapSizeConstants.Dimensions_ExtraSmall.Horizontal.X * Constants.Chunk.CHUNK_X;
                                var offsetToUse = i % 2 == 0 ? xOffset1 : xOffset2;
                                _wallChunks[i] = new Chunk(offsetToUse, -1, true, true, true);
                            }
                        }
                        break;
                    case Enums.MapOrientation.Vertical:
                        break;
                }
                break;
            case Enums.MapSize.SMALL:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        break;
                    case Enums.MapOrientation.Vertical:
                        break;
                }
                break;
            case Enums.MapSize.MEDIUM:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        break;
                    case Enums.MapOrientation.Vertical:
                        break;
                }
                break;
        }
    }

    int getNumberOfChunks() {
        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                return Constants.MapSizeConstants.EXTRA_SMALL;
            case Enums.MapSize.SMALL:
                return Constants.MapSizeConstants.SMALL;
            case Enums.MapSize.MEDIUM:
                return Constants.MapSizeConstants.MEDIUM;
        }
        return 0;
    }

    int getNumberOfWallChunks() {
        switch (_mapSize) {
            case Enums.MapSize.EXTRA_SMALL:
                switch (_mapOrientation) {
                    case Enums.MapOrientation.Horizontal:
                        return Constants.MapSizeConstants.Dimensions_ExtraSmall.Horizontal.Y * 2 + Constants.MapSizeConstants.Dimensions_ExtraSmall.Horizontal.X;
                    case Enums.MapOrientation.Vertical:
                        return Constants.MapSizeConstants.Dimensions_ExtraSmall.Vertical.Y * 2 + Constants.MapSizeConstants.Dimensions_ExtraSmall.Vertical.X;
                }
                break;
            //case Enums.MapSize.SMALL:
            //    switch (_mapOrientation) {
            //        case Enums.MapOrientation.Horizontal:
            //            break;
            //        case Enums.MapOrientation.Horizontal:
            //            break;
            //    }
            //    break;
            //case Enums.MapSize.MEDIUM:
            //    switch (_mapOrientation) {
            //        case Enums.MapOrientation.Horizontal:
            //            break;
            //        case Enums.MapOrientation.Horizontal:
            //            break;
            //    }
            //    break;
            default:
                return -1;
        }
        return -1;
    }

}

public class Chunk {

    public int _x;
    public int _y;
    public Tile[,] _tiles;
    public bool _wallChunk;
    public bool _isHorizontal;
    public bool _isSideways;

    public Chunk(int x, int y, bool wallChunk = false, bool isHorizontal = false, bool isSideways = false) {
        _x = x;
        _y = y;
        _wallChunk = wallChunk;
        _isHorizontal = isHorizontal;
        _isSideways = isSideways;

        _tiles = new Tile[Constants.Chunk.CHUNK_X, Constants.Chunk.CHUNK_Y];

        InitChunk();
    }

    // Initating chunks
    void InitChunk() {
        // If is normal chunk
        if (!_wallChunk) {
            for (var y = 9; y >= 0; y--) {
                for (var x = 0; x < 10; x++) {
                    _tiles[x, y] = new Tile(x, y, Enums.GroundTileType.groundDirt);
                }
            }
        } else {
            // Horizontal wall
            if (_isHorizontal) {
                if (!_isSideways) {
                    for (var y = 0; y <= 1; y++) {
                        for (var x = 0; x < 10; x++) {
                            _tiles[x, y] = new Tile(x, y, Enums.GroundTileType.groundRock);
                        }
                    }
                } else {
                    for (var x = 0; x <= 1; x++) {
                        for (var y = 0; y < 10; y++) {
                            _tiles[x, y] = new Tile(x, y, Enums.GroundTileType.groundRock);
                        }
                    }
                }
            } // Vertical wall
            else {
                for (var y = 9; y >= 0; y--) {
                    for (var x = 0; x <= 1; x++) {
                        _tiles[x, y] = new Tile(x, y, Enums.GroundTileType.groundRock);
                    }
                }
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

