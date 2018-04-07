using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPoolerScript : MonoBehaviour {

    public int _maxNumberOfObjects;
    public GameObject [] prefabArray;
    public GameObject gemPrefab;
    public List<GameObject> goList;
    //int nextFreeIndex = 0;
    // ranget vapaille pooler objekteille
    //public int[] lootRanges;
    // loot indeksit
    //public int[] lootIndecies;

	// Use this for initialization
	void Start () {
        goList = new List<GameObject>();

        //InitPooler(0, 3);
        InitGemPooler(0, 3);
    }
	
    public void InitGemPooler(int mapSize, int mapTier = 0) {
        var prefabCount = GetHowManyGemPrefabAreUsed(mapTier);

        switch (mapSize) {
            case Constants.MapSizeConstants.EXTRA_SMALL:
                _maxNumberOfObjects = Constants.Loot_Pooler.MAX_EXTRA_SMALL;

                for (var i = 0; i < _maxNumberOfObjects; i++) {
                    var go = Instantiate(gemPrefab, transform.position, gemPrefab.transform.rotation, transform.parent);
                    goList.Add(go);
                    go.SetActive(false);
                }

                break;
        }
    }

    public void InitPooler(int mapSize, int mapTier = 0) {
        var prefabCount = GetHowManyGemPrefabAreUsed(mapTier);
        //lootRanges = new int[prefabCount * 2];
        //lootIndecies = new int[prefabCount];

        switch (mapSize) {
            case Constants.MapSizeConstants.EXTRA_SMALL:
                _maxNumberOfObjects = Constants.Loot_Pooler.MAX_EXTRA_SMALL;

                for (var j = 0; j < prefabCount; j++) {
                    GameObject prefabToInstantiate = prefabArray[j];
                    for (var i = 0; i < _maxNumberOfObjects / prefabCount; i++) {
                        var go = Instantiate(prefabToInstantiate, transform.position, prefabToInstantiate.transform.rotation, transform.parent);
                        goList.Add(go);
                        go.SetActive(false);
                    }
                }
                break;
        }

        //// 0 indeksit
        //for (var lR = 0; lR < prefabCount * 2; lR += 2) {
        //    lootRanges[lR] = 0;
        //}
        //// max indeksit
        //for (var lR = 1; lR < prefabCount * 2; lR += 2) {
        //    lootRanges[lR] = _maxNumberOfObjects / prefabCount;
        //}
        //for(var i=0; i < lootIndecies.Length; i++) {
        //    lootIndecies[i] = lootRanges[(prefabCount * i)];
        //}
    }

    // Palauttaa montaa eri prefabi käytetään
    int GetHowManyGemPrefabAreUsed(int mapTier) {
        switch(mapTier) {
            case 0:
                return 1;
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 4;
        }

        return 0;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateGemFromPooler(int gemIndex, Vector3 position) {
        if (goList != null) {
            foreach (GameObject go in goList) {
                if (go != null) {
                    if (!go.activeSelf && go.name == Constants.Loot_Gems.GENERIC_GEM_NAME) {
                        go.SetActive(true);
                        LootPickupScript lps = go.GetComponent<LootPickupScript>();
                        Loot_GemScript lgs = go.GetComponent<Loot_GemScript>();
                        
                        lps.ResetPickup();
                        lgs.SetSprite(gemIndex);

                        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

                        var randomForceMult = Random.Range(0f, 2f);
                        rb.velocity = Random.onUnitSphere * randomForceMult;

                        go.transform.position = position;
                        
                        break;
                    }
                }
            }
        }
    }

    // Aktivoi poolerista halutun objektin, haluttuun paikkaan kentässä
    public void ActivateFromPooler(int whichLootIndex, Vector3 position) {

        if (goList != null) {
            foreach (GameObject go in goList) {
                if (go != null) {
                    if (!go.activeSelf && go.name == GetLootsNameByIndex(whichLootIndex)) {
                        LootPickupScript lps = go.GetComponent<LootPickupScript>();
                        lps.ResetPickup();
                        go.SetActive(true);
                        go.transform.Translate(position);

                        Debug.Log("Activating "+whichLootIndex + " @" +go.transform.position);

                        break;
                    }
                }
            }
        }
    }

    // Palauttaa rangella olevat Lootable GameObjectit
    public List<GameObject> FindLootsThatPlayerCanPickup(Vector3 playerPos, float distanceRange) {

        List<GameObject> closeGoList = new List<GameObject>();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Lootable");

        for (var i = 0; i < gos.Length; i++) {
            if(Vector2.Distance(gos[i].transform.position, playerPos) <= distanceRange) {
                closeGoList.Add(gos[i]);
            }
        }
        return closeGoList;
    }

    // Palauttaa lootin nimen stringinä
    string GetLootsNameByIndex(int index) {
        switch (index) {
            case 0:
                return Constants.Loot_Gems.RUBY_NAME;
            case 1:
                return Constants.Loot_Gems.SAPPHIRE_NAME;
            case 2:
                return Constants.Loot_Gems.EMERALD_NAME;
            case 3:
                return Constants.Loot_Gems.TOPAZ_NAME;
        }

        return "";
    }

    // Mitä indeksia muutetaan
    //void MoveIndex(int whichIndex) {
    //    Debug.Log("Index " + whichIndex);
    //    if(lootIndecies[whichIndex] < lootRanges[whichIndex + 1]) {
    //        Debug.Log(lootIndecies[whichIndex] + " -> " + (lootIndecies[whichIndex] +1));
    //        lootIndecies[whichIndex]++;
    //    }
    //}


}
