using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Room {

    [Header("Generator configuration")]
	public Hangar hangar;
	public Valve valve;

	public int NbBattery{
		get { return nbBattery; }
		set { nbBattery = value; }
	}

	private bool isWaiting;
	private float timeToWait=5f;
	private int nbBattery=0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncDecRadioactivity", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting && boat.Radioactivity > 0)
			StartCoroutine (IncreaseNbBattery());
	}

	IEnumerator IncreaseNbBattery() {
		isWaiting = true;

		if ((nbBattery) < 5) {
			nbBattery++;
			hangar.spawnBattery();
		}

		yield return new WaitForSeconds (timeToWait);
		isWaiting = false;
	}

	//après changement de generatorPower -> changer timeToWait (de 5s à 0.5s) 
	void IncDecRadioactivity() {
		IncreaseRadioactivity ();
		DecreaseRadioactivity ();
		timeToWait=(1-boat.Radioactivity)*5;
	}

	void IncreaseRadioactivity() {
		if (valve.NbTour == 0)
			return;

		boat.Radioactivity += valve.NbTour * 0.01f;
	}

	void DecreaseRadioactivity() {
		if (boat.Submersion == 0)
			return;

		boat.Radioactivity -= boat.Submersion*0.2f; //EmptyTheBucket
	}

	public override void Setup() {
		timeToWait=5f;
		nbBattery=0;
		valve.NbTour=0;
	}
    
	public override void ResetRoom() {
		CancelInvoke ("IncreaseRadioactivity");
		StopAllCoroutines ();
	}

    public override void EnterRoom()
    {
        AudioManager.singleton.PlayBgs(roomBgs);
    }
}
