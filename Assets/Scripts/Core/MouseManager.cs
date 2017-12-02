using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

	public Camera cam;

	private GameObject currentGameObject;

	private bool mousePressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			mousePressed = true;

			currentGameObject = GetGameObjectUnderMouse ();

			if (currentGameObject) {
				Interactable interactable = currentGameObject.GetComponent<Interactable> ();
				if (interactable) {
					interactable.MousePressed ();
				}
			}
		}

		/*
		// No drag interaction.
		if (currentGameObject != null) {
			if (Input.GetMouseButtonUp (0)) {
				mousePressed = false;
				Debug.Log ("Click on " + currentGameObject);
				currentGameObject = null;
			}
		}

		else {
			Debug.Log ("move hover");

			if (newObj) {
				currentGameObject = newObj;

				if (Input.GetMouseButtonDown (0)) {
					mousePressed = true;
					Debug.Log ("Mouse down on an object");
				}
			}
		}
		*/
	}

	GameObject GetGameObjectUnderMouse() {
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);

		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

		Debug.DrawRay (ray.origin, ray.direction, Color.green);

		if(hit) {
			return hit.transform.gameObject;
		}

		return null;
	}
}
