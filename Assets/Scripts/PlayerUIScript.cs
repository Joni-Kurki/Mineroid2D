using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour {

    public Text miningPowerText;
    CharMineScript cms;

	// Use this for initialization
	void Start () {
        cms = gameObject.GetComponentInChildren<CharMineScript>();
	}
	
	// Update is called once per frame
	void Update () {
        miningPowerText.text = cms.miningPower.ToString();
    }
}
