using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Coordinates))]
public class GameElement : MonoBehaviour {

	public Coordinates coo { get { return gameObject.GetComponent<Coordinates> (); } }
	public ResourceMatrix res { get { return GameObject.FindObjectOfType<ResourceMatrix> (); } }
	public GroundMatrix gnd { get { return GameObject.FindObjectOfType<GroundMatrix> (); } }
	public GameClock clk { get { return GameObject.FindObjectOfType<GameClock> (); } }

	public static GameObject InstantiateGameObject(int indexR, int indexC, GameObject prefab) {
		Vector3 center = new Vector3 (ResourceMatrix.tileSize * ResourceMatrix.nbCol / 2, ResourceMatrix.tileSize * ResourceMatrix.nbRow / 2, 0);

		GameObject obj = Instantiate (prefab, new Vector3 (indexC * ResourceMatrix.tileSize, indexR * ResourceMatrix.tileSize, 0) - center, Quaternion.identity);

		Coordinates coo = obj.GetComponent<Coordinates> ();
		if (coo != null) {
			// On initialise les coordonnees s'il y en a
			coo.indexR = indexR;
			coo.indexC = indexC;
		}

		SwapObjects swap = obj.GetComponent<SwapObjects> ();
		if (swap == null) {
			// C'est un terrain donc on le met en arriere plan
			obj.transform.position = new Vector3 (obj.transform.position.x, obj.transform.position.y, 1 + Random.value / 10);
			// On ajoute une valeur aleatoire a l'axe z pour eviter que les elements soient sur le meme plan, ce qui occasionne
			// des problemes d'affichage.

			if (Time.time > 1) { // bricolage, mais il y a un pb a l'initialisation
				if (GameObject.FindObjectOfType<GroundMatrix> () != null) {
					// C'est un terrain donc on maj la matrice des terrains
					GameObject.FindObjectOfType<GroundMatrix> ().SetObject (indexR, indexC, obj);
				}
			}
		} else {
			if (Time.time > 1) {
				if (GameObject.FindObjectOfType<ResourceMatrix> () != null) {
					// C'est une ressource donc on maj la matrice des ressources
					GameObject.FindObjectOfType<ResourceMatrix> ().SetObject (indexR, indexC, obj);
				}
			}
		}

		return obj;
	}
}
