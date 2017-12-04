using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum WatchEvent {
	SEAGELL,
	PLANES,
	CLEAR_SKY
}

public class Watch : Room {

  [Header("Watch configuration")]
	public GameObject[] spawnedElements;
	public WatchEvent watchEvent;
	public Transform posPlane;
	public GameObject planePrefab;

	public AudioClip planeBgs;

	public Transform ennemiesTransform;

	public GameObject soundTrigger;


	private bool isWaitingEvent;

	void Awake() {
		watchEvent = WatchEvent.CLEAR_SKY;
	}

	void Start() {

	}

	void Update() {
		if (!isWaitingEvent) {
			StartCoroutine (TriggerEvent());
		}

	}

	IEnumerator TriggerEvent() {
		isWaitingEvent = true;

		int nextEvent = Random.Range (15, 30);

		ManageEvent ();

		yield return new WaitForSeconds (nextEvent);
		isWaitingEvent = false;
	}

	private void ManageEvent() {
		// Spawn event elements.
		spawnPlane();
	}

	public void spawnPlane(){
		GameObject planeSpawned = Instantiate (planePrefab, posPlane.position, posPlane.rotation, ennemiesTransform);
		Plane p = planeSpawned.GetComponent<Plane> ();
		p.watch = this;
		p.PlaneIsHere = true;
		watchEvent = WatchEvent.PLANES;
	}



	public override void Setup() {

	}

	public override void ResetRoom() {

	}

	public override void EnterRoom()
	{
		base.EnterRoom ();

		soundTrigger.SetActive (true);
	}

	public override void LeaveRoom() {
		soundTrigger.SetActive (false);
	}
}