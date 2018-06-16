using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ResourceMatrix : GameMatrix {

	public TextAsset lvlResource;

	[Header("Differentes ressources")]
	public GameObject resPlant;
	public GameObject resWater;
	public GameObject resWood;
	public GameObject resBottle;
	public GameObject resElectricity;
	public GameObject resPollution;
	public GameObject resRadioactivity;
	public GameObject resNull;

	void Start() {
		matrix = InitiateMatrix (lvlResource.text);
	}

	public override GameObject[,] InitiateMatrix(string str) {
		GameObject[,] mat = new GameObject[nbRow, nbCol];
		Vector3 center = new Vector3 (ResourceMatrix.tileSize * ResourceMatrix.nbCol / 2, ResourceMatrix.tileSize * ResourceMatrix.nbRow / 2, 0);

		for (int i = 0; i < GameMatrix.nbRow; i++) {
			for (int j = 0; j < GameMatrix.nbCol; j++) {
				if (char.Equals (str [i * nbCol + j], 'p')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resPlant);
				} else if (char.Equals (str [i * nbCol + j], 'w')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resWater);
				} else if (char.Equals (str [i * nbCol + j], 'o')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resWood);
				} else if (char.Equals (str [i * nbCol + j], 'b')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resBottle);
				} else if (char.Equals (str [i * nbCol + j], 'e')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resElectricity);
				} else if (char.Equals (str [i * nbCol + j], 'u')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resPollution);
				} else if (char.Equals (str [i * nbCol + j], 'r')) {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resRadioactivity);
				} else {
					mat [i, j] = GameElement.InstantiateGameObject (i, j, resNull);
				}
			}
		}

		return mat;
	}


	public void SwapElements(int indexR1, int indexC1, int indexR2, int indexC2) {
		GameObject obj = matrix [indexR1, indexC1];
		matrix [indexR1, indexC1] = matrix [indexR2, indexC2];
		matrix [indexR2, indexC2] = obj;
	}
}
