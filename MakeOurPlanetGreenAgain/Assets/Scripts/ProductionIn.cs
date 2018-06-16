using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionIn : GameElement, Production {

	public GameObject prefabResource;

	void Start() {
		GameClock.OnClock += Produce;
	}

	public void Produce() {
		GameObject obj = res.GetObject (coo.indexR, coo.indexC);
		if (obj != null) {
			if (string.Equals (obj.tag, prefabResource.tag)/* && !string.Equals(obj.tag, "radioactivityWaste") && !string.Equals(obj.tag, "electricity")*/) {
				// La ressource sur le terrain est la meme que la ressource produite par le terrain, donc on stack la nouvelle ressource sur celle deja presente
				obj.GetComponent<QuantityUnit> ().StackUnit ();
			} else if (string.Equals (obj.tag, "none")) {
				// On a une ressource nulle sur le terrain. On la remplace par une ressource produite.
				obj = InstantiateGameObject (coo.indexR, coo.indexC, prefabResource);
			}
			// sinon, la ressource presente est differente donc on ne la remplace pas/ on ne la stack pas
		}
	}

	public void StopProduction() {
		GameClock.OnClock -= Produce;
	}
}
