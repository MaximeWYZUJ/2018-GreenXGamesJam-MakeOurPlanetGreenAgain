using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ProductionIn))]
public class AlternativeProductionIn : MonoBehaviour, AlternativeProduction {

	public GameObject obj1;
	public GameObject obj2;

	private bool alternate;

	void Start () {
		alternate = true;
		GameClock.OnClock += SwitchProduction;
	}

	public void SwitchProduction() {
		if (alternate) {
			GetComponent<ProductionIn> ().prefabResource = obj1;
		} else {
			GetComponent<ProductionIn> ().prefabResource = obj2;
		}
		alternate = !alternate;
	}
}
