using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Valve : MonoBehaviour {

	public BoatManager boat;
	public Generator generator;

	public AudioClip valveUp;
	public AudioClip valveDown;

	private int nbTour;

	public int NbTour{
		get { return nbTour; }
		set { nbTour = value; }
	}

	void OnMousePressed(int index) {
		if (index==0){
			if (nbTour < 10) {
				transform.Rotate (Vector3.forward, 45f);
				nbTour++;
				AudioManager.singleton.PlaySfx (valveDown);
			}
		}
		if (index==1){
			if (nbTour > 2) {
				transform.Rotate (Vector3.forward, -45f);
				nbTour--;
				AudioManager.singleton.PlaySfx (valveUp);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
