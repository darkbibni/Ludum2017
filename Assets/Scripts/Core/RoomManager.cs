using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

	public Camera cam;
	public Room[] rooms;
	public GameObject splashScreen;

	private Room currentRoom;

	public void MoveToRoom(int roomIndex) {

		if (rooms [roomIndex] == currentRoom) {
			return;
		}

		if (currentRoom) {
			currentRoom.LeaveRoom ();
		}

		currentRoom = rooms [roomIndex];

		Vector3 newCamPos;

		if (roomIndex < 0 || roomIndex > rooms.Length) {
			newCamPos = splashScreen.transform.position;
		}

		else {
			newCamPos = currentRoom.GetRoomPosition ();
		}
				
		newCamPos.z = cam.transform.position.z;

		currentRoom.EnterRoom();
		cam.transform.position = newCamPos;
	}
}
