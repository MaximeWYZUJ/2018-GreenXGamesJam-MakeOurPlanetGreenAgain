using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour {

	private bool alternance;

	void Start () {
		GetComponent<SpriteRenderer> ().color = new Color (Random.value, Random.value, Random.value, 1f);
		alternance = true;

		//GameClock.OnClock += ChangeColor;
	}

	void ChangeColor() {
		Debug.Log ("on change de color");
		if (alternance) {
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
		} else {
			GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 0f);
		}

		alternance = !alternance;
	}

}
