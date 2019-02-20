using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private GameObject Camera;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		Camera = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Get input values for vertical and horizontal axis
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		// Transform character position based on the camera rotation
		// so that the character moves in the direction it's facing
		transform.position += Camera.transform.forward * v * speed * Time.deltaTime;
		transform.position += Camera.transform.right * h * speed * Time.deltaTime;
		// Fix the 'y' value so that the character does not fly
		transform.position = new Vector3 (transform.position.x, 1.3f, transform.position.z);
	}
}
