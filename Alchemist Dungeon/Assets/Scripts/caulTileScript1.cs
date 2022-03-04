using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caulTileScript1 : MonoBehaviour
{
    private GameController gameHandler;
    private GameInventory inventory;
    private GameObject glowCauldron;

    // On start, find the inventory manager and assign it to a variable you
    // can reference. Also find the glowing cauldron so you can set it active
    // when canCraft1 == true.
    void Start()
    {
        // Finding the inventory GameController.
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
        
        // Finding the inventory script contained by the GameController.
        inventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();

        // Finding glowingCauldron before making it invisible.
        glowCauldron = GameObject.FindWithTag("highlighted");
        glowCauldron.gameObject.SetActive(false);
    }

    // If any of the recipes can be crafted, make invisible. Else, make visible.
    void Update()
    {
        if (inventory.canCraft1 == true)
        {
            this.gameObject.SetActive(false);
            glowCauldron.gameObject.SetActive(true);
        }
    }
}
