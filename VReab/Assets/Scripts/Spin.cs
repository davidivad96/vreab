using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float speed = 150;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * speed * Time.deltaTime);
	}

	public void FlipSpin () {
		speed = -speed;
	}
}