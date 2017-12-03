using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum WatchEvent {
	SEAGELL,
	PLANES,
	CLEAR_SKY
}

public class Watch : Room {

	public BoatManager boat;

	public GameObject[] spawnedElements;

	public WatchEvent watchEvent;
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

		float nextEvent = Random.Range (20f, 40f);


		yield return new WaitForSeconds (nextEvent);
		isWaitingEvent = false;
	}

	private void ManageEvent() {
		// Spawn event elements.


		// 
	}



	public override void Setup() {

	}

	public override void Reset() {

	}
}
