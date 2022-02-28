using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    public bool canExit = false;
    public LayerMask Player;

    // Update is called once per frame
    void Update()
    {
        if (canExit && Physics2D.OverlapCircle(transform.position, 0f, Player)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EnableExit() {
        canExit = true;
    }
}
