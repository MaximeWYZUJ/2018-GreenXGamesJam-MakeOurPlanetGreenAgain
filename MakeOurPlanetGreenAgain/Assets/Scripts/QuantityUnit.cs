using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityUnit : GameElement {

	public const int qttMax = 3;
	public int qtt;	// passer en private une fois le chgt de sprite effectue


	void Start () {
		qtt = 1;
	}

	public void StackUnit() {
		if (qtt < qttMax) {
			qtt += 1;
			// Modifier le sprite
		}
	}

	public int Quantity { get { return qtt; } }
}
