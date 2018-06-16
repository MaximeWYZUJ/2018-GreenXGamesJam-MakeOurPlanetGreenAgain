using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour {

	public delegate void ClockTic();
	public static event ClockTic OnClock;


	void Start () {
		StartCoroutine (UpdateCoroutine());
	}


	IEnumerator UpdateCoroutine() {
		while (true) {
			Debug.Log ("tic");
			if (OnClock != null) {
				OnClock ();
			}
			yield return new WaitForSecondsRealtime (5f);
		}
	}
}
