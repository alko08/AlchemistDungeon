using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronScript : MonoBehaviour
{
    private GameController gameHandler;
    private GameInventory inventory;

    void Start()
    {
        // Finding the inventory GameController.
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
        
        // Finding the inventory script contained by the GameController.
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
    }

    // Old version where passing through caused cauldron to trigger.
    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     // If it collides with the player and canCraft is true, call Craft1() in inventory.
    //     if (other.gameObject.tag == "Player" && inventory.canCraft1 == true
    //     && inventory.recipeNum == 1)
    //     {
    //         inventory.Craft1();
    //     } else if (other.gameObject.tag == "Player" && inventory.canCraft2 == true
    //     && inventory.recipeNum == 2)
    //     {
    //         inventory.Craft2();
    //     } else if (other.gameObject.tag == "Player" && inventory.canCraft3 == true
    //     && inventory.recipeNum == 3)
    //     {
    //         inventory.Craft3();
    //     } else if (other.gameObject.tag == "Player" && inventory.canCraft4 == true
    //     && inventory.recipeNum == 4)
    //     {
    //         inventory.Craft4();
    //     }
    // }

    // Note: Player can perform the following function while sliding past the
    // cauldron. They technically don't even need to be facing it. As long as
    // the key input is detected while the player is in the hitbox, the potion
    // will be crafted.
    public void OnTriggerStay2D(Collider2D other)
    {
        // If [E] key is pressed, cauldron activates.
        if (Input.GetKeyDown("e"))
        {
            if (other.gameObject.tag == "Player" && inventory.canCraft1 == true
        && inventory.recipeNum == 1)
        {
            inventory.Craft1();
        } else if (other.gameObject.tag == "Player" && inventory.canCraft2 == true
        && inventory.recipeNum == 2)
        {
            inventory.Craft2();
        } else if (other.gameObject.tag == "Player" && inventory.canCraft3 == true
        && inventory.recipeNum == 3)
        {
            inventory.Craft3();
        } else if (other.gameObject.tag == "Player" && inventory.canCraft4 == true
        && inventory.recipeNum == 4)
        {
            inventory.Craft4();
        }
        }
    }
}
