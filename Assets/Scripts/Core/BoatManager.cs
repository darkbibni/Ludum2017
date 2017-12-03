using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour {

	public Image electricityValue;
	public Image radioactivityValue;
	public Image waterValue;
	public Text scoreValue;

	[Header("Intervalles")]
	public float scoreInterval = 1.0f;
	public float requestInterval = 1.0f;

	public Generator generator;
	public Bilge bilge;
	public Hangar hangar;

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

	public float ElectricityRequest {
		get { return electricityRequest; }
		set {
			electricityRequest = Mathf.Clamp (value, 0f, 1f);
			electricityValue.fillAmount = electricityRequest;
			CheckElectricityRequestEvent ();
		}
	}

	public int Score {
		get { return score; }
		set {
			score = value;

			scoreValue.text = score.ToString();
		}
	}
	private float submersion=0f;
	private float radioactivity=0f;
	private float electricityRequest=1f;
	private int score=0;

	void Awake() {
		SetupBoat ();
	}

	void SetupBoat() {

		Radioactivity = 0.0f;
		ElectricityRequest = 1.0f;
		Submersion = 0.0f;
		Score = 0;
		bilge.SetupBilge ();
		generator.SetupGenerator ();
		hangar.SetupHangar ();

		InvokeRepeating ("IncreaseScore", 0.0f, scoreInterval);
		InvokeRepeating ("DeacreaseElectricityRequest", 0.0f, requestInterval);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void IncreaseScore(){
		Score += 10;
	}

	void CheckSubmersionEvent() { // check value of submersion trigger event
		if (submersion == 1) {
			StopBoat ();
			GameManager.singleton.GameOver (GameoverType.SINKING);
		}
	}

	void CheckRadioactivityEvent() { // check value of submersion trigger event
		if (radioactivity == 1) {
			StopBoat ();
			GameManager.singleton.GameOver(GameoverType.OVERHEAT);
		}
	}

	void CheckElectricityRequestEvent() { // check value of submersion trigger event

		if (electricityRequest <= 0f) {

			GameManager.singleton.GameOver(GameoverType.BOMBING);
			StopBoat ();
		}
			
		//if (electricityRequest==0.1)
			//Call SendTheRafales
	}

	// Trigger when gameover.
	void StopBoat() {

		CancelInvoke ("DeacreaseElectricityRequest");
		CancelInvoke ("IncreaseScore");
		bilge.StopBilge ();
		generator.StopGenerator ();
		hangar.StopHangar ();
	}

	void DeacreaseElectricityRequest() {
		ElectricityRequest -= 0.01f;
	}

}
