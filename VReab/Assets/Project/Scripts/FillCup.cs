using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCup : MonoBehaviour {
    private bool active;
    public GameObject milk_brick;

    // Start is called before the first frame update
    void Start() {
        active = false;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            // If the player is grabbing the milk brick, then fill the cup
            if (milk_brick.GetComponent<GrabObject>().isGrabbed()) {
                // Calculate the distance between the player and the cup
                float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                // If the cup is close enough to the player, then it can be filled with milk
                if (distance <= 3.0f) {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }

    // Called when there's a "PointerEnter" event
    public void Activate() {
        active = true;
    }

    // Called when there's a "PointerExit" event
    public void Deactivate() {
        active = false;
    }
}
