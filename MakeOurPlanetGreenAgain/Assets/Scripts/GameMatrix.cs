using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMatrix : MonoBehaviour {

	public const float tileSize = 1;
	public const int nbRow = 7;
	public const int nbCol = 5;

	protected GameObject[,] matrix;

	public abstract GameObject[,] InitiateMatrix (string str);

	public GameObject GetObject(int indexR, int indexC) {
		return matrix [indexR, indexC];
	}

	public void SetObject(int indexR, int indexC, GameObject obj) {
		matrix [indexR, indexC] = obj;
	}

	public bool IsAccessible(int indexR, int indexC) {
		bool segFault = !(indexR < 0 || indexR >= GameMatrix.nbRow || indexC < 0 || indexC >= GameMatrix.nbCol);

		if (!segFault) {
			if (matrix [indexR, indexC].GetComponent<NonMoveable> () == null) {
				// La case est dans la matrice et on peut se deplacer dessus.
				return true;
			}
		}

		return false;
	}


}
