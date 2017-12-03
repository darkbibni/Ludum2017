using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : Room {

	public BoatManager boat;
	public Generator generator;
	public Drone d;

	public Transform posDrone;
	public Transform posBattery;
	public GameObject batteryPrefab;
	public GameObject dronePrefab;

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

	void sendDrone() {
		generator.NbBattery = generator.NbBattery - 1; //remplacer 1 par nb de batteries chargées
		//Delay 5sec puis call IncreaseElecricityRequest et boat.score=+100

	}

	public void spawnDrone(){
		GameObject droneSpawned = Instantiate (dronePrefab, posDrone.position, posDrone.rotation);
		Drone d = droneSpawned.GetComponent<Drone> ();
		d.hangar = this;
	}

	public void spawnBattery(){
		GameObject batterySpawned = Instantiate (batteryPrefab, posBattery.position, posBattery.rotation);
		Battery b = batterySpawned.GetComponent<Battery> ();
		b.generator = generator;
		b.hangar = this;
	}

	public void IncreaseElectricityRequest() {
		boat.ElectricityRequest += d.LoadedBattery * 0.1f;
	}

	public void SetupHangar() {
	}

	public void StopHangar() {
	}


}
