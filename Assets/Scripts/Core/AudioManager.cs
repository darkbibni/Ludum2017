﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager singleton;

	public AudioClip bgmTitle;
	public AudioClip bgmInGame;

	public AudioSource musicSrc;
	public AudioSource soundSrc;
	public AudioSource ambientSrc;

	void Awake() {
		SingletonThis();
	}

	public void PlayBgm(AudioClip bgm) {
		musicSrc.clip = bgm;
		musicSrc.Play ();
	}

	public void PlayBgs(AudioClip bgs) {
		ambientSrc.clip = bgs;
		ambientSrc.Play ();
	}

	public void PlaySfx(AudioClip sfx) {
		soundSrc.PlayOneShot(sfx);
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
}