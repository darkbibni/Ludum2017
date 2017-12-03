using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWatch : MonoBehaviour {

	public GameObject sea;

	public float speed = 4f;

	private bool mousePressed;
	private Vector3 mouseOrigin;

	void OnMouseOver() {

		if (Input.GetMouseButtonDown (0)) {
			mousePressed = true;

			mouseOrigin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if(Input.GetMouseButtonUp(0)) {
			mouseOrigin = Vector3.zero;
		}

		if (mousePressed) {

			if(mouseOrigin != Vector3.zero) {
				Vector3 dir = (mouseOrigin - Camera.main.ScreenToWorldPoint (Input.mousePosition)).normalized;

				float dirRatio = Mathf.Round(dir.x);
				Debug.Log (dirRatio);

				Debug.Log (transform.position);

				// Clamp
				sea.transform.Translate (Vector2.right * dirRatio * speed * Time.deltaTime);

				Vector3 newLocalPos = sea.transform.localPosition;
				newLocalPos.x = Mathf.Clamp (sea.transform.localPosition.x, -7f, 7f);
				sea.transform.localPosition = newLocalPos;
			}
		}
	}


}
