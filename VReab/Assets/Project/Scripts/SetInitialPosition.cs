using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitialPosition : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start() {
        transform.position = position;
        transform.rotation = rotation;
    }
}
