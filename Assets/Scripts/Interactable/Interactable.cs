﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType {
	CLICKABLE,
	DRAGABLE
}

public class Interactable : MonoBehaviour {

	public InteractionType interactionType;

	public void MousePressed(int index) {
		SendMessage ("OnMousePressed", index, SendMessageOptions.DontRequireReceiver);
	}

	public void MouseDrag() {
		SendMessage ("OnMouseDrag", SendMessageOptions.DontRequireReceiver);
	}

	/// <summary>
	/// Send message on all components of this object when mouse is released.
	/// </summary>
	/// <param name="targetObject">Target object if exists</param>
	public void MouseReleased(GameObject targetObject) {
		SendMessage ("OnMouseReleased", targetObject, SendMessageOptions.DontRequireReceiver);
	}

	public void MouseReleased(Vector3 dropPosition) {
		SendMessage ("OnMouseReleased", dropPosition, SendMessageOptions.DontRequireReceiver);
	}
}
