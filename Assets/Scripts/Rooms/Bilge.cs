using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilge : Room {

	public BoatManager boat;

	private int nbHole=0;

	public int NbHole {
		get { return nbHole; }
		set {
			nbHole = value;
		}
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseSubmersion", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseSubmersion() {
		//if (nbHole == 0)
		//	return;

		boat.Submersion += /*nbHole * */ 0.01f;
	}

	public void SetupBilge() {
		nbHole = 0;
	}

	public void StopBilge() {
		CancelInvoke ("IncreaseSubmersion");
	}
}
