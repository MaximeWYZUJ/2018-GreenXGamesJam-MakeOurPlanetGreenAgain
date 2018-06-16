using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectAround : ProductionAround {


	void Start () {
		GameClock.OnClock += Produce;
		//prefabProduced = (GameObject)Resources.Load ("RadioactiveEffect");
	}
	

	protected override void ProduceAtCase(int indexR, int indexC, GameMatrix mat) {
		if (gnd.IsAccessible (indexR, indexC)) {
			GameObject obj = res.GetObject (indexR, indexC);

			if (obj != null) {
				if (!string.Equals (obj.tag, "none") && obj.GetComponent<Radioactive>() == null) {
					obj.AddComponent<Radioactive> ();
				}
			}
		}
	}


	public override void Produce() {
		// Diagonales
		ProduceAtCase (coo.indexR + 1, coo.indexC + 1, res);
		ProduceAtCase (coo.indexR - 1, coo.indexC + 1, res);
		ProduceAtCase (coo.indexR + 1, coo.indexC - 1, res);
		ProduceAtCase (coo.indexR - 1, coo.indexC - 1, res);
		// Points cardinaux
		ProduceAtCase (coo.indexR, coo.indexC + 1, res);
		ProduceAtCase (coo.indexR, coo.indexC - 1, res);
		ProduceAtCase (coo.indexR + 1, coo.indexC, res);
		ProduceAtCase (coo.indexR - 1, coo.indexC, res);
	}
}
