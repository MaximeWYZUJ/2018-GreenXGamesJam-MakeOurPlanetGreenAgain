using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjects : GameElement {

	private AudioSource asrc;
	private bool selected;

	public AudioClip snd;

	void Start () {
		selected = false;
		asrc = gameObject.AddComponent<AudioSource> ();
		asrc.clip = snd;
	}


	private void move(int newIndexR, int newIndexC) {
		// On vérifie que la nouvelle case existe (pas en dehors de la matrice)
		if (newIndexR >= 0 && newIndexR <= ResourceMatrix.nbRow - 1 && newIndexC >= 0 && newIndexC <= ResourceMatrix.nbCol - 1) {
			// S'il y a un objet a cette nouvelle case, on swap les ressources
			if (res.GetObject (newIndexR, newIndexC) != null) {
				asrc.Play ();
				Swap (res.GetObject (newIndexR, newIndexC));
			}
			else {
				Debug.Log ("Pas de ressource a echanger. Besoin de remplir la case vide par une ressource nulle.");
			}

		}
	}


	/* Echange les places de deux objets.
	 * PREPOSITION : les deux objets existent et sont dans les limites de la matrice
	 */
	private void Swap(GameObject otherObject) {
		Debug.Log ("on swap");

		// Maj des positions dans le worldspace
		Vector3 oldPosition = transform.position;
		transform.position = otherObject.transform.position;
		otherObject.transform.position = oldPosition;

		// Maj des coordonnees
		int oldIndexR = coo.indexR;
		int oldIndexC = coo.indexC;
		coo.indexC = otherObject.GetComponent<Coordinates> ().indexC;
		coo.indexR = otherObject.GetComponent<Coordinates> ().indexR;

		otherObject.GetComponent<Coordinates> ().indexC = oldIndexC;
		otherObject.GetComponent<Coordinates> ().indexR = oldIndexR;

		// Maj des objets dans la matrice de ressources
		res.SwapElements(oldIndexR, oldIndexC, coo.indexR, coo.indexC);
	}
		

	
	void Update () {
		Touch[] touch = Input.touches;

		if (touch.Length > 0) {
			Touch t = touch [0];
			Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (t.position.x, t.position.y, -Camera.main.transform.position.z));

			// On sélectionne le premier objet qu'on veut swap
			if (t.phase == TouchPhase.Began && Vector3.Distance (transform.position, touchWorldPosition) < ResourceMatrix.tileSize/2) {
				selected = true;
			} else if (t.phase == TouchPhase.Ended) {
				if (selected) {
					// On cherche quelle est la direction choisie pour swaper (de quel point cardinal le doigt est le plus proche relativement à l'objet)
					Vector3 cardN = transform.position + new Vector3 (0, ResourceMatrix.tileSize/4, 0);
					Vector3 cardS = transform.position + new Vector3 (0, -ResourceMatrix.tileSize/4, 0);
					Vector3 cardE = transform.position + new Vector3 (ResourceMatrix.tileSize/4, 0, 0);
					Vector3 cardW = transform.position + new Vector3 (-ResourceMatrix.tileSize/4, 0, 0);

					float distanceN = Vector3.Distance (touchWorldPosition, cardN);
					float distanceS = Vector3.Distance (touchWorldPosition, cardS);
					float distanceE = Vector3.Distance (touchWorldPosition, cardE);
					float distanceW = Vector3.Distance (touchWorldPosition, cardW);

					float minDistance = Mathf.Min (new float[] { distanceN, distanceS, distanceE, distanceW });

					if (minDistance > ResourceMatrix.tileSize / 2) {
						if (Mathf.Abs (distanceN - minDistance) < 0.000001f) {
							move (coo.indexR + 1, coo.indexC);
						} else if (Mathf.Abs (distanceS - minDistance) < 0.000001f) {
							move (coo.indexR - 1, coo.indexC);
						} else if (Mathf.Abs (distanceE - minDistance) < 0.000001f) {
							move (coo.indexR, coo.indexC + 1);
						} else if (Mathf.Abs (distanceW - minDistance) < 0.000001f) {
							move (coo.indexR, coo.indexC - 1);
						}
					}

					selected = false;
				}
			}
		}
			
	}
}
