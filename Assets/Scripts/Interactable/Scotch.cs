using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scotch : MonoBehaviour {

	public AudioClip scotchSound;

	void OnMouseReleased(GameObject target) {

		Hole h = target.GetComponent<Hole> ();
		if (h) {
			AudioManager.singleton.PlaySfx (scotchSound);
			Destroy (h.gameObject);
		}
	}

	void OnMouseReleased(Vector3 dropPosition) {

		// Do nothing
	}
}
