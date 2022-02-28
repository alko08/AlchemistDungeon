using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BillPickUp : MonoBehaviour
{

      private GameController gameHandler;
      // public Object inventoryItem;
      //public playerVFX playerPowerupVFX; 
      // public bool isHealthPickUp = true;
      // public bool isSpeedBoostPickUp = false;

      // public int healthBoost = 50;
      // public float speedBoost = 2f;
      // public float speedTime = 2f;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameController>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  // GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());
                  
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}