using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float speed;
	private bool active;

	// Use this for initialization
	void Start () {
		speed = 150;
		active = false;
	}

	// Update is called once per frame
	void Update () {
		// The object is rotating all the time
		transform.Rotate (Vector3.up * speed * Time.deltaTime);

		// Little hack to detect when there's a "PointerClick" event,
		// because the original method using the Event Trigger script
		// doesn't work with the bluetooth controller.
		// "Jump" is the up trigger button in the bluetooth controller,
		// and "Fire1" is the left click button of the mouse.
		// This way it works in the editor and in the mobile device
		if ((Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown(0)) && active) {
			// If there's a "PointerClick" event, then the object spins in the opposite direction
			speed = -speed;
		}
	}

	// Called when there's a "PointerEnter" event
	public void Activate(){
		active = true;
	}

	// Called when there's a "PointerExit" event
	public void Deactivate(){
		active = false;
	}
}