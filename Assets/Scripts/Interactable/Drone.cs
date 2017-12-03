﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Drone : MonoBehaviour {

	public BoatManager boat;
	public Hangar hangar;

	private int loadedBattery=0;

	public int LoadedBattery {
		get { return loadedBattery; }
		set {
			loadedBattery = value;
		}
	}

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

	public void SetupDrone() {
		loadedBattery=0;
	}
	public void StopDrone() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D Trigger){
		Destroy (gameObject);
		hangar.IncreaseElectricityRequest ();
		hangar.spawnDrone ();
		boat.Score += 100;
	}
}
