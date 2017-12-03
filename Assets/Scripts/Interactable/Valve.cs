using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactable))]

public class Valve : MonoBehaviour {

	public BoatManager boat;
	public Generator generator;

	private int nbTour;

	public int NbTour{
		get { return nbTour; }
		set { nbTour = value; }
	}

	void OnMousePressed() {
		if (nbTour < 10) {
			transform.Rotate (Vector3.forward, 45f);
			nbTour++;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
