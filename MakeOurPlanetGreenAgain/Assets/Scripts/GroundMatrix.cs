using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GroundMatrix : GameMatrix {

	[Header("Niveaux de jeu")]
	public TextAsset lvlGround;

	[Header("Terrains possibles")]
	public GameObject gndForest;
	public GameObject gndPlain;
	public GameObject gndRiver;
	public GameObject gndCity;
	public GameObject gndInfested;
	public GameObject gndEnergyCentral;


	void Start() {
		matrix = InitiateMatrix (lvlGround.text);
	}

	public override GameObject[,] InitiateMatrix(string str) {
		GameObject[,] mat = new GameObject[GameMatrix.nbRow, GameMatrix.nbCol];

		for (int i = 0; i < GameMatrix.nbRow; i++) {
			for (int j = 0; j < GameMatrix.nbCol; j++) {
				if (char.Equals (str [i * nbCol + j], 'f')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndForest);
				} else if (char.Equals (str [i * nbCol + j], 'p')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndPlain);
				} else if (char.Equals (str [i * nbCol + j], 'i')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndInfested);
				} else if (char.Equals (str [i * nbCol + j], 'c')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndCity);
				} else if (char.Equals (str [i * nbCol + j], 'r')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndRiver);
				} else if (char.Equals (str [i * nbCol + j], 'e')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, gndEnergyCentral);
				} else {
					Debug.Log ("ne fait rien, bizarre");
				}
			}
		}

		return mat;
	}
}
