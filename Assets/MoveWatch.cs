using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWatch : MonoBehaviour {

	private bool mousePressed;
	private Vector3 mouseOrigin;

	void OnMouseOver() {

		Debug.Log ("Over");

		/*
		if (Input.GetMouseButtonDown (0)) {
			mousePressed = true;

			mouseOrigin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if(Input.GetMouseButtonUp(0)) {
			mouseOrigin = Vector3.zero;
		}

		if (mousePressed) {

			if(mouseOrigin != Vector3.zero) {
				Vector3 dir = (mouseOrigin - Input.mousePosition).normalized;
			}
		}
		*/
	}


}
