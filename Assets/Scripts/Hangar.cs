using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour {

	public BoatManager boat;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SendDrone() {
		nbBattery = nbBattery - 1; //remplacer 1 par nb de batteries chargées
		//Delay 5sec puis call IncreaseElecricityRequest

	}

	void IncreaseElectricityRequest() {
		boat.ElecricityResquest = boat.ElecricityResquest+ 0.2;
	}
}
