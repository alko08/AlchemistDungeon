using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDeath : MonoBehaviour
{
    private MoveAnim player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PlayerController").GetComponent<MoveAnim>();
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") {
            player.deathTween();
        }
    }
}
