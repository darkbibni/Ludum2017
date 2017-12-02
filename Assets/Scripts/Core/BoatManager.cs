using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour {

	public Image electricityValue;
	public Image radioactivityValue;
	public Image waterValue;
	public Text scoreValue;


	public float Submersion {
		get { return submersion; }
		set {
			submersion = Mathf.Clamp (value, 0, 1);

			waterValue.fillAmount = submersion;
			CheckSubmersionEvent ();
		}
	}

	public float Radioactivity {
		get { return radioactivity; }
		set {
			radioactivity = Mathf.Clamp (value, 0, 1);
			radioactivityValue.fillAmount = radioactivity;
			CheckRadioactivityEvent ();
		}
	}

	public float ElecricityResquest {
		get { return electricityRequest; }
		set {
			electricityRequest = Mathf.Clamp (value, 0, 1);
			electricityValue.fillAmount = electricityRequest;
			CheckElectricityRequestEvent ();
		}
	}

	public int Score {
		get { return score; }
		set {
			electricityValue.fillAmount = score;
		}
	}
	private float submersion=0f;
	private float radioactivity=0f;
	private float electricityRequest=1f;
	private int score=0;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("IncreaseScore", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseScore(){
		score += 10;
	}

	void CheckSubmersionEvent() { // check value of submersion trigger event
		if (submersion==1)
			GameManager.singleton.GameOver();
	}

	void CheckRadioactivityEvent() { // check value of submersion trigger event
		if (radioactivity==1)
			GameManager.singleton.GameOver();
	}

	void CheckElectricityRequestEvent() { // check value of submersion trigger event
		if (electricityRequest==0)
			GameManager.singleton.GameOver();
		//if (electricityRequest==0.1)
			//Call SendTheRafales
	}

	void DeacreaseElectricityRequest() {
		ElecricityResquest -= ElecricityResquest * 0.01f;
	}

}
