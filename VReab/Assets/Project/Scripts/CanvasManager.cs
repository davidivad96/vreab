using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    private bool showing_canvas;

    public PutObject put_objects_script;
    public List<FillContainer> fill_container_scripts;
    public GameObject canvas;

    // Start is called before the first frame update
    private void Start() {
        showing_canvas = false;
    }

    // Update is called once per frame
    void Update() {
        if (!showing_canvas) {
            // Debug.Log(Time.time);
            bool all_filled = true;
            for (int i = 0; i < fill_container_scripts.Count; i++) {
                if (fill_container_scripts[i].getIsFilled() == false) {
                    all_filled = false;
                }
            }
            if (all_filled && put_objects_script.getAllObjectsPutted()) {
                FindInactiveObjectByName("TotalText").GetComponent<Text>().text = "Total: " + Time.time.ToString("F2") + " segundos";
                canvas.SetActive(true);
                showing_canvas = true;
            }
        }
    }

    // Used to find inactive objects (GameObject.Find() only works for active objects)
    private GameObject FindInactiveObjectByName(string name) {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++) {
            if (objs[i].hideFlags == HideFlags.None) {
                if (objs[i].name == name) {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
