
public class Enums {
    public enum GroundTileType {
        groundDirt = 0,
        groundRock = 1,
        groundFrozenDirt = 2,
        groundGrass = 3,
        groundRedDirt = 4,
    }

    public enum MapSize {
        EXTRA_SMALL = 0,
        SMALL = 1,
        MEDIUM = 2,
    }

    public enum MapOrientation {
        Horizontal = 0,
        Vertical = 1,
    }

    public enum MapChunkBiodome {
        warm = 0,
        cold = 1,
        alien = 2,
        fossil = 3,
        random = 4,
    }

    public enum MapChunkWealth {
        poorAsFuck = 0,
        poor = 1,
        normal = 2,
        high = 3,
        wealthy = 4,
    }

    public enum AtlasTileset {
        dirt = 0,
        cold = 1,
    }
}