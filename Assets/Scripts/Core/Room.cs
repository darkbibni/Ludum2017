using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public Vector2 GetRoomPosition() {
		return transform.position;
	}

	public virtual void Setup () {

	}

	public virtual void Reset () {

	}
}
