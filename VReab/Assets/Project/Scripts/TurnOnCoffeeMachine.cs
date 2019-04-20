using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCoffeeMachine : MonoBehaviour
{
    private bool active;
    private bool waterContainerPutted;
    private bool filterPutted;
    private bool cupPutted;
    private bool coffeeMade;

    public GameObject cup;
    public GameObject cable;
    public GameObject waterContainer;
    public GameObject filter;

    // Start is called before the first frame update
    void Start() {
        active = false;
        waterContainerPutted = true;
        filterPutted = true;
        cupPutted = true;
        coffeeMade = false;
    }

    // Update is called once per frame
    void Update() {
        // If detect a "PointerClick" event
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && active) {
            bool isPlugged = cable.transform.GetChild(0).gameObject.activeSelf;
            bool waterContainerFilled = waterContainer.transform.GetChild(1).gameObject.activeSelf;
            bool filterFilled = filter.transform.GetChild(0).GetChild(3).gameObject.activeSelf;

            // If all the conditions are true, then start making the coffee
            if (isPlugged && waterContainerFilled && waterContainerPutted && filterFilled && filterPutted && cupPutted && !coffeeMade) {
                Debug.Log("START MAKING COFFEE!");
                StartCoroutine(makeCoffee());
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

    IEnumerator makeCoffee() {
        // Disable box colliders so that we can't interact with the objects while the coffee is being made
        enableAllColliders(false);
        // Wait for 10 seconds to make the coffee
        yield return new WaitForSeconds(10);
        // Enable again all box colliders
        enableAllColliders(true);
        // If the cup had already milk, then now it has coffee with milk.
        // But if the cup was empty, then now it only has coffee.
        if (cup.transform.GetChild(1).gameObject.activeSelf) {
            // Disable milk
            cup.transform.GetChild(1).gameObject.SetActive(false);
            // Enable coffee with milk
            cup.transform.GetChild(3).gameObject.SetActive(true);
        } else {
            // Enable coffee
            cup.transform.GetChild(2).gameObject.SetActive(true);
        }
        Debug.Log("COFFEE READY!");
        coffeeMade = true;
    }

    // Enable or disabled all box colliders of the objects putted in the coffee machine
    private void enableAllColliders(bool b) {
        cup.GetComponent<BoxCollider>().enabled = b;
        cable.GetComponent<BoxCollider>().enabled = b;
        waterContainer.GetComponent<BoxCollider>().enabled = b;
        filter.GetComponent<BoxCollider>().enabled = b;
        gameObject.GetComponent<BoxCollider>().enabled = b;
    }
}
