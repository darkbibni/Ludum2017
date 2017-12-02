﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilge : MonoBehaviour {

	public BoatManager boat;

	private int nbHole=0;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseSubmersion", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseSubmersion() {
		//if (nbHole == 0)
		//	return;
		
		boat.Submersion += nbHole * 0.01f;
	}
}
