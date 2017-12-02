using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cale : MonoBehaviour {

	public BoatManager boat;

	private int nbHole;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseSubmersion", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseSubmersion() {
		if (nbHole == 0)
			return;
		
		boat.Submersion =+ nbHole * 0.01;
	}
}
