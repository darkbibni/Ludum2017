using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Hole : MonoBehaviour {

	public BoatManager boat;
	public Bilge bilge;

	void OnMousePressed() {
		Debug.Log ("Hole Created");

	}

	// Update is called once per frame
	void Update () {

	}
}
