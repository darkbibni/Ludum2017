using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilge : Room {

	public BoatManager boat;

	public GameObject water;

 	public int NbHole {
		get { return nbHole; }
		set {
			nbHole = Mathf.Max(value, 0); // Hole can't be negative
		}
	}

	private int nbHole=0;
	private List<GameObject> holes = new List<GameObject> ();

	private Vector3 initialWaterHeight;

	// Use this for initialization
	void Start () {
		initialWaterHeight = water.transform.localPosition;

		InvokeRepeating ("IncreaseSubmersion", 0.0f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

		MoveWater (boat.Submersion);
	}

	public void MoveWater(float submersion) {
		Vector2 newPos = Vector2.Lerp (initialWaterHeight, Vector2.zero, submersion);
		newPos.x = -0.65f;

		water.transform.localPosition = newPos;
	}

	public void EjectWater() {
		boat.Submersion -= boat.Submersion * 0.25f;
	}

	void IncreaseSubmersion() {

		boat.Submersion += nbHole * 0.01f;
	}

	public override void Setup() {
		nbHole = 0;
	}

	public override void Reset() {
		CancelInvoke ("IncreaseSubmersion");
		// TODO clean hole !!!

		foreach (GameObject g in holes) {
			Destroy (g);
		}

		holes.Clear ();
	}

	public void AddHole(GameObject hole) {
		holes.Add (hole);
	}
}
