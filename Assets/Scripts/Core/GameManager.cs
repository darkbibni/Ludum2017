using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameoverType {
	OVERHEAT,
	SINKING,
	BOMBING
}

public class GameManager : MonoBehaviour {

	public static GameManager singleton;

	public GameObject blackScreen;
	public GameObject gameOverPanel;

	public RoomManager roomMgr;
	public BoatManager boatMgr;

	[Header("Audio components")]
	private AudioManager audioMgr;
	public AudioClip[] gameoverSfxs;

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
		blackScreen.SetActive (false);
		gameOverPanel.SetActive (false);

		boatMgr.SetupBoat ();

		// Generator by default
		roomMgr.MoveToRoom (2);
	}

	public void GameOver(GameoverType gameoverType) {
		// Fade In

		AudioClip gameOverToPlay = null;

		switch (gameoverType) {
		case GameoverType.OVERHEAT:
			gameOverToPlay = gameoverSfxs [0];
				break;
		case GameoverType.SINKING:
			gameOverToPlay = gameoverSfxs[1];
				break;
		case GameoverType.BOMBING:
			gameOverToPlay = gameoverSfxs [2];
			break;
		}

		audioMgr.StopBgm ();
		audioMgr.PlaySfx(gameOverToPlay);


		blackScreen.SetActive (true);
		gameOverPanel.SetActive (true);
	}

	private void SingletonThis() {
		if (singleton == null) {
			singleton = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);
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
