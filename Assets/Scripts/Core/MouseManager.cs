using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

	public Camera cam;

	public LayerMask allObjectsLayer;
	public LayerMask interactableLayer;
	public LayerMask targetableLayer;

	private GameObject currentGameObject;
	private Interactable interactable;

	private bool mousePressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			
			currentGameObject = GetObject (allObjectsLayer);

			// Store interactable if gameobject exist.
			if (currentGameObject) {
				interactable = currentGameObject.GetComponent<Interactable> ();

				if (interactable) {
					if (interactable.interactionType == InteractionType.CLICKABLE) {
						interactable.MousePressed ();
					} else if (interactable.interactionType == InteractionType.DRAGABLE) {
						mousePressed = true;

						Debug.Log ("Start drag");
					}
				}
			}
		}

		// Release !
		if (Input.GetMouseButtonUp (0)) {
			if (mousePressed) {
				if (interactable) {

					if (interactable.interactionType == InteractionType.DRAGABLE) {
						Debug.Log ("End drag");

						mousePressed = false;

						GameObject targetableObject = GetObject (targetableLayer);

						interactable.MouseReleased (targetableObject);

						Debug.Log ("Drop object on " + targetableObject);
					}
				}
			}
		}

		// Drag !
		if (mousePressed && currentGameObject != null) {

			float mouseX = Input.mousePosition.x;
			float mouseY = Input.mousePosition.y;
			float screenWidth = Screen.width;
			float screenHeight = Screen.height;

			// Out of screen.
			if (mouseX < 0 || mouseX > 725 || mouseY < 0 || mouseY > screenHeight) {
				
			} else {
				Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
				newPos.z = 0.0f;

				currentGameObject.transform.position = newPos;

				if (interactable) {
					if (interactable.interactionType == InteractionType.DRAGABLE) {
						interactable.MouseDrag ();
					}
				}
			}
		}
	}

	GameObject GetObject(LayerMask layerMask) {
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);

		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 100.0f, layerMask);

		if(hit) {
			Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.red, 0.5f);

			return hit.transform.gameObject;
		}

		return null;
	}
}
