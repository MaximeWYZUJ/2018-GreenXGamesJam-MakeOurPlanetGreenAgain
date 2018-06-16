using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionGround : GameElement {

	public GameObject infestedGround;

	void Start() {
		GameClock.OnClock += Infection;
	}

	public void Infection() {
		GameObject ground = gnd.GetObject (coo.indexR, coo.indexC);

		if (ground != null) {
			if (!string.Equals (ground.tag, "infestedGnd")) {
				
				if (ground.GetComponent<Production> () != null) {
					// Si le sol produisait quelque chose, on fait en sorte qu'il ne produit plus rien desormais.
					// On supprime son handler de l'event OnClock
					ground.GetComponent<Production> ().StopProduction ();
				}

				// On remplace l'ancien sol par un sol contamine.
				Destroy (ground);
				GameObject newGround = GameElement.InstantiateGameObject (coo.indexR, coo.indexC, infestedGround);
				gnd.SetObject (coo.indexR, coo.indexC, newGround);
			}
		}
	}
}
