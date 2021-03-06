﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BoatManager : MonoBehaviour {

	public Image electricityValue;
	public Image radioactivityValue;
	public Image waterValue;
	public Text scoreValue;


	[Header("Intervalles")]
	public float scoreInterval = 10.0f;
	public float requestInterval = 1.0f;

	public Generator generator;
	public Bilge bilge;
	public Hangar hangar;
	public Watch watch;

	public AudioClip[] alertVoices;
	public AudioClip Bombing;

	private bool alert;

	private bool reactorAlarm;
	public AudioClip reactorAlarmSound;

	public GameObject ui;

	public float alertTime = 0.15f;

	private bool sendRafales;

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

			radioactivityValue.color = Color.Lerp (Color.green, Color.red, radioactivity);
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

			scoreValue.text = "Score\n" + score.ToString();
		}
	}
	private float submersion=0f;
	private float radioactivity=0f;
	private float electricityRequest=1f;
	private int score=0;

	void Awake() {
		
	}

	public void SetupBoat() {

		Radioactivity = 0.0f;
		ElectricityRequest = 1.0f;
		Submersion = 0.0f;
		Score = 0;
		bilge.Setup ();
		generator.Setup ();
		hangar.Setup ();

		InvokeRepeating ("IncreaseScore", 0.0f, scoreInterval);
		InvokeRepeating ("DeacreaseElectricityRequest", 0.0f, requestInterval);
		InvokeRepeating ("requestUpgrade", 60.0f, 60.0f);
	}

	void IncreaseScore(){
		Score += 10;
	}

	void requestUpgrade() {
		requestInterval *=0.80f;
		CancelInvoke ("DeacreaseElectricityRequest");
		InvokeRepeating ("DeacreaseElectricityRequest", 0.0f, requestInterval);
	}

	void DeacreaseElectricityRequest() {
		ElectricityRequest -= 0.01f;
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

		if (!reactorAlarm && radioactivity > 0.75f) {
			reactorAlarm = true;
			AudioManager.singleton.PlaySfx (reactorAlarmSound);
		}

		if (reactorAlarm && radioactivity <= 0.7f) {
			reactorAlarm = false;
		}
	}

	void CheckElectricityRequestEvent() { // check value of submersion trigger event

		if (electricityRequest <= 0f) {

			GameManager.singleton.GameOver(GameoverType.BOMBING);
			StopBoat ();
		}
			
		if (!alert && electricityRequest <= alertTime) {
			alert = true;

			// Alert for the Rafales !
			int randVoice = Random.Range (0, alertVoices.Length);
			AudioManager.singleton.PlayVoice (alertVoices [randVoice]);

			AudioManager.singleton.PlayBgm (AudioManager.singleton.bgmInGameStressfull);
		}

		if (alert && electricityRequest > alertTime) {
			alert = false;

			AudioManager.singleton.PlayBgm (AudioManager.singleton.bgmInGame);
		}

		if (!sendRafales && electricityRequest <= 0.1f) {
			sendRafales = true;

			TriggerRafalesEvent ();
		}

		if (sendRafales && electricityRequest > 0.1f) {
			sendRafales = false;
		}
	}

	void TriggerRafalesEvent() {
		bilge.rafalesBombing();
		AudioManager.singleton.PlaySfx (Bombing);
		StartCoroutine (ShakeSprite ());
	}

	// Trigger when gameover.
	void StopBoat() {
		CancelInvoke ("DeacreaseElectricityRequest");
		CancelInvoke ("IncreaseScore");

		bilge.ResetRoom();
		generator.ResetRoom();
		hangar.ResetRoom();
		watch.ResetRoom();
	}

	// Shake the sprite.
    private IEnumerator ShakeSprite()
    {
        Vector3 shakingPos = Vector3.zero;

        int shakingCount = 25;
        float shakeDuration = 0.2f / shakingCount;

		RectTransform rect = ui.GetComponent<RectTransform> ();

		Vector3 originalPos = rect.position;

        int i = 0;
        while (i < shakingCount)
        {
			shakingPos = Random.insideUnitCircle * 25f;

            // Change local position to simulate shake.
			rect.position = originalPos + shakingPos;

            yield return new WaitForSeconds(shakeDuration);
            i++;
        }

        // Reset position of the sprite.
		rect.position = originalPos;
    }


	[ContextMenu("Shake")]
	public void SimulateShake() {
		StartCoroutine (ShakeSprite ());
	}
}
