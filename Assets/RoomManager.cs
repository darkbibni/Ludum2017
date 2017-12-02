using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

	public Camera cam;
	public Room[] rooms;

	public void MoveToRoom(int roomIndex) {
		Vector3 newCamPos = rooms [roomIndex].GetRoomPosition ();
		newCamPos.z = cam.transform.position.z;

		cam.transform.position = newCamPos;
	}
}
