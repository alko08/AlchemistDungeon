using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
          if (other.tag == "Player"){
                // add it to the HUD
                Destroy(gameObject);
          }
    }
}
