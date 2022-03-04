using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caulTileScript1 : MonoBehaviour
{
    private GameController gameHandler;
    private GameInventory inventory;

    // On start, find the inventory manager and assign it to a variable you
    // can reference.
    void Start()
    {
        // Finding the inventory GameController.
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
        
        // Finding the inventory script contained by the GameController.
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
    }

    // If any of the recipes can be crafted, make invisible. Else, make visible.
    void Update()
    {
        if (inventory.canCraft1 == true && inventory.recipeNum == 1)
        {
            this.gameObject.SetActive(false);
        } else {
            this.gameObject.SetActive(true);
        }

        if (inventory.canCraft2 == true && inventory.recipeNum == 2)
        {
            this.gameObject.SetActive(false);
        } else {
            this.gameObject.SetActive(true);
        }

        if (inventory.canCraft3 == true && inventory.recipeNum == 3)
        {
            this.gameObject.SetActive(false);
        } else {
            this.gameObject.SetActive(true);
        }

        if (inventory.canCraft4 == true && inventory.recipeNum == 4)
        {
            this.gameObject.SetActive(false);
        } else {
            this.gameObject.SetActive(true);
        }
    }
}
