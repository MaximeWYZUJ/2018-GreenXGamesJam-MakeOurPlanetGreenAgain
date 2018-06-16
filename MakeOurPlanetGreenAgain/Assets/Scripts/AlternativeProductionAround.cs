using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ProductionAround))]
public class AlternativeProductionAround : MonoBehaviour, AlternativeProduction {

	public GameObject obj1;
	public GameObject obj2;

	private bool alternate;

	void Start () {
		alternate = true;
		GameClock.OnClock += SwitchProduction;
	}

	public void SwitchProduction() {
		if (alternate) {
			GetComponent<ProductionAround> ().prefabProduced = obj1;
		} else {
			GetComponent<ProductionAround> ().prefabProduced = obj2;
		}
		alternate = !alternate;
	}
}
