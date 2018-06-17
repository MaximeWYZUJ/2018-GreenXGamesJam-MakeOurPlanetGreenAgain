using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeResource : GameElement {

	private int happiness;
	private int hunger;
	private int health;
	private Queue<float> timeHit;
	private const int maxHit = 5;

	public GameObject resourceNull;
	public GameObject resourceWaste;

	public class ResourcesStat
	{
		// Stat plant
		public const int happinessPlant = 0;
		public const int hungerPlant = 2;
		public const int healthPlant = 2;

		// Stat radioactive plant
		public const int happinessRadioactivePlant = -3;
		public const int hungerRadioactivePlant = 1;
		public const int healthRadioactivePlant = -2;

		// Stat water
		public const int happinessWater = 1;
		public const int hungerWater = 0;
		public const int healthWater = 2;

		// Stat radioactive water
		public const int happinessRadioactiveWater = -2;
		public const int hungerRadioactiveWater = 0;
		public const int healthRadioactiveWater = -3;

		// Stat electricity
		public const int happinessElectricity = 5;
		public const int hungerElectricity = 0;
		public const int healthElectricity = 1;
	}


	void Start () {
		timeHit = new Queue<float> ();

		happiness = 0;
		hunger = 0;
		health = 0;
	}
	
	void Update () {
		GameObject resource = res.GetObject (coo.indexR, coo.indexC);
		if (string.Equals(res.GetObject(coo.indexR, coo.indexC).tag, "plant") ||
			string.Equals(res.GetObject(coo.indexR, coo.indexC).tag, "water") ||
			string.Equals(res.GetObject(coo.indexR, coo.indexC).tag, "electricity")) {
			Debug.Log ("ressource sur la ville; " + Input.touchCount);
			Consume ();

			// Une ressource est sur la ville


			/*if (Input.touches.Length > 0) {

				Touch t = Input.touches [0];
				Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint (new Vector3 (t.position.x, t.position.y, -Camera.main.transform.position.z));
				if (t.phase.Equals (TouchPhase.Began)/* && Vector3.Distance(transform.position, touchWorldPosition) < GameMatrix.tileSize) {
					Debug.Log ("truc");
					timeHit.Enqueue (Time.time);

					Debug.Log (timeHit.Count);
					if (timeHit.Count > maxHit) {
						timeHit.Dequeue ();
					}

					float mean = meanTimes ();
					Debug.Log (mean);

					if (mean < 0.7f) {
						// Le joueur a rapidement appuye sur l'ecran a proximite de la ville, on en deduit qu'il veut consommer la ressource.
						Consume();
					}
				}
			}*/
		}
	}


	public int Happiness { get { return happiness; } }
	public int Hunger { get { return hunger; } }
	public int Health { get { return health; } }


	private void Consume() {
		Debug.Log ("on consomme");
		GameObject resource = res.GetObject (coo.indexR, coo.indexC);
		if (string.Equals (resource.tag, "plant")) {
			int qtt = resource.GetComponent<QuantityUnit> ().Quantity;

			if (resource.GetComponent<Radioactive> () == null) {
				happiness += qtt*ResourcesStat.happinessPlant;
				hunger += qtt*ResourcesStat.hungerPlant;
				health += qtt*ResourcesStat.healthPlant;
			} else {
				happiness += qtt*ResourcesStat.happinessRadioactivePlant;
				hunger += qtt*ResourcesStat.hungerRadioactivePlant;
				health += qtt*ResourcesStat.healthRadioactivePlant;
			}

		} else if (string.Equals (resource.tag, "water")) {
			int qtt = resource.GetComponent<QuantityUnit> ().Quantity;

			if (resource.GetComponent<Radioactive> () == null) {
				happiness += qtt*ResourcesStat.happinessWater;
				hunger += qtt*ResourcesStat.hungerWater;
				health += qtt*ResourcesStat.healthWater;
			} else {
				happiness += qtt*ResourcesStat.happinessRadioactiveWater;
				hunger += qtt*ResourcesStat.hungerRadioactiveWater;
				health += qtt*ResourcesStat.healthRadioactiveWater;
			}

		} else if (string.Equals (resource.tag, "electricity")) {
			happiness += ResourcesStat.happinessElectricity;
			hunger += ResourcesStat.hungerElectricity;
			health += ResourcesStat.healthElectricity;

		}

		if (Random.value < 0.3f) {	// 30% de chances de générer un déchet
			if (string.Equals (res.GetObject (coo.indexR + 1, coo.indexC).tag, "none")) {
				Destroy (res.GetObject (coo.indexR + 1, coo.indexC));
				GameElement.InstantiateGameObject (coo.indexR + 1, coo.indexC, resourceWaste);
			} else if (string.Equals (res.GetObject (coo.indexR - 1, coo.indexC).tag, "none")) {
				Destroy (res.GetObject (coo.indexR - 1, coo.indexC));
				GameElement.InstantiateGameObject (coo.indexR - 1, coo.indexC, resourceWaste);
			} else if (string.Equals (res.GetObject (coo.indexR, coo.indexC + 1).tag, "none")) {
				Destroy (res.GetObject (coo.indexR, coo.indexC + 1));
				GameElement.InstantiateGameObject (coo.indexR, coo.indexC + 1, resourceWaste);
			} else {
				Destroy (res.GetObject (coo.indexR, coo.indexC - 1));
				GameElement.InstantiateGameObject (coo.indexR, coo.indexC - 1, resourceWaste);
			}
		}

		Destroy (res.GetObject (coo.indexR, coo.indexC));
		GameElement.InstantiateGameObject (coo.indexR, coo.indexC, resourceNull);

		Debug.Log ("hap : " + happiness + "; hung : " + hunger + "; heal : " + health);
	}


	private float meanTimes() {
		Queue<float> copy = timeHit;

		float sum = 0;
		int n=0;

		float t = copy.Dequeue();
		float tbis;

		while (copy.Count>0) {
			tbis = copy.Dequeue();
			sum += tbis-t;
			n += 1;

			t = tbis;
		}

		return sum/n;
	}
}
