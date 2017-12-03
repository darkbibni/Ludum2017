using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Hole : MonoBehaviour {

	public Bilge bilge;

	public void OnCreateHole() {
		bilge.NbHole++;
	}

	void OnDestroy() {
		OnRepareHole ();
	}

	private void OnRepareHole() {
		bilge.NbHole--;
	}
}
