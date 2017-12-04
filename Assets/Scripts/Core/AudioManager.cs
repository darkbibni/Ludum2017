using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager singleton;

	public AudioClip bgmTitle;
	public AudioClip bgmInGame;
	public AudioClip bgmInGameStressfull;

	public AudioSource musicSrc;
	public AudioSource soundSrc;
	public AudioSource ambientSrc;
	public AudioSource voiceSrc;

	void Awake() {
		SingletonThis();
	}

	public void PlayBgm(AudioClip bgm) {
		musicSrc.clip = bgm;
		musicSrc.Play ();
	}

	public void StopBgm() {
		musicSrc.Stop ();
	}

	public void PlayBgs(AudioClip bgs) {

        // Stop ambient.
        if (bgs == null)
        {
            ambientSrc.Stop();
        }

        else
        {
            ambientSrc.clip = bgs;
            ambientSrc.Play();
        }
	}

    public void ChangeBgsPitch(float newPitch)
    {
        ambientSrc.pitch = newPitch;
    }

    public void PlaySfx(AudioClip sfx) {
		soundSrc.PlayOneShot(sfx);
	}

	public void PlayVoice(AudioClip voice) {
		voiceSrc.PlayOneShot (voice);
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
