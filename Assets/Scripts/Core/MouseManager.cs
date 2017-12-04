using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

	public Camera cam;

	public LayerMask allObjectsLayer;
	public LayerMask interactableLayer;
	public LayerMask targetableLayer;

	[Header("Cursor")]
	public Texture2D cursorTexture;
	public CursorMode cursorMode;

	private GameObject currentGameObject;
	private Interactable interactable;



	private bool mousePressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		GameObject objectHovered = GetObject (interactableLayer);
		if (objectHovered) {
			Cursor.SetCursor (cursorTexture, Vector2.zero, cursorMode);
		} else {
			Cursor.SetCursor (null, Vector2.zero, cursorMode);
		}

		HandleMousePressed (0);
		HandleMousePressed (1);

		HandleMouseReleased ();

		HandleMouseDrag ();
	}

	void HandleMousePressed(int index) {
		if (Input.GetMouseButtonDown (index)) {

			currentGameObject = GetObject (allObjectsLayer);

			// Store interactable if gameobject exist.
			if (currentGameObject) {
				interactable = currentGameObject.GetComponent<Interactable> ();

				if (interactable) {
					
					if (interactable.interactionType == InteractionType.CLICKABLE) {
						interactable.MousePressed (index);
					}

					else if (interactable.interactionType == InteractionType.DRAGABLE) {
						mousePressed = true;

						Debug.Log ("Start drag");
					}
				}
			}
		}
	}

	void HandleMouseReleased() {
		// Release !
		if (Input.GetMouseButtonUp (0)) {
			if (mousePressed) {
				if (interactable) {

					if (interactable.interactionType == InteractionType.DRAGABLE) {
						Debug.Log ("End drag");

						mousePressed = false;

						GameObject targetableObject = GetObject (targetableLayer);

						if (targetableObject) {
							interactable.MouseReleased (targetableObject);

							Debug.Log ("Drop object on " + targetableObject);
						}

						else {
							interactable.MouseReleased (cam.ScreenToWorldPoint(Input.mousePosition));
						}
					}
				}
			}
		}
	}

	void HandleMouseDrag() {
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
				newPos.z = currentGameObject.transform.position.z;

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
			Debug.DrawRay (ray.origin, ray.direction * hit.distance, Color.red, 2.0f);

			return hit.transform.gameObject;
		}

		return null;
	}
}
