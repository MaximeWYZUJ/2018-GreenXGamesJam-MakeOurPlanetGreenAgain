using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionAround : GameElement, Production {

	public GameObject prefabProduced;


	void Start() {
		GameClock.OnClock += Produce;
	}


	protected void ProduceResource() {
		ProduceAtCase (coo.indexR, coo.indexC + 1, res);
		ProduceAtCase (coo.indexR, coo.indexC - 1, res);
		ProduceAtCase (coo.indexR + 1, coo.indexC, res);
		ProduceAtCase (coo.indexR - 1, coo.indexC, res);
	}


	protected void ProduceGround() {
		ProduceAtCase (coo.indexR, coo.indexC + 1, gnd);
		ProduceAtCase (coo.indexR, coo.indexC - 1, gnd);
		ProduceAtCase (coo.indexR + 1, coo.indexC, gnd);
		ProduceAtCase (coo.indexR - 1, coo.indexC, gnd);
	}


	protected virtual void ProduceAtCase(int indexR, int indexC, GameMatrix mat) {
		if (gnd.IsAccessible (indexR, indexC)) {
			GameObject obj = mat.GetObject (indexR, indexC);

			if (obj != null) {
				if (string.Equals (obj.tag, prefabProduced.tag)) {
					// La ressource sur le terrain est la meme que la ressource produite par le terrain, donc on stack la nouvelle ressource sur celle deja presente
					obj.GetComponent<QuantityUnit> ().StackUnit ();
				} else if (string.Equals (obj.tag, "none")) {
					// On a une ressource nulle sur le terrain. On la remplace par une ressource produite.
					obj = InstantiateGameObject (coo.indexR, coo.indexC, prefabProduced);
				}
				// sinon, la ressource presente est differente donc on ne la remplace pas/ on ne la stack pas
			}
		}
	}


	public virtual void Produce() {
		if (prefabProduced.GetComponent<SwapObjects> () != null) {
			ProduceResource ();
		} else {
			ProduceGround ();
		}
	}


	public void StopProduction() {
		GameClock.OnClock -= Produce;
	}
}
