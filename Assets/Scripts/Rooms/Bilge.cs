using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilge : Room {

	public BoatManager boat;

	public GameObject water;

	private int nbHole=0;

	private Vector3 initialWaterHeight;

	// Use this for initialization
	void Start () {
		initialWaterHeight = water.transform.localPosition;

		InvokeRepeating ("IncreaseSubmersion", 0.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

		MoveWater (boat.Submersion);
	}

	public void MoveWater(float submersion) {
		Vector2 newPos = Vector2.Lerp (initialWaterHeight, Vector2.zero, submersion);
		newPos.x = -0.65f;

		water.transform.localPosition = newPos;
	}

	void IncreaseSubmersion() {
		//if (nbHole == 0)
		//	return;

		boat.Submersion += nbHole * 0.01f;
	}
}
