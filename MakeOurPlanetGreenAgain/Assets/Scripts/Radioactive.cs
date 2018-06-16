using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radioactive : GameElement {

	void Start() {
		SpriteRenderer[] renderer = GetComponentsInChildren<SpriteRenderer> ();
		if (renderer.Length == 2) {
			renderer [1].enabled = true;
			renderer [0].enabled = true;
		}
	}
}
