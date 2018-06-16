using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionAround : GameElement, Production {

	public GameObject prefabResource;

	void Start() {
		GameClock.OnClock += Produire;
	}

	public void Produire() {
		int random = Random.Range (0, 4);

		// On produit une ressource aléatoirement sur une case autour de nous (haut, bas, gauche ou droite)
		/*switch (random) {
		case 0:	// haut					PAS A JOUR !!!!!
			{
				if (res.IsAccessible (coo.indexR + 1, coo.indexC) && gnd.IsAccessible (coo.indexR + 1, coo.indexC)) {
					res.SetObject (coo.indexR + 1, coo.indexC, InstantiateGameObject (coo.indexR + 1, coo.indexC, prefabResource));
				} else {
					Produire (); // la case n'est pas accessible donc on reessaie jusqu'a tomber sur une case accessible
				}
				break;
			}
		case 1 : // bas
			{
				if (res.IsAccessible (coo.indexR - 1, coo.indexC) && gnd.IsAccessible (coo.indexR - 1, coo.indexC)) {
					res.SetObject (coo.indexR - 1, coo.indexC, InstantiateGameObject (coo.indexR - 1, coo.indexC, prefabResource));
				} else {
					Produire (); // la case n'est pas accessible donc on reessaie jusqu'a tomber sur une case accessible
				}
				break;
			}
		case 2 : // gauche
			{
				if (res.IsAccessible (coo.indexR, coo.indexC - 1) && gnd.IsAccessible (coo.indexR, coo.indexC - 1)) {
					res.SetObject (coo.indexR, coo.indexC - 1, InstantiateGameObject (coo.indexR, coo.indexC - 1, prefabResource));
				} else {
					Produire (); // la case n'est pas accessible donc on reessaie jusqu'a tomber sur une case accessible
				}
				break;
			}
		case 3 : // droite
			{
				if (res.IsAccessible (coo.indexR, coo.indexC + 1) && gnd.IsAccessible (coo.indexR, coo.indexC + 1)) {
					res.SetObject (coo.indexR, coo.indexC + 1, InstantiateGameObject (coo.indexR, coo.indexC + 1, prefabResource));
				} else {
					Produire (); // la case n'est pas accessible donc on reessaie jusqu'a tomber sur une case accessible
				}
				break;
			}
		}*/
	}

	public void StopProduction() {
		GameClock.OnClock -= Produire;
	}
}
