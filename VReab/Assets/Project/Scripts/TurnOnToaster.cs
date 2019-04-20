using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnToaster : MonoBehaviour
{
    private bool active;
    private bool toast1Putted;
    private bool toast2Putted;
    private bool areToasted;

    public GameObject toast1;
    public GameObject toast2;
    public GameObject cable;
    public Material toastMaterial;

    // Start is called before the first frame update
    void Start() {
        active = false;
        toast1Putted = false;
        toast2Putted = false;
        areToasted = false;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            bool isPlugged = cable.transform.GetChild(0).gameObject.activeSelf;
            // If the two toasts are putted in the toaster and the cable is plugged and they are not toasted yet, then start preparing them
            if (toast1Putted && toast2Putted && isPlugged && !areToasted) {
                Debug.Log("START PREPARING TOASTS!");
                StartCoroutine(prepareToasts());
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

    // Called when the toast1 is putted in the toaster or grabbed from it
    public void putToast1(bool put) {
        toast1Putted = put;
    }

    // Called when the toast2 is putted in the toaster or grabbed from it
    public void putToast2(bool put) {
        toast2Putted = put;
    }

    IEnumerator prepareToasts() {
        // Disable box colliders so that we can't interact with the objects while the toasts are being made
        enableAllColliders(false);
        // Translate down the button and the toasts (to make it more realistic)
        float offset = 0.05f;
        gameObject.transform.position -= new Vector3(0.0f, offset, 0.0f);
        toast1.transform.position -= new Vector3(0.0f, offset, 0.0f);
        toast2.transform.position -= new Vector3(0.0f, offset, 0.0f);
        // Wait for 10 seconds to make the coffee
        yield return new WaitForSeconds(10);
        // Enable again all box colliders
        enableAllColliders(true);
        // Translate up the button and the toasts (to make it more realistic)
        gameObject.transform.position += new Vector3(0.0f, offset, 0.0f);
        toast1.transform.position += new Vector3(0.0f, offset, 0.0f);
        toast2.transform.position += new Vector3(0.0f, offset, 0.0f);
        // Set toast material to the toasts
        toast1.GetComponent<Renderer>().material = toastMaterial;
        toast2.GetComponent<Renderer>().material = toastMaterial;
        Debug.Log("TOASTS READY!");
        areToasted = true;
    }

    // Enable or disabled all box colliders of the objects putted in the coffee machine
    private void enableAllColliders(bool b) {
        toast1.GetComponent<BoxCollider>().enabled = b;
        toast2.GetComponent<BoxCollider>().enabled = b;
        cable.GetComponent<BoxCollider>().enabled = b;
        gameObject.GetComponent<BoxCollider>().enabled = b;
    }
}
