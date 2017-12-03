using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Drone : MonoBehaviour {

	public BoatManager boat;
	public Hangar hangar;

	public AudioClip droneTakeover;

	private int loadedBattery=0;

	public int LoadedBattery {
		get { return loadedBattery; }
		set {
			loadedBattery = value;
		}
	}

	public float speed = 5.0f;

	private bool move;

	void OnMousePressed() {
		Debug.Log ("Send drone");
		move = true;

		AudioManager.singleton.PlaySfx (droneTakeover);
	}

	void Update() {
		if (move) {
			transform.Translate (new Vector2 (0.0f, Time.deltaTime * speed));
			transform.localScale *= 0.95f;

			if (transform.localScale.x <= 0.05f)
				ValidateDrone ();
		}
	}

	public void SetupDrone() {
		loadedBattery=0;
	}

	public void StopDrone() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D Trigger){
		//ValidateDrone ();
	}

	void ValidateDrone() {
		hangar.IncreaseElectricityRequest ();
		boat.Score += 100 * loadedBattery;

		Destroy (gameObject);

		hangar.spawnDrone ();
	}
}
