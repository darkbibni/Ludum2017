using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Battery : MonoBehaviour {
	
	public Hangar hangar;
	public Generator generator;

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

	void OnMouseReleased(Vector3 dropPosition) {

		// Do nothing !
	}

}
