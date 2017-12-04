using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameoverType {
	OVERHEAT,
	SINKING,
	BOMBING
}

public class GameManager : MonoBehaviour {

	public static GameManager singleton;

    [Header("Managers")]
    public RoomManager roomMgr;
    public BoatManager boatMgr;

    [Header("Gameover panel")]
    public GameObject gameOverPanel;
	public Text explanation;
	public Text finalScore;

    [Header("Gameover panel")]
    public GameObject creditsPanel;

    [Header("Audio components")]
	private AudioManager audioMgr;
	public AudioClip[] gameoverSfxs;

	private bool isGameOver;
    private bool inCredits;

	void Awake() {
		SingletonThis();

		audioMgr = AudioManager.singleton;
	}

	void Start() {
		audioMgr.PlayBgm (audioMgr.bgmInGame);

		Setup ();
	}

	public void Setup() {
		// Fade out.
		gameOverPanel.SetActive (false);

		boatMgr.SetupBoat ();

		// Generator by default
		roomMgr.MoveToRoom (2);
	}

	public void Update() {
        
		if (inCredits) {
			if (Input.GetMouseButtonDown (0)) {
                creditsPanel.SetActive(false);
                inCredits = false;
			}
		}
	}

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenCredits()
    {
        inCredits = true;
        creditsPanel.SetActive(true);
    }

	public void GameOver(GameoverType gameoverType) {
		// Fade In
		isGameOver = true;

		AudioClip gameOverToPlay = null;

		switch (gameoverType) {
		case GameoverType.OVERHEAT:
			gameOverToPlay = gameoverSfxs [0];
			explanation.text = "Overheat text";
				break;
		case GameoverType.SINKING:
			gameOverToPlay = gameoverSfxs[1];
			explanation.text = "Sinking  text";
				break;
		case GameoverType.BOMBING:
			gameOverToPlay = gameoverSfxs [2];
			explanation.text = "Bombing text";
			break;
		}

		finalScore.text = "Score final\n\n" + boatMgr.Score;

		audioMgr.StopBgm ();
		audioMgr.PlaySfx(gameOverToPlay);

		gameOverPanel.SetActive (true);
	}

	private void SingletonThis() {
		if (singleton == null) {
			singleton = this;
		} else {
			Destroy (gameObject);
			return;
		}
	}

	[ContextMenu("GameOver")]
	public void SimulateGO() {
		GameOver (GameoverType.BOMBING);
	}

	[ContextMenu("Restart")]
	public void SimulateRestart() {
		Setup ();
	}
}
