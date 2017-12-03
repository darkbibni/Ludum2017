using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mass : MonoBehaviour {

	public Bilge bilge;
	public GameObject holePrefab;
	public AudioClip massHit;

	void OnMouseReleased(GameObject target) {

		// Do nothing.
	}

	void OnMouseReleased(Vector3 dropPosition) {

		dropPosition.z = 0.0f;

		AudioManager.singleton.PlaySfx (massHit);
		GameObject holeSpawned = Instantiate (holePrefab, dropPosition, Quaternion.identity);

		Hole h = holeSpawned.GetComponent<Hole> ();
		h.bilge = bilge;
		h.OnCreateHole ();
	}
}
