using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Drone : MonoBehaviour {

	public BoatManager boat;
	public Hangar hangar;
	public Watch watch;

	public AudioClip droneTakeover;
	public AudioClip droneSupplyValidate;
	public AudioClip sendError;
	public AudioClip Explosion;

	private int loadedBattery=0;
	private int luck;
	private int planeMalus;

	public int LoadedBattery {
		get { return loadedBattery; }
		set {
			loadedBattery = value;
		}
	}

	public float speed = 5.0f;

	private bool move;

	void OnMousePressed(int index) {
		if (index == 0) {
			if (loadedBattery > 0) {
				move = true;
				AudioManager.singleton.PlaySfx (droneTakeover);
			} else {
				AudioManager.singleton.PlaySfx (sendError);
			}
		}
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

	void ValidateDrone() {
		
		if (watch.watchEvent == WatchEvent.PLANES) {
			
			luck = Random.Range (0, 100);
			planeMalus = 25 + loadedBattery * 5;

			if (luck > planeMalus) {
				Success ();
			} else {
				AudioManager.singleton.PlaySfx (Explosion);
			}
		}

		else if (watch.watchEvent == WatchEvent.SEAGELL) {
			
			luck = Random.Range (0, 100);
			planeMalus = 5 + loadedBattery * 5;

			if (luck > planeMalus) {
				Success ();
			} else {
				AudioManager.singleton.PlaySfx (Explosion);
			}
		}

		else {
			Success ();
		}

		Destroy (gameObject);
		hangar.spawnDrone ();
	}

	private void Success() {
		hangar.IncreaseElectricityRequest ();
		boat.Score += 100 * loadedBattery;
		AudioManager.singleton.PlaySfx (droneSupplyValidate);
	}
}
