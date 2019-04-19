using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugUnplugCable : MonoBehaviour
{
    private bool active;

    // Start is called before the first frame update
    void Start() {
        active = false;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            // If the cable is not plugged, then plug it. If it is plugged, then unplug it.
            if (gameObject.transform.GetChild(0).gameObject.active) {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            } else {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
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
