using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : Room {

	public BoatManager boat;
	public Generator generator;

	private int loadedBattery=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadDrone() {
		//drag & drop des battery sur le drone
		//Increase de loadedBattery
		//Decrease de generator.NbBattery
	}

	void SendDrone() {
		generator.NbBattery = generator.NbBattery - 1; //remplacer 1 par nb de batteries chargées
		//Delay 5sec puis call IncreaseElecricityRequest et boat.score=+100

	}

	void IncreaseElectricityRequest() {
		boat.ElectricityRequest = boat.ElectricityRequest + 0.2f;
	}

	public void SetupHangar() {
		loadedBattery=0;
	}

	public void StopHangar() {
	}


}
