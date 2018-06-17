using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Objective : MonoBehaviour {

	public enum DiffObjectives { HEALTH, HUNGER, HAPPYNESS};

	public Scene nextScene;
	public DiffObjectives objectiveType;
	public int objectiveAmount;

	private Text txtObject;
	private ConsumeResource cons;
	private int objectiveState;

	void Start () {
		cons = GetComponent<ConsumeResource> ();
		txtObject = GameObject.Find ("TextObjective").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (objectiveType) {
		case DiffObjectives.HAPPYNESS:
			{
				objectiveState = cons.Happiness;
				break;
			}
		case DiffObjectives.HEALTH:
			{
				objectiveState = cons.Health;
				break;
			}
		case DiffObjectives.HUNGER:
			{
				objectiveState = cons.Hunger;
				break;
			}
		}

		txtObject.text = "Food : " + objectiveState + " / " + objectiveAmount;

		if (objectiveState >= objectiveAmount) {
			SceneManager.LoadScene (nextScene.name);
		}
	}
}


