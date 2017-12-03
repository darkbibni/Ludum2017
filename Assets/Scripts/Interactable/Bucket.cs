using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {

	public Bilge bilge;
	public SpriteRenderer bucketSprite;

	public Sprite bucketFull;
	public Sprite bucketEmpty;

	public AudioClip takeWater;
	public AudioClip dropWater;

	private bool fullOfWater;
	private bool isDragging;

	void OnTriggerEnter2D(Collider2D collider) {

		if (fullOfWater || !isDragging) {
			return;
		}

		if (collider.gameObject.name.Contains ("Water")) {
			TakeWaterOnBucket ();
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		
		if (fullOfWater || !isDragging) {
			return;
		}

		if (collider.gameObject.name.Contains ("Water")) {
			TakeWaterOnBucket ();
		}
	}

	#region Mouse interaction

	void OnMouseDrag() {
		isDragging = true;
	}

	void OnMouseReleased(GameObject target) {

		if (fullOfWater) {
			if (target.name.Contains ("Porthole")) {
				DropWaterFromBucket ();
			}
		}

		isDragging = false;
	}

	void OnMouseReleased(Vector3 dropPosition) {
		// Do nothing.

		isDragging = false;
	}

	#endregion

	#region gameplay

	void TakeWaterOnBucket() {
		// TODO feedback sound and sprite.
		bucketSprite.sprite = bucketFull;

		bilge.EjectWater ();
		fullOfWater = true;

		if (takeWater)
			AudioManager.singleton.PlaySfx (takeWater);
	}

	void DropWaterFromBucket() {
		bucketSprite.sprite = bucketEmpty;
		fullOfWater = false;

		if(dropWater)
			AudioManager.singleton.PlaySfx (dropWater);
	}

	#endregion
}
