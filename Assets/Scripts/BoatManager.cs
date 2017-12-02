using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour {

	public Bilge bilge;

	public float Submersion {
		get { return submersion; }
		set {
			submersion = Mathf.Clamp (value, 0, 1);

			CheckSubmersionEvent ();
		}
	}

	public float Radioactivity {
		get { return radioactivity; }
		set {
			radioactivity = Mathf.Clamp (value, 0, 1);
		
			CheckRadioactivityEvent ();
		}
	}

	public float ElecricityResquest {
		get { return electricityRequest; }
		set {
			electricityRequest = Mathf.Clamp (value, 0, 1);

			CheckElectricityRequestEvent ();
		}
	}

	private float submersion;
	private float radioactivity;
	private float electricityRequest;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckSubmersionEvent() { // check value of submersion trigger event
		//if (submersion==1)
			//Call GameOver
	}

	void CheckRadioactivityEvent() { // check value of submersion trigger event
		//if (radioactivity==1)
			//Call GameOver
	}

	void CheckElectricityRequestEvent() { // check value of submersion trigger event
		//if (electricityRequest==0)
			//Call GameOver
		//if (electricityRequest==0.1)
			//Call SendTheRafales
	}

	void DeacreaseElectricityRequest() {
		boat.ElecricityResquest =- boat.ElecricityResquest * 0.01 ;
	}

}
