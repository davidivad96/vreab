using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool active;
    private Animator animator_component;

    // Start is called before the first frame update
    void Start() {
        active = false;
        animator_component = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            // If the door is closed then open it. If it's opened, then close it
            if (animator_component.GetBool("Active")) {
                animator_component.SetBool("Active", false);
            } else {
                animator_component.SetBool("Active", true);
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
