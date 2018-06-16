using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : GameElement {

	public int indexR;
	public int indexC;

	private Vector3 center;

	void Start() {
		center = new Vector3 (ResourceMatrix.tileSize * ResourceMatrix.nbCol / 2, ResourceMatrix.tileSize * ResourceMatrix.nbRow / 2, 0);
	}

	void Update() {
		bool syncV = Mathf.Abs (transform.position.y - (indexR * ResourceMatrix.tileSize - center.y)) < 0.0001f;
		bool syncH = Mathf.Abs (transform.position.x - (indexC * ResourceMatrix.tileSize - center.x)) < 0.0001f;

		if (!syncV) {
			Debug.Log ("pb synchro V");
		}
		if (!syncH) {
			Debug.Log ("pb synchro H");
		}
	}
}
