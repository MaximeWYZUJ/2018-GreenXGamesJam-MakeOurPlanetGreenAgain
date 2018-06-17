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
		bool waitFirst = true;
		while (true) {
			if (waitFirst) {
				waitFirst = false;
				yield return new WaitForSecondsRealtime (5f);
			} else {
				Debug.Log ("tic");
				if (OnClock != null) {
					OnClock ();
				}
				yield return new WaitForSecondsRealtime (5f);
			}
		}
	}
}
