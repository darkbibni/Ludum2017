using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Battery : MonoBehaviour {

	public BoatManager boat;
	public Hangar hangar;

	void OnMousePressed() {
		Debug.Log ("Fill water");
	}

	// Update is called once per frame
	void Update () {

	}

}
