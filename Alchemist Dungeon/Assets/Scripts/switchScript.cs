using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    private GameObject toggleCol1;
    private GameObject toggleFore1;
    private GameObject toggleSwitch1;
    private GameObject toggleCol2;
    private GameObject toggleSwitch2;
    private GameObject toggleFore2;
    private bool oneActive = true;
    private bool touchingPlayer = false;
    
    // Okay so I know I could have done this without making a bunch of tags, but
    // by the time I realized it, I'd already made 6 of them, so I'm gonna keep
    // them like this for now.
    void Start()
    {
        toggleCol1 = GameObject.FindWithTag("toggle1");
        toggleCol2 = GameObject.FindWithTag("toggle2");

        toggleFore1 = GameObject.FindWithTag("toggle3");
        toggleFore2 = GameObject.FindWithTag("toggle4");

        toggleSwitch1 = GameObject.FindWithTag("toggle5");
        toggleSwitch2 = GameObject.FindWithTag("toggle6");

        toggleCol2.SetActive(false);
        toggleFore2.SetActive(false);
        toggleSwitch2.SetActive(false);
    }

    // Proof of concept code that just detects if a player has entered the 
    // switch.
    // // On collision with player, switch the active layers.
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Player")
    //     {
    //         oneActive = !oneActive;

    //         toggleCol1.SetActive(oneActive);
    //         toggleCol2.SetActive(!oneActive);

    //         toggleFore1.SetActive(oneActive);
    //         toggleFore2.SetActive(!oneActive);

    //         toggleSwitch1.SetActive(oneActive);
    //         toggleSwitch2.SetActive(!oneActive);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Switch touched");
        
        if(col.gameObject.tag == "Player"){
            touchingPlayer = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Switch untouched");
        
        if(col.gameObject.tag == "Player"){
            touchingPlayer = false;
        }
    }

    void Update() {
        // If [E] key is pressed, cauldron activates.
        if (touchingPlayer && Input.GetKeyDown(KeyCode.E)) {
            oneActive = !oneActive;

            toggleCol1.SetActive(oneActive);
            toggleCol2.SetActive(!oneActive);

            toggleFore1.SetActive(oneActive);
            toggleFore2.SetActive(!oneActive);

            toggleSwitch1.SetActive(oneActive);
            toggleSwitch2.SetActive(!oneActive);
        }
    }
}
