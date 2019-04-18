using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutObject : MonoBehaviour
{
    private bool active;
    private List<GrabObject> grab_object_scripts = new List<GrabObject>();
    private List<Vector3> initial_positions = new List<Vector3>();
    private List<Quaternion> initial_rotations = new List<Quaternion>();

    public List<GameObject> objects_to_put;

    // Start is called before the first frame update
    void Start() {
        active = false;
        foreach (GameObject obj in objects_to_put) {
            grab_object_scripts.Add(obj.GetComponent<GrabObject>());
            initial_positions.Add(obj.transform.position);
            initial_rotations.Add(obj.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            // Find index of the gameObject being grabbed
            int index = objects_to_put.FindIndex(obj => obj.GetComponent<GrabObject>().isGrabbed());
            // If the player is grabbing any of the correct objects, place it in its position
            if (index != -1) {
                // Calculate the distance between the player and the machine
                float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
                // If the machine is close enough to the player, then the object can be put
                if (distance <= 3.0f) {
                    grab_object_scripts[index].releaseObject();
                    objects_to_put[index].transform.position = initial_positions[index];
                    objects_to_put[index].transform.rotation = initial_rotations[index];
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
