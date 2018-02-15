using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileControllerScript : MonoBehaviour {

    public GameObject smallTile;

    public TileType tile;

    public float currentHp;
    public bool isGroundTile;
    public int y;
    public int h;
    public TileType.TileTypes tilesType;

    GameObject player;
    CharMineScript cms;
    GameObject goLoot;
    LootPoolerScript loot;

    int _lootInventory;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        cms = player.GetComponentInChildren<CharMineScript>();
        goLoot = GameObject.FindGameObjectWithTag("LootPooler");
        loot = goLoot.GetComponent<LootPoolerScript>();

        _lootInventory = 0;
    }

    public void initTile() {
        currentHp = tile.getTileHp();
        isGroundTile = tile._isGroundTile;
        tilesType = tile._tileType;
    }

    public void TakeDamage(float value) {
        currentHp -= value;
    }
	
	// Update is called once per frame
	void Update () {
		if(currentHp <= 0) {
            gameObject.SetActive(false);
        }
    }

    void OnDisable() {
        // random määrä pienia paloja, mitkä tuhotaan sitten
        int random = Random.Range(5, 12);

        for(var i=0; i < random; i++) {
            var go = Instantiate(smallTile, transform.position, Quaternion.identity, transform.parent);
        }

        float randomRoll = Random.Range(0f, 100f);
        //Debug.Log("Roll: "+randomRoll);
        LootManagerScript lms = new LootManagerScript();
        // TODO: tää tulis level managerilta
        var lootChances = lms.GetLootTable(4);
        for (var i = 0; i < lootChances.Length; i++) {
            if (randomRoll >= lootChances[i]) {
                //Debug.Log("Tier: " + i);
                Invoke("SpawnSomething", .3f);
                _lootInventory = i;
                break;
            }
        }
    }

    void SpawnSomething() {
        var gemToUse = -1;
        //Debug.Log("SpawnSomething");
        switch (_lootInventory) {
            case 0:
                gemToUse = Constants.Loot_Gems.RUBY_INDEX;
                break;
            case 1:
                gemToUse = Constants.Loot_Gems.SAPPHIRE_INDEX;
                break;
            case 2:
                gemToUse = Constants.Loot_Gems.EMERALD_INDEX;
                break;
            case 3:
                gemToUse = Constants.Loot_Gems.TOPAZ_INDEX;
                break;
        }
        if (gemToUse != -1) {
            //Debug.Log("Using gem tier: " + gemToUse);
            loot.ActivateGemFromPooler(gemToUse, transform.position);
        }
    }

    void OnMouseDown() {
        if(Vector2.Distance(gameObject.transform.position, player.transform.position) < 1.5f)
            cms.SetColObject(gameObject);
    }

}
