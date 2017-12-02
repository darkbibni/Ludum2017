using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

	public BoatManager boat;

	void OnMousePressed() {
		Debug.Log ("Send drone");
	}
}
