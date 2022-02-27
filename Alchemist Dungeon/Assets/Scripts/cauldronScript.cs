using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cauldronScript : MonoBehaviour
{
    // Pseudo.
    // If collides with player and canCraft is true, remove ingredients from
    // player's inventory and add a potion.

    public GameController gameHandler;

    void Start(){
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
    }

    public void OnTrigger(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && (gameHandler.canCraft1))
        {
            gameHandler.Craft1();
        }
    }
}
