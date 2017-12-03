using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct Tuto {
	public Sprite sprite;
	public string text;
}

public class MenuScript : MonoBehaviour {

	public Image[] blackBars;
	public AudioClip startClip;
	public AudioClip titleClip;
	public Image textBG;
	public Sprite alternateMenu;
	public Image splashArt;
	public Tuto[] tutos;


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
	private int step = 0;
	private string startText = "";
	private bool finished = false;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < tutos.Length; i++) {
			tutos [i].text = tutos [i].text.Replace ("\\n", "\n");
		}
		startText = tutos [0].text;
		textBG.enabled = false;
		textComponent = gameObject.GetComponentInChildren<Text> ();
		textComponent.text = "";
		AudioManager.singleton.PlayBgm (titleClip);
	}

	// Update is called once per frame
	void Update () {
		if (!finished) {
			if (initialized) {
				if (!started) {
					switch (step) {
					default :
						textComponent.text = tutos [step].text;
						textBG.enabled = true;
						break;

					case 0:
						blinkTimer += Time.deltaTime;
						if (blinkTimer > blinkEvery) {
							textComponent.text = startText;
							splashArt.sprite = alternateMenu;
						} else {
							textComponent.text = "";
							splashArt.sprite = tutos[step].sprite;
						}

						if (blinkTimer > blinkEvery * 2) {
							blinkTimer = 0f;
						} 
						break;
					}
					if (Input.GetMouseButtonDown (0)) {
						started = true;
						textComponent.text = "";
						textBG.enabled = false;
						initialized = false;
						AudioManager.singleton.PlaySfx (startClip);
					}
				}

			} else {
				foreach (Image thisBlackBar in blackBars) {
					thisBlackBar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (gameWidth, 1.05f*Mathf.Ceil (gameHeight - (initializationTimer / initializedAfter) * gameHeight));
				}
				if (!started) {
					initializationTimer += 1 * Time.deltaTime;
					if (initializationTimer > initializedAfter) {
						initialized = true;
					}
				} else {
					initializationTimer -= 1 * Time.deltaTime;
					if (initializationTimer <= 0 && !finished) {
						step++;
						started = false;
						if (step > tutos.Length - 1) {
							finished = true;
							Invoke ("LoadScene", 0.1f);
						} else {
							splashArt.sprite = tutos [step].sprite;
						}
					} 
				}
			}
		}
	}

	private void LoadScene() {
		AudioManager.singleton.StopBgm();
		SceneManager.LoadScene (1);
	}
}
