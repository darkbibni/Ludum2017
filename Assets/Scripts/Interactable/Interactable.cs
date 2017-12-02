using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType {
	CLICKABLE,
	DRAGABLE
}

public class Interactable : MonoBehaviour {

	public InteractionType interactionType;

	public void MousePressed() {
		SendMessage ("OnMousePressed", SendMessageOptions.DontRequireReceiver);
	}

	public void MouseDrag() {
		SendMessage ("OnMouseDrag", SendMessageOptions.DontRequireReceiver);
	}

	public void MouseReleased() {
		SendMessage ("OnMouseReleased", SendMessageOptions.DontRequireReceiver);
	}
}
