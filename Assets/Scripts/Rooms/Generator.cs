using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Room {

	public BoatManager boat;
	public Hangar hangar;

	public int NbBattery{
		get { return nbBattery; }
		set { nbBattery = value; }
	}

	private bool isWaiting;
	private float timeToWait=5f;
	private int nbBattery=0;
	private float generatorPower=0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseRadioactivity", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting)
			StartCoroutine (IncreaseNbBattery());
	}

	IEnumerator IncreaseNbBattery() {
		isWaiting = true;

		Debug.Log ("Spawn battery");

		if (nbBattery < 5) {
			nbBattery++;
			hangar.spawnBattery();
		}

		yield return new WaitForSeconds (timeToWait);
		isWaiting = false;
	}

	//après changement de generatorPower -> changer timeToWait (de 5s à 0.5s) 

	void IncreaseRadioactivity() {
		if (generatorPower == 0)
			return;

		boat.Radioactivity += generatorPower * 0.01f;
	}

	void DecreaseRadioactivity() {
		if (boat.Submersion == 0)
			return;

		boat.Radioactivity = boat.Radioactivity - 0.2f; //EmptyTheBucket
	}

	public void SetupGenerator() {
		timeToWait=5f;
		nbBattery=0;
		generatorPower=0f;
	}

	public void StopGenerator() {
		CancelInvoke ("IncreaseRadioactivity");
		StopAllCoroutines ();
	}


}
