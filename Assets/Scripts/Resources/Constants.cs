
public class Constants {

	public class General {

    }

    public class Loot_Gems {
        public const int RUBY_INDEX = 0;
        public const int SAPPHIRE_INDEX = 1;
        public const int EMERALD_INDEX = 2;
        public const int TOPAZ_INDEX = 3;

        public const string RUBY_NAME = "loot_ruby(Clone)";
        public const string SAPPHIRE_NAME = "loot_sapphire(Clone)";
        public const string EMERALD_NAME = "loot_emerald(Clone)";
        public const string TOPAZ_NAME = "loot_topaz(Clone)";

        public const string GENERIC_GEM_NAME = "loot_gem(Clone)";
    }

    public class MapPropertiesCount {
        public const int NUMBER_OF_MAPSIZES = 3;
        public const int NUMBER_OF_ORIENTATIONS = 2;
    }

    public class IntMapSize {
        public const int EXTRA_SMALL = 3;
        public const int SMALL = 6;
        public const int MEDIUM = 10;
    }

    public class IntMapTiers {
        public const int MIN_TIER = 1;
        public const int MAX_TIER = 5;
    }

    public class Loot_Pooler {
        public const int MAX_EXTRA_SMALL = 100;
    }

    public class Loot_Manager {
        public const float BASE_LOOT_CHANCE = 5f;
        public const int MAX_NUMBER_OF_TIERS = 4;
    }

    public class Chunk {
        public const int CHUNK_X = 10;
        public const int CHUNK_Y = 10;
        public const int CHUNK_OFFSET = 10;
    }

    public class TileConstants {
        public const float TILE_DIRT_MULTIPLIER = 1.15f;
        public const int TILE_DIRT_BASE_HP = 20;

        public const float TILE_GRASS_MULTIPLIER = 1f;
        public const int TILE_GRASS_BASE_HP = 15;

        public class TileDirtAtlas {
            public const int NUMBER_OF_NORMAL_VARS = 3;
            public static readonly int [] NORMAL_VAR_INDEX = { 0, 2, 3 };

            public const int DIRT_NORMAL_VAR_0 = 0;
            public const int DIRT_TOP_MOSS_VAR_0 = 1;
            public const int DIRT_NORMAL_VAR_1 = 2;
            public const int DIRT_NORMAL_VAR_2 = 3;
        }

        public class TileColdAtlas {
            public const int NUMBER_OF_NORMAL_VARS = 3;
            public static readonly int[] NORMAL_VAR_INDEX = { 0, 2, 3 };

            public const int COLD_NORMAL_VAR_0 = 0;
            public const int COLD_TOP_ICE_VAR_0 = 1;
            public const int COLD_NORMAL_VAR_1 = 2;
            public const int COLD_NORMAL_VAR_2 = 3;
        }
    }
}
