using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager singleton;

	public GameObject blackScreen;
	public GameObject gameOverPanel;

	public RoomManager roomMgr;

	void Awake() {
		SingletonThis();
	}

	private void Restart() {
		// Fade out.
		blackScreen.SetActive (false);
		gameOverPanel.SetActive (false);

		roomMgr.MoveToRoom (-1);
	}

	private void GameOver() {
		// Fade In
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
		GameOver ();
	}

	[ContextMenu("Restart")]
	public void SimulateRestart() {
		Restart ();
	}
}
