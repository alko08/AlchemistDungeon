using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronScript : MonoBehaviour
{
    public GameController gameHandler;
    public GameInventory inventory;

    void Start()
    {
        // Finding the inventory GameController.
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
        
        // Finding the inventory script contained by the GameController.
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If it collides with the player and canCraft is true, call Craft1() in inventory.
        if ((other.gameObject.tag == "Player") && (inventory.canCraft1 == true))
        {
            inventory.Craft1();
        }
    }
}
