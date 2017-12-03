using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Battery : MonoBehaviour {
	public Hangar hangar;
	public Generator generator;



	void Awake() {
		
	}

	void OnMouseDrag() {
	}

	void OnMouseReleased(GameObject target) {

		Drone d = target.GetComponent<Drone> ();

		if (d) {
			if (d.LoadedBattery < 5) {
				generator.NbBattery--;
				Destroy (gameObject);
				d.LoadedBattery++;
			} 
			else if (d.LoadedBattery >= 5) {
				transform.position = hangar.posBattery.position;		
			}
		}
	}

	// Update is called once per frameS
	void Update () {

	}

}
