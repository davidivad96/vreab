using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private GameObject Camera;
    private Rigidbody rigidbody_component;
	public float speed = 1.0f;
    private bool grabbing_something;

	// Use this for initialization
	void Start () {
		Camera = GameObject.Find ("Main Camera");
        rigidbody_component = gameObject.GetComponent<Rigidbody>();
        grabbing_something = false;
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

    // Prevent from bouncing when the player collides
    void OnCollisionEnter(Collision collision) {
        rigidbody_component.velocity = Vector3.zero;
    }

    // Set the grabbing_something attribute
    public void setGrabbingSomething(bool b) {
        grabbing_something = b;
    }

    // Get the grabbing_something attribute
    public bool getGrabbingSomething() {
        return grabbing_something;
    }
}
