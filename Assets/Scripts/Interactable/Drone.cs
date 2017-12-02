using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Drone : MonoBehaviour {

	public BoatManager boat;
	public Hangar hangar;

	public float speed = 2.0f;

	private bool move;

	void OnMousePressed() {
		Debug.Log ("Send drone");
		move = true;

	}

	void Update() {
		if (move) {
			transform.Translate (new Vector2 (0.0f, Time.deltaTime * speed));
		}
	}


}
