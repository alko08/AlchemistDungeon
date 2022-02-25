using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour
{
      private GameController gameController; // #1: add variable to hold GameController
      public int scoreValue;

      void Start () { // #2: assign actual Game Controller to variable
            GameObject gameCtrlTemp = GameObject.FindWithTag ("GameController");
            if (gameCtrlTemp != null) {
                  gameController = gameCtrlTemp.GetComponent<GameController>();
            }
            if (gameCtrlTemp == null) {
                  Debug.Log ("Cannot find 'GameController' script");
            }
      }

      private void OnTriggerEnter2D(Collider2D other){
            if (other.tag == "Player"){
                  gameController.AddScore (scoreValue); // add it to the HUD
                  Destroy(gameObject);
            }
      }
}
