using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    public PutObject put_objects_script;
    public List<FillContainer> fill_container_scripts;
    public GameObject canvas;

    // Update is called once per frame
    void Update() {
        // Debug.Log(Time.time);
        bool all_filled = true;
        for (int i = 0; i < fill_container_scripts.Count; i++) {
            if (fill_container_scripts[i].getIsFilled() == false) {
                all_filled = false;
            }
        }
        if (all_filled && put_objects_script.getAllObjectsPutted()) {
            canvas.SetActive(true);
        }
    }
}
