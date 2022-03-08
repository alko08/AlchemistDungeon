using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUpBoss: MonoBehaviour {

    private GameInventory playerInventory;
    public string ItemName = "item1";
    public GameObject art;
    private bool isActive;


    void Awake(){
        if (GameObject.FindWithTag("GameHandler") != null) {
            playerInventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
        }
        isActive = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && isActive){
            FindObjectOfType<AudioManager>().Play("MajorPickup");
            //Debug.Log("You found an" + ItemName);
            playerInventory.InventoryAdd(ItemName);
            //playerInventory.removeObjectFromLevel(ItemName);
            isActive = false;
            art.SetActive(isActive);
        }
    }

    public void enableArt() {
        isActive = true;
        art.SetActive(isActive);
    }
}
