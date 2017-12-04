using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilge : Room {
    
    [Header("Generator configuration")]
	public GameObject water;

	public Transform[] posHoles;
	public GameObject holePrefab;


 	public int NbHole {
		get { return nbHole; }
		set {
			nbHole = Mathf.Max(value, 0); // Hole can't be negative

            CheckFillWaterBgs();
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

	public override void ResetRoom() {
		CancelInvoke ("IncreaseSubmersion");
		// TODO clean hole !!!

		foreach (GameObject g in holes) {
			Destroy (g);
		}

		holes.Clear ();
	}

    public override void EnterRoom()
    {
        CheckFillWaterBgs();
    }

    private void CheckFillWaterBgs()
    {
        if (nbHole > 0)
        {
            AudioManager.singleton.PlayBgs(roomBgs);
        }
        else
        {
            AudioManager.singleton.PlayBgs(null);
        }
    }

    public void AddHole(GameObject hole) {
		holes.Add (hole);
	}

	public void rafalesBombing(){

		int c = 0;
		while (c < 3){
			GameObject holeSpawned = Instantiate (holePrefab, posHoles[c].position, posHoles[c].rotation);
			Hole h = holeSpawned.GetComponent<Hole> ();
			h.bilge = this;
			c++;
		}

		nbHole += 3;
	}
}
