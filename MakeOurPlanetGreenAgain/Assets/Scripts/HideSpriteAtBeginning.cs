using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpriteAtBeginning : MonoBehaviour {


	void Start () {
		GetComponent<SpriteRenderer> ().enabled = false;
	}
}
