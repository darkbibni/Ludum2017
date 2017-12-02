using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public BoatManager boat;

	public int NbBattery{
		get { return nbBattery; }
		set { 					}
	}

	private int nbBattery;

	private float generatorPower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseRadioactivity() {
		if (generatorPower == 0)
			return;

		boat.Radioactivity =+ generatorPower * 0.01;
	}

	void DecreaseRadioactivity() {
		if (boat.Submersion == 0)
			return;

		boat.Radioactivity = boat.Radioactivity - 0.2; //EmptyTheBucket
	}




}
