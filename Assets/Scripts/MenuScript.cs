using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

	public string startText = "CLICK TO START";
	public Image[] blackBars;
	public AudioClip startClip;
	public AudioClip titleClip;


	private const float blinkEvery = 0.5f; //seconds
	private const float initializedAfter = 1f; //seconds
	private const float gameWidth = 854f;
	private const float gameHeight = 480f;

	//VARS
	private float blinkTimer = 0f;
	private bool initialized = false;
	private float initializationTimer = 0f;
	private Text textComponent;
	private bool started = false;

	// Use this for initialization
	void Start () {
		textComponent = gameObject.GetComponentInChildren<Text> ();
		textComponent.text = startText;
		AudioManager.singleton.PlayBgm (titleClip);
	}

	// Update is called once per frame
	void Update () {
		if (initialized) {
			if (!started) {
				blinkTimer += Time.deltaTime;
				if (blinkTimer > blinkEvery) {
					textComponent.text = startText;
				} else {
					textComponent.text = "";
				}

				if (blinkTimer > blinkEvery * 2) {
					blinkTimer = 0f;
				} 

				if (Input.GetMouseButtonDown (0)) {
					started = true;
					textComponent.text = "";
					initialized = false;
					AudioManager.singleton.PlaySfx (startClip);
				}
			}

		} else {
			foreach (Image thisBlackBar in blackBars){
				thisBlackBar.GetComponent<RectTransform>().sizeDelta = new Vector2(gameWidth, Mathf.Round(gameHeight-(initializationTimer / initializedAfter)*gameHeight));
			}
			if (!started) {
				initializationTimer += 1 * Time.deltaTime;
				if (initializationTimer > initializedAfter) {
					initialized = true;
				}
			} else {
				initializationTimer -= 1 * Time.deltaTime;
				if (initializationTimer <= 0) {
					Invoke ("LoadScene", 0.1f);
				}
			}
		}
	}

	private void LoadScene() {
		AudioManager.singleton.StopBgm();
		SceneManager.LoadScene (1);
	}
}
