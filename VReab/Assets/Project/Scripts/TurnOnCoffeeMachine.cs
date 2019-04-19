using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCoffeeMachine : MonoBehaviour
{
    private bool active;
    private bool waterContainerPutted;
    private bool filterPutted;
    private bool cupPutted;

    public GameObject cable;
    public GameObject waterContainer;
    public GameObject filter;

    // Start is called before the first frame update
    void Start() {
        active = false;
        waterContainerPutted = true;
        filterPutted = true;
        cupPutted = true;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            bool isPlugged = cable.transform.GetChild(0).gameObject.activeSelf;
            bool waterContainerFilled = waterContainer.transform.GetChild(1).gameObject.activeSelf;
            bool filterFilled = filter.transform.GetChild(0).GetChild(3).gameObject.activeSelf;

            if (isPlugged && waterContainerFilled && waterContainerPutted && filterFilled && filterPutted && cupPutted) {
                Debug.Log("IT'S READY!");
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

    // Called when the water container is putted in the coffee machine or grabbed from it
    public void putWaterContainer(bool put) {
        waterContainerPutted = put;
    }

    // Called when the coffee filter is putted in the coffee machine or grabbed from it
    public void putCoffeeFilter(bool put) {
        filterPutted = put;
    }

    // Called when the cup is putted in the coffee machine or grabbed from it
    public void putCup(bool put) {
        cupPutted = put;
    }
}
