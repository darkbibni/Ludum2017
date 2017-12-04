using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    [Header("Room configuration")]
    public BoatManager boat;
    public AudioClip roomBgs;

	public Vector2 GetRoomPosition() {
		return transform.position;
	}

	public virtual void Setup () {

	}

	public virtual void ResetRoom() {

	}

    public virtual void PlayRoomBgs()
    {
        AudioManager.singleton.PlayBgs(roomBgs);
    }
}
