using UnityEngine;

public class TileData {

    int _chunkX;
    int _chunkY;
    int _chunkW;
    int _chunkH;

    TileType[,] tiles;

    public TileData(int x, int y, int w, int h) {
        _chunkX = x;
        _chunkY = y;
        _chunkW = w;
        _chunkH = h;

        tiles = new TileType[_chunkW, _chunkH];

        initTiles();
    }

    void initTiles() {
        for (var y = 0; y < _chunkH; y++) {
            for (var x = 0; x < _chunkW; x++) {
                bool isGrounded = true;
                if (y >= 5) {
                    isGrounded = false;
                }
                tiles[x, y] = new TileType(isGrounded, 0, y);
            }
        }
    }

    public TileType getTileAt(int x, int y) {
        return tiles[x, y];
    }

}

public class TileType {

    public float _tileHP;
    int _depth;
    public bool _isGroundTile;
    public TileTypes _tileType;

    public enum TileTypes {
        obstacle = 0,
        ground = 1,
    }

    public TileType(bool isGroundTile, int chunkY, int tileH) {
        _depth = chunkY + tileH;
        _isGroundTile = isGroundTile;

        _tileType = isGroundTile ? TileTypes.ground : TileTypes.obstacle;

        float ran = Random.Range(0, 100);

        if(ran > 85) {
            _tileType = TileTypes.obstacle;
        } else {
            _tileType = TileTypes.ground;
        }

        switch (_tileType) {
            case TileTypes.obstacle:
            case TileTypes.ground:
                break;
        }
    }

    public TileTypes getTile() {
        return _tileType;
    }

    public float getTileHp() {
        return _depth * _tileHP;
    }

}

public class TileContent{

    TileContent _tileContent;

    public enum Content {
        mineral = 1,
        gem = 2,
    }

}
