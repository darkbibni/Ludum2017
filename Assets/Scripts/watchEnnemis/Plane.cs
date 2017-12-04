using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

	public Watch watch;
	private bool planeIsHere;

	public bool PlaneIsHere {
		get { return planeIsHere; }
		set { planeIsHere = value; }
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (planeIsHere == true) {
			transform.Translate (new Vector2 (0.05f, 0));
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.tag == "SoundTrigger") {

			AudioManager.singleton.PlayBgs (watch.planeBgs);
			return;
		}

		planeIsHere = false;
		watch.watchEvent = WatchEvent.CLEAR_SKY;
		Destroy (gameObject);
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.tag == "SoundTrigger") {
			AudioManager.singleton.PlayBgs (null);
			return;
		}
	}
}