
public class LootManagerScript {

    float [] _lootChances;

	public LootManagerScript() {
        //_lootChances = Constants.Loot_Manager.BASE_LOOT_CHANCE; // * loot multiplier
        _lootChances = new float[Constants.Loot_Manager.MAX_NUMBER_OF_TIERS];
    }

    // Laskee loot chanssit tierien mukaan
    void SetLootChances(int tiers) {
        switch (tiers) {
            case 1:
                _lootChances[0] = 100;
                _lootChances[1] = 0;
                _lootChances[2] = 0;
                _lootChances[3] = 0;
                break;
            case 2:
                _lootChances[0] = 75;
                _lootChances[1] = 25;
                _lootChances[2] = 0;
                _lootChances[3] = 0;
                break;
            case 3:
                _lootChances[0] = 60;
                _lootChances[1] = 30;
                _lootChances[2] = 10;
                _lootChances[3] = 0;
                break;
            case 4:
                _lootChances[0] = 50;
                _lootChances[1] = 25;
                _lootChances[2] = 17;
                _lootChances[3] = 8;
                break;
        }
    }

    public float [] GetLootTable(int numberOfTiers) {
        SetLootChances(numberOfTiers);
        return _lootChances;
    }

}
