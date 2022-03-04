using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowingCaulTileScript : MonoBehaviour
{
    private GameController gameHandler;
    private GameInventory inventory;

    // On start, find the inventory manager and assign it to a variable you
    // can reference. Also, make this layer invisible.
    void Start()
    {
        // Finding the inventory GameController.
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
        
        // Finding the inventory script contained by the GameController.
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();

        this.gameObject.SetActive(false);
    }

    // If any of the recipes can be crafted, make visible. Else, make invisible.
    void Update()
    {
        if (inventory.canCraft1 == true && inventory.recipeNum == 1)
        {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }

        if (inventory.canCraft2 == true && inventory.recipeNum == 2)
        {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }

        if (inventory.canCraft3 == true && inventory.recipeNum == 3)
        {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }

        if (inventory.canCraft4 == true && inventory.recipeNum == 4)
        {
            this.gameObject.SetActive(true);
        } else {
            this.gameObject.SetActive(false);
        }
    }
}
