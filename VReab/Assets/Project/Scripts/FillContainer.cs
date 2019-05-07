using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillContainer : MonoBehaviour {
    private bool active;
    private bool is_filled;
    public GameObject object_used_to_fill;
    public GameObject filled_object;

    // Start is called before the first frame update
    void Start() {
        active = false;
        is_filled = false;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            // If the player is grabbing the object used to fill, then fill the container
            if (object_used_to_fill.GetComponent<GrabObject>().isGrabbed()) {
                // Calculate the distance between the player and the container
                float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                // If the container is close enough to the player, then it can be filled with the filled object
                if (distance <= 5.0f) {
                    // In the case of the cup, it can be filled with only milk or with coffee with milk
                    if (gameObject.name == "cup") {
                        // If the cup had already coffee, then now it has coffee with milk.
                        // But if the cup was empty, then now it only has milk.
                        if (gameObject.transform.GetChild(2).gameObject.activeSelf) {
                            // Disable coffee
                            gameObject.transform.GetChild(2).gameObject.SetActive(false);
                            // Enable coffee with milk
                            gameObject.transform.GetChild(3).gameObject.SetActive(true);
                        } else if (!gameObject.transform.GetChild(1).gameObject.activeSelf) {
                            // Enable milk
                            gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        }
                    } else {
                        filled_object.SetActive(true);
                    }
                    is_filled = true;
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

    // Called from the "CanvasManager" script
    public bool getIsFilled() {
        return is_filled;
    }
}
