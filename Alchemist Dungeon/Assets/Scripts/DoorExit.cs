using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    public bool canExit = false;
    public GameObject OpenDoor;
    public GameObject ClosedDoor;
    public GameObject potion;
    // private GameObject slime;

    void Start()
    {
        if (!canExit) {
            OpenDoor.SetActive(false);
            ClosedDoor.SetActive(true);
            // slime = GameObject.FindWithTag("Slime");
        }
    }

    // Update is called once per frame. NO LONGER NEEDED, uses Trigger now.
    // void Update()
    // {
    //     Debug.Log(canExit + " = " + Physics2D.OverlapCircle(transform.position, 0f, Player));
    //     if (canExit && Physics2D.OverlapCircle(transform.position, 0f, Player)) {
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && canExit){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EnableExit() {
        StartCoroutine(WaitForDoor());
        // slime.SetActive(false);
    }
    
    IEnumerator WaitForDoor() {
        yield return new WaitForSeconds(.8f);
        canExit = true;
        OpenDoor.SetActive(true);
        ClosedDoor.SetActive(false);
        FindObjectOfType<AudioManager>().Play("DoorOpen");
    }

    public void ThrowPotion() {
        potion.SetActive(true);
    }
}
