using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private GameObject Camera;
	private float speed;

	// Use this for initialization
	void Start () {
		Camera = GameObject.Find ("Main Camera");
		speed = 4.0f * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		// Get input values for vertical and horizontal axis
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		// Transform character position based on the camera rotation
		// so that the character moves in the direction it's facing
		transform.position += Camera.transform.forward * v * speed;
		transform.position += Camera.transform.right * h * speed;
		// Set the 'y' value to 1.0 so that the character does  not fly
		transform.position = new Vector3 (transform.position.x, 1.0f, transform.position.z);
	}
}
