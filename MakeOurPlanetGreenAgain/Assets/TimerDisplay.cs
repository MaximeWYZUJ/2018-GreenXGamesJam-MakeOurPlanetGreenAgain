using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

	private Text txt;

	void Start () {
		txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = (5 - (Mathf.Round (Time.time) % GameClock.delay)).ToString();
	}
}
